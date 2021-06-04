using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DashIA : Enemy
{
    [Header("Player Nearby")]
    [SerializeField] float lookRadius = 15f;
    [SerializeField] float dashDistance = 5f;

    [Header("Player References")]
    [SerializeField] GameObject player;
    [SerializeField] Transform trPlayer;

    [Header("Speed Settings")]
    [SerializeField] float rotSpeed = 3.0f;
    //private float iniSpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float dashSpeed;

    bool canMove = true;
    bool isAttacking = false;
    bool setDestin = false;

    Transform target;
    NavMeshAgent agent;

    public Animator animatorMarti;

    public AudioSource audioSteps;
    //public AudioSource audiorun;
    //public AudioSource audiostop;

    [Header("RedHit")]
    [SerializeField] Material hitmat;
    [SerializeField] Material normalmat;
    [SerializeField] GameObject cuerpo;

    public BoxCollider colider;


    private void Awake()
    {
        audioSteps.enabled = false;
        //audiorun.enabled = false;
        //audiostop.enabled = false;
    }

    void Start()
    {
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        normalSpeed = agent.speed;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (canMove && !isAttacking)
        {
            animatorMarti.SetTrigger("run");
            audioSteps.enabled = true;
            agent.SetDestination(target.position);
            if (distance <= lookRadius)
            {
                StartCoroutine(Dash());
            }


        }
        if (isAttacking)
        {
            //animatorMarti.SetTrigger("attack");
            if (agent.remainingDistance <= 0.01f)
            {
                //animatorMarti.SetTrigger("stop");
                Debug.Log("parao");
                isAttacking = false;
                canMove = false;
                StartCoroutine(TimeStunned());
            }
        }

        //GetComponent<NavMeshAgent>().speed = 10f;
    }
    /*
    void Dash()
    {
        GetComponent<NavMeshAgent>().speed = 20f;
        GetComponent<NavMeshAgent>().acceleration = 100f;

        //GetComponent<NavMeshAgent>().speed = 10f;
    }
    */

    IEnumerator Dash()
    {
        animatorMarti.SetTrigger("attack");
        //audiorun.enabled = true;
        isAttacking = true;
        agent.speed = 0f;

        yield return new WaitForSeconds(0.3f);

        agent.speed = dashSpeed;
        Vector3 currentPlayerPos = trPlayer.position;
        agent.SetDestination(currentPlayerPos);
        
        setDestin = true;

        /*
        animatorMarti.SetFloat("speed", 2f);
        audiorun.enabled = true;
        GetComponent<NavMeshAgent>().speed = dashSpeed;
        GetComponent<NavMeshAgent>().acceleration = dashSpeed;
        //_animator.SetTrigger("death");
        yield return new WaitForSeconds(1f);
        audiorun.enabled = false;
        canMove = false;
        audiostop.enabled = true;
        animatorMarti.SetFloat("speed", 0f);
        //normalSpeed = iniSpeed;
        yield return new WaitForSeconds(1f);
        audiostop.enabled = false;
        animatorMarti.SetFloat("speed", 1f);
        canMove = true;
        */
    }
    IEnumerator TimeStunned()
    {
        //Debug.Log("parao");

        //audiostop.enabled = true;
        animatorMarti.SetTrigger("stop");
        yield return new WaitForSeconds(2f);
        animatorMarti.SetTrigger("run");
        canMove = true;
        agent.speed = normalSpeed;
    }

    IEnumerator Die()
    {
        canMove = false;
        animatorMarti.SetTrigger("dead");
        agent.isStopped = true;
        colider.enabled = false;
        yield return new WaitForSeconds(3f);
        GameObject.Destroy(gameObject);
    }

    IEnumerator Hitted()
    {
        cuerpo.GetComponent<SkinnedMeshRenderer>().material = hitmat;
        yield return new WaitForSeconds(0.1f);
        cuerpo.GetComponent<SkinnedMeshRenderer>().material = normalmat;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
