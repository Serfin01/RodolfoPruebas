using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayoLaser : MonoBehaviour
{
    //[SerializeField] float duration;

    //float iniDuration;
    private LineRenderer lr;
    [SerializeField] int damage;
    public Enemy enemy;
    //[SerializeField] Laser rayo;

    private bool canShoot;
    bool check = false;

   // GameObject laser;

    void Start()
    {
        //laser = GameObject.Find("Laser");
        //duration = 3;
        //iniDuration = duration;
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }
            if (hit.transform.gameObject.tag == "Enemy" && check == true)
            {
                Debug.Log("enemigooo");
                hit.transform.GetComponent<Enemy>().Damaged(damage);
            }
        }
        else lr.SetPosition(1, transform.forward * 5000);
        /*
        duration -= Time.deltaTime;

        if (duration <= 0)
        {
            DestroyLaser();
        }
        */
    }

    public void activo(bool si)
    {
        if(si == true)
        {
            check = true;
        }
        else
        {
            check = false;
        }
    }

    /*
    void DestroyLaser()
    {
        Destroy(laser);
    }
    */
}