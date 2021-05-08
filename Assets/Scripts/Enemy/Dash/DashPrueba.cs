using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DashPrueba : MonoBehaviour
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
    public AudioSource audiorun;
    public AudioSource audiostop;

    [Header("RedHit")]
    [SerializeField] Material hitmat;
    [SerializeField] Material normalmat;
    [SerializeField] GameObject cuerpo;

    public BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        normalSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (canMove && !isAttacking)
        {
            agent.SetDestination(target.position);
            if (distance <= lookRadius)
            {
                StartCoroutine(Dash());
            }
        }

        if (setDestin && isAttacking)
        {

            agent.SetDestination(target.position);
        }
        Debug.Log(target.position);
    }

    IEnumerator Dash()
    {
        isAttacking = true;
        agent.speed = 0f;

        yield return new WaitForSeconds(0.3f);

        agent.speed = dashSpeed;
        setDestin = true;
        Debug.Log(agent.hasPath);
        
    }
}
