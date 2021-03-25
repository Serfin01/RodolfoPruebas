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
    private float baseAcceleration;
    private float baseSpeed;

    bool canMove = true;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        baseAcceleration = GetComponent<NavMeshAgent>().acceleration;
        baseSpeed = GetComponent<NavMeshAgent>().speed;
        //iniSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (canMove)
        {
            GetComponent<NavMeshAgent>().speed = baseSpeed;
            GetComponent<NavMeshAgent>().acceleration = baseAcceleration;
            if (distance <= lookRadius)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpeed * Time.deltaTime);
                agent.SetDestination(target.position);
            }

            if(distance <= dashDistance)
            {
                //Dash();
                StartCoroutine("Dash");
            }
        }
        else
        {
            GetComponent<NavMeshAgent>().speed = 0;
            GetComponent<NavMeshAgent>().acceleration = 0;
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
        GetComponent<NavMeshAgent>().speed = dashSpeed;
        GetComponent<NavMeshAgent>().acceleration = dashSpeed;
        //_animator.SetTrigger("death");
        yield return new WaitForSeconds(1f);
        canMove = false;
        GetComponent<NavMeshAgent>().speed = normalSpeed;
        GetComponent<NavMeshAgent>().acceleration = baseAcceleration;
        //normalSpeed = iniSpeed;
        yield return new WaitForSeconds(1f);
        canMove = true;
    }

    IEnumerator Die()
    {
        canMove = false;
        //_animator.SetTrigger("death");
        yield return new WaitForSeconds(3f);
        GameObject.Destroy(gameObject);
    }
}
