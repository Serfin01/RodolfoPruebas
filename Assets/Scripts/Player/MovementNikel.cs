using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementNikel : MonoBehaviour
{

    public int speed;
    Vector3 moveDirection;
    [SerializeField] int distDash;
    [SerializeField] TrailRenderer dash;
    public AudioSource audio;
    public static bool isGodModOn = true;
    public CapsuleCollider colider;
    public GameObject canvas;
    public Rigidbody r_body;
    PlayerControls controls;

    Vector2 move;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += cntxt => move = Vector2.zero;
    }

    private void OnEnable()
    {
        //controls.Gameplay.Move.performed += HandleMove;
        //controls.Gameplay.Move.Enable();
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        //controls.Gameplay.Move.performed -= HandleMove;
        controls.Gameplay.Disable();
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        /*
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        r_body.velocity = moveDirection * speed * Time.deltaTime;
        */
    }

    private void FixedUpdate()
    {
        /*
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        

        //transform.Translate(moveDirection);
        //r_body.AddForce(moveDirection * speed, ForceMode.VelocityChange);
        r_body.velocity = moveDirection * speed * Time.deltaTime;
        */
    }

    void Update()
    {
        moveDirection = new Vector3(move.x * 5, 0, move.y * 5).normalized;
        r_body.velocity = moveDirection;

        if (Input.GetAxis("Vertical") != 0 && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.2f, 0.4f);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
        if (Input.GetAxis("Horizontal") != 0 && audio.isPlaying == false)
        {
            audio.volume = Random.Range(0.2f, 0.4f);
            audio.pitch = Random.Range(0.8f, 1.1f);
            audio.Play();
        }
        if(Input.GetKeyDown(KeyCode.F10))
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

        Dash();
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

    void Dash() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(distDash, 0, 0);
                dash.emitting = true;
                //FindObjectOfType<AudioManager>().Play("dash");
                AudioManager.instance.Play("dash");
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(-distDash, 0, 0);
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");
                AudioManager.instance.Play("dash");
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(0, 0, distDash);
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(0, 0, -distDash);
                dash.emitting = true;
                FindObjectOfType<AudioManager>().Play("dash");

            }

        }
        else
        {
            dash.emitting = false;
        }
    }
}
