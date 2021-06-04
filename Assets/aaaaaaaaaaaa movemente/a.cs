using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    //PlayerInput input;

    [SerializeField] CharacterController controller;

    [SerializeField] float speed;
    [SerializeField] float gravity = -9.81f;
    public bool canMove = true;

    //[SerializeField] GameObject shadow;

    Animator _animator;

    [SerializeField] GameObject pistola;
    public AudioSource audioSteps;

    [SerializeField] Transform rotatingElement;

    [Header("Ground Settings")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTime;
    [SerializeField] float inicooldownDash;
    [SerializeField] TrailRenderer dash;
    float cooldownDash;
    bool isCooldownDash = false;

    Vector3 velocity;
    Vector3 move;
    bool isGrounded;
    bool isMoving = true;

    [Header("Fall Settings")]
    [SerializeField] GameObject[] spawnRodolfo;
    [SerializeField] GameObject ragDoll;
    int fall = 15;

    public GameObject Godmode;

    bool GodmodeOn;
    
    private void Awake()
    {
        /*
        input = new PlayerInput();
        input.CharacterControls.Dash.performed += ctx => {
            callDash();
        };
        */
        cooldownDash = inicooldownDash;
        dash.emitting = false;
        _animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
       

     
        /*
        if (isGrounded)
        {
            shadow.SetActive(true);
        }
        else
        {
            shadow.SetActive(false);
        }
        */
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        move = transform.right * x + transform.forward * z;

        if (canMove)
        {
            controller.Move(move * speed * Time.deltaTime);
            if (move.x != 0f || move.z != 0f)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            if(isMoving)
            {
                if(!audioSteps.isPlaying)
                {
                    audioSteps.Play();
                }
            }
            else
            {
                audioSteps.Stop();
            }

            Vector3 localVelocity = rotatingElement.InverseTransformDirection(controller.velocity);
            localVelocity.Normalize();

            _animator.SetFloat("velZ", localVelocity.z, 0.1f, Time.deltaTime);
            _animator.SetFloat("velX", localVelocity.x, 0.1f, Time.deltaTime);
        }

        Gravity();

        /*if (Input.GetKeyDown(KeyCode.F10))
        {
            Debug.Log("f10");
            if(!GodmodeOn)
            {
                godmodeON();
                Debug.Log("godmodeon");
            }
            else
            {
                godmodeOFF();
                Debug.Log("godmodeFF");
            }

        }*/

        controller.Move(velocity * Time.deltaTime); //Solo la gravedad

        if (isCooldownDash)
        {
            CooldownDash();
        }
        if (!isCooldownDash)
        {
            
            if (Input.GetKeyDown("space"))
            {
                isCooldownDash = true;
                cooldownDash = inicooldownDash;
                //dash.emitting = true;
                StartCoroutine(Dash());
                Debug.Log("dash2");
            }
        }

    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

    }
    void CooldownDash()
    {
        cooldownDash -= Time.deltaTime;
        dash.emitting = false;

        if (cooldownDash <= 0.0f)
        {
            isCooldownDash = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("preFall"))
        {
            StartCoroutine(ReturnFromFall());
        }
    }

    IEnumerator ReturnFromFall()
    {

        ragDoll.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        controller.enabled = false;
        transform.position = SpawnPoint();
        this.GetComponent<Player>().Damaged(fall);
        ragDoll.SetActive(true);
        Debug.Log("marica");

        controller.enabled = true;
    }

    Vector3 SpawnPoint()
    {
        Vector3 closePoint = Vector3.zero;
        float distance = Mathf.Infinity;
        for (int i = 0; i < spawnRodolfo.Length; i++)
        {
            float cntDistance = Vector3.Distance(gameObject.transform.position, spawnRodolfo[i].transform.position);
            if(cntDistance < distance)
            {
                distance = cntDistance;
                closePoint = spawnRodolfo[i].transform.position;
            }
        }
        return closePoint;
    } 
    /*
    void callDash()
    {
        StartCoroutine(Dash());
        Debug.Log("dash");
    }
    */

    IEnumerator Dash()
    {
        float startTime = Time.time;
        FindObjectOfType<AudioManager>().Play("dash");

        while (Time.time < startTime + dashTime)
        {
            controller.Move(move * dashSpeed * Time.deltaTime);
            dash.emitting = true;

            yield return null;
        }
    }

    /*void godmodeON ()
    {
        Godmode.SetActive(true);
        GetComponent<Collider>().enabled = false;
        gravity = 0f;
        velocity.y = 0f;
        GodmodeOn = true;
    }

    void godmodeOFF ()
    {
        GetComponent<Collider>().enabled = true;
        Godmode.SetActive(false);
        gravity = -9.81f;
        velocity.y = -2f;
        GodmodeOn = false;
    }*/
}
