using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPatrol : MonoBehaviour
{
    [SerializeField] Transform[] targetPoints;
    [SerializeField] int speed;

    private int target;

    private float waitTime;
    [SerializeField] float startWaitTime;
    private Vector3 point = new Vector3();

    bool canMove = true;
    public bool canShoot = true;
    [SerializeField] Collider colTurret;

    public AudioSource audio;

    TurretEnemy turretEnemy;

    public Animator CapyAnim; 

    void Start()
    {
        target = 0;
        waitTime = startWaitTime;
        turretEnemy = GetComponent<TurretEnemy>();

    }

    void Update()
    {

        float distance;
        distance = Vector3.Distance(transform.position, targetPoints[target].position);

            if (distance <= 0.5f)
            {
                waitTime -= Time.deltaTime;
                canMove = false;
                canShoot = true;
                Move();
            }
        if (transform.position != targetPoints[target].position/*canMove == true*/)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoints[target].position, speed * Time.deltaTime);
        }

        /*
        else
        {
            target++;
            if (target >= targetPoints.Length)
            {
                target = 0;
            }
            Debug.Log("siguiente xfa");
        }
        */

        

        if(waitTime <= 0)
        {
            target++;
            if (target >= targetPoints.Length)
            {
                target = 0;

            }
            canMove = true;
            canShoot = false;

            waitTime = startWaitTime;
            Move();
        }

        if (canMove == true)
        {

            GetComponent<Collider>().enabled = false;
            if (audio.isPlaying == false)
            {
                audio.volume = Random.Range(0.2f, 0.4f);
                audio.pitch = Random.Range(0.8f, 1.1f);
                audio.Play();
            }
            turretEnemy.canShoot = false;

        }
        else
        {
            GetComponent<Collider>().enabled = true;
            audio.Stop();
            turretEnemy.canShoot = true;
        }

    }

    private void Move()
    {
        if (canMove == true)
        {
            //CapyAnim.SetTrigger("MeterseSuelo");
            CapyAnim.SetBool("MeterseSuelo", true);
            CapyAnim.SetBool("moverse", true);
            CapyAnim.SetBool("salirSuelo", false);
            CapyAnim.SetBool("Disparar", false);

        }
        else
        {
            CapyAnim.SetBool("moverse", false);
            CapyAnim.SetBool("salirSuelo", true);
        }
    }

}
