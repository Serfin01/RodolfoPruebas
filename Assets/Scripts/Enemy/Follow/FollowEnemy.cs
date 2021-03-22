using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowEnemy : Enemy
{
    Transform trPlayer;
    private float rotSpeed = 3.0f;
    private float moveSpeed = 3.0f;
    [SerializeField] Vector3 range;
    [SerializeField] float gzRange = 10;
    public int damage;
    public Animator _animator;

    // Use this for initialization
    void Start()
    {

        trPlayer = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agente = GetComponent<NavMeshAgent>();
        agente.SetDestination(trPlayer.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpeed * Time.deltaTime);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        
        if(health <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        
    }

    void Damage()
    {
        Debug.Log("la picadura de la cobra gei");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, gzRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Damage();
            other.GetComponent<Player>().Damaged(damage);
            _animator.SetTrigger("Punch");
        }
    }
}
