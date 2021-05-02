using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    //PlayerInput input;

    [SerializeField] CharacterController controller;

    [SerializeField] float speed;
    [SerializeField] float gravity = -9.81f;

    [SerializeField] GameObject shadow;

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
    bool canMove = true;
    bool isMoving = true;

    [Header("Fall Settings")]
    [SerializeField] GameObject[] spawnRodolfo;
    [SerializeField] GameObject ragDoll;
    int fall = 1000;
    [SerializeField] GameObject pistola;
    public AudioSource audioSteps;

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
    }
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        if (isGrounded)
        {
            shadow.SetActive(true);
        }
        else
        {
            shadow.SetActive(false);
        }
        
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
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

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
                dash.emitting = true;
                StartCoroutine(Dash());
                Debug.Log("dash2");
            }
        }
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
        if (other.CompareTag("fall1"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[0].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall2"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[1].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall3"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[2].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall4"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[3].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall5"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[4].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall6"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[5].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall7"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[6].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall8"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[7].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall9"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[8].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall10"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[9].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("fall11"))
        {
            controller.enabled = false;
            transform.position = spawnRodolfo[10].transform.position;
            ragDoll.SetActive(false);
            pistola.SetActive(true);
            controller.enabled = true;
            //_animator.enabled = true;
        }
        if (other.CompareTag("preFall"))
        {
            controller.enabled = false;
            pistola.SetActive(false);
            ragDoll.SetActive(true);
            controller.enabled = true;
            this.GetComponent<Player>().Damaged(fall);
            //_animator.enabled = false;
        }
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

        while(Time.time < startTime + dashTime)
        {
            controller.Move(move * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
