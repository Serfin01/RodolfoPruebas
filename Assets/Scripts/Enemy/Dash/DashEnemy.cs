using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    [SerializeField] private float dashForce;
    [SerializeField] private float recoveryTime;
    Transform trPlayer;
    private float rotSpeed = 3.0f;
    private float moveSpeed = 3.0f;

    float distancia;
    //[SerializeField] Transform taget;

    private Rigidbody rb;

    float iniMoveSpeed;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        iniMoveSpeed = moveSpeed;
    }

    void Update()
    {
        if(canMove == true)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpeed * Time.deltaTime);
            transform.LookAt(trPlayer);

            transform.position += transform.forward * moveSpeed * Time.deltaTime;

            distancia = Vector3.Distance(this.transform.position, trPlayer.position);

            if (distancia <= 5)
            {
                moveSpeed = 50;
                if (distancia <= 0.2f)
                {
                    canMove = false;
                    StartCoroutine(Cast());
                }
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //StartCoroutine(Cast());
            
        }
        /*
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpeed * Time.deltaTime);

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        */
    }
    
    public IEnumerator Cast()
    {
        moveSpeed = iniMoveSpeed;

        yield return new WaitForSeconds(recoveryTime);

        canMove = true;
    }
    
}
