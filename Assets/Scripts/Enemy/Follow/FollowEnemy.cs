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
    [SerializeField] Renderer renderer;
    private bool canMove = true;

    // Use this for initialization
    void Start()
    {

        trPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        FindObjectOfType<AudioManager>().Play("PuñakosWalk");

    }

    // Update is called once per frame
    void Update()
    {
        
        if (canMove)
        {
            NavMeshAgent agente = GetComponent<NavMeshAgent>();
            agente.SetDestination(trPlayer.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpeed * Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("PuñakosWalk");
        }


        /*
        if (this._animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            //StartCoroutine("Fade");
            GameObject.Destroy(gameObject);
        }
        */
    }

    void Damage()
    {
        Debug.Log("la picadura de la cobra gei");
        FindObjectOfType<AudioManager>().Play("puñakoPunch");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, gzRange);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.rigidbody.CompareTag("Player"))
        {
            _animator.SetTrigger("Punch");
        }
            //collision.rigidbody.GetComponent<Player>().Damaged(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Damage();
            other.GetComponent<Player>().Damaged(damage);
        }
    }
    /*
    void Die()
    {
        _animator.SetTrigger("death");
    }
    */
    IEnumerator Die()
    {
        FindObjectOfType<AudioManager>().Play("enemyDeath");
        canMove = false;
        _animator.SetTrigger("death");
        yield return new WaitForSeconds(3f);
        GameObject.Destroy(gameObject);
    }

    /*IEnumerator Hit()
    {


        yield return new WaitForSeconds(1f);


    }*/
}
