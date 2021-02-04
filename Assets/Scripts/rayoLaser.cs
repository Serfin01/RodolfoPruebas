using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayoLaser : MonoBehaviour
{

    private LineRenderer lr;
    [SerializeField] int damage;
    public Enemy enemy;

    private bool canShoot;

    void Start()
    {
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
            if (hit.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("enemigooo");
                hit.transform.GetComponent<Enemy>().Damaged(damage);
            }
        }
        else lr.SetPosition(1, transform.forward * 5000);
    }
    
}