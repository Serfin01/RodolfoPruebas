using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Enemy
{
    private Transform target;

    [Header("Attributes")]

    [SerializeField] GameObject boss;
    [SerializeField] float range = 15f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    [SerializeField] string enemyTag = "Player";

    [SerializeField] Transform partToRotate;
    [SerializeField] float turnSpeed = 10f;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;

    public bool canShoot;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

        if(health <= 0)
        {
            GameObject.Destroy(gameObject);
            boss.SetActive(true);
            FindObjectOfType<AudioManager>().Play("enemyDeath");
        }
    }
    //que pida bool canShoot y le meto el if correspondiente
    public void Shoot()
    {
        //Debug.Log("shoot");
        if (canShoot) { 
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
