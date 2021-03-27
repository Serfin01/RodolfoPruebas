using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    PlayerInput input;

    Vector2 currentMovement;
    bool movementPressed = false;
    Vector3 moveDirection;
    
    public CapsuleCollider colider;
    public GameObject canvas;
    public static bool isGodModOn = true;
    public Rigidbody r_body;
    public float speed = 700f;

    [SerializeField] int distDash;
    [SerializeField] TrailRenderer dash;

    [SerializeField] Transform rotatingElement;

    public AudioSource audio;

    Animator _animator;

    public bool canMove = true;
    bool isGrounded;
    float gravity = -10;
    Vector3 velocity;
    Vector3 newNewVelocity;
    [SerializeField] GameObject ragDoll;

    [Header("Set Ground")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Movement.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
            //Debug.Log(ctx.ReadValueAsObject());
        };
        input.CharacterControls.GodMode.performed += GodMode;
        input.CharacterControls.Dash.performed += Dash;
        input.CharacterControls.Dash.canceled += DisableDash;
        dash.emitting = false;
        _animator = GetComponentInChildren<Animator>();
    }
    void HandleFixed()
    {
            r_body.velocity = newNewVelocity;
    }

    void HandleMovement()
    {
        if (isGrounded)
        {
            moveDirection = new Vector3(currentMovement.x, 0, currentMovement.y).normalized;
            newNewVelocity = moveDirection * Time.deltaTime * speed;

            if (audio.isPlaying == false)
            {
                audio.volume = Random.Range(0.2f, 0.4f);
                audio.pitch = Random.Range(0.8f, 1.1f);
                audio.Play();
            }
            /*
            if (movementPressed)
            {

            }
            */
        }
        else
        {
            ragDoll.SetActive(true);
        }

        // Animating

        Vector3 localVelocity = rotatingElement.InverseTransformDirection(r_body.velocity);
        localVelocity.Normalize();

        //Debug.Log("LocalVelocity " + localVelocity);
        _animator.SetFloat("velZ", localVelocity.z, 0.1f, Time.deltaTime);
        _animator.SetFloat("velX", localVelocity.x, 0.1f, Time.deltaTime);
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        newNewVelocity.y = velocity.y;
        velocity.y += gravity * Time.deltaTime;
        HandleMovement();
    }

    void Gravity()
    {

    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    private void FixedUpdate()
    {
        //HandleMovement();
        HandleFixed();
        FixedUpdateDash();
    }

    void GodMode(InputAction.CallbackContext obj)
    {
        if (isGodModOn)
        {
            GodModOn();
        }
        else
        {
            GodModOff();
            isGodModOn = true;
        }
    }

    void GodModOn()
    {
        Debug.Log("GodModeON");
        colider.isTrigger = true;
        canvas.SetActive(true);
        isGodModOn = false;
        r_body.useGravity = false;
        transform.gameObject.tag = "Untagged";
    }

    void GodModOff()
    {
        Debug.Log("GodModeOFF");
        colider.isTrigger = false;
        canvas.SetActive(false);
        isGodModOn = true;
        r_body.useGravity = true;
        transform.gameObject.tag = "Player";
    }

    bool performADash = false;
    void Dash(InputAction.CallbackContext obj)
    {
        performADash = true;
    }

    bool mustStop = false;
    void FixedUpdateDash()
    {
        if (performADash)
        {
            performADash = false;
            mustStop = true;

            Vector3 dashMovement = Vector3.zero;
            if (Input.GetAxis("Horizontal") > 0)  { dashMovement.x = distDash;  }
            if (Input.GetAxis("Horizontal") < 0)  { dashMovement.x = -distDash; }
            if (Input.GetAxis("Vertical") > 0)    { dashMovement.z = distDash;  }
            if (Input.GetAxis("Vertical") < 0)    { dashMovement.z = -distDash; }

            if (dashMovement.magnitude > 0.1f)
            {
                r_body.velocity = dashMovement / Time.fixedDeltaTime;
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");
            }
        }
        else if (mustStop)
        {
            r_body.velocity = Vector3.zero;
            mustStop = false;
        }
    }

    void DisableDash(InputAction.CallbackContext obj)
    {
        dash.emitting = false;
    }
}
