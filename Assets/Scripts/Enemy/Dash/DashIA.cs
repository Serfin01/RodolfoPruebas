using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DashIA : MonoBehaviour
{
    public float lookRadius = 10f;

    [SerializeField] GameObject player;
    [SerializeField] Transform trPlayer;
    private float rotSpeed = 3.0f;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpeed * Time.deltaTime);
            agent.SetDestination(target.position);
        }
    }

    void Speed()
    {
        //GetComponent<NavMeshAgent>().speed = 10f;
    }
}
