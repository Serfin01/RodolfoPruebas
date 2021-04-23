using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Enemy
{
    private Transform target;

    [Header("Attributes")]
    
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
    public Animator CapyAnim;

    public GameObject particulas;

    [Header("RedHit")]
    [SerializeField] Material hitmat;
    [SerializeField] Material normalmat;
    [SerializeField] GameObject cuerpo;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        particulas.SetActive(false);
    }

    private void Awake()
    {
        CapyAnim.SetBool("moverse", true);
        CapyAnim.SetBool("salirSuelo", false);
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
            //CapyAnim.SetBool("moverse", false);
            //CapyAnim.SetBool("salirSuelo", true);
            target = nearestEnemy.transform;
            particulas.SetActive(true);
        }
    }

    void Update()
    {
        if(target == null)
        {
            CapyAnim.SetBool("moverse", true);
            CapyAnim.SetBool("salirSuelo", false);
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
            //hacer que se espere un poco pa la animacion
            GameObject.Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("enemyDeath");
            CapyAnim.SetBool("MeterseSuelo", true);
            CapyAnim.SetBool("Disparar", false);
        }
    }
    //que pida bool canShoot y le meto el if correspondiente
    public void Shoot()
    {
        //Debug.Log("shoot");
        if (canShoot) { 
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            CapyAnim.SetBool("Disparar", true); 
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    IEnumerator Die()
    {
        FindObjectOfType<AudioManager>().Play("enemyDeath");
        CapyAnim.SetTrigger("MeterseSuelo");
        yield return new WaitForSeconds(3f);
        GameObject.Destroy(gameObject);
    }

    IEnumerator Hitted()
    {
        cuerpo.GetComponent<SkinnedMeshRenderer>().material = hitmat;
        yield return new WaitForSeconds(0.1f);
        cuerpo.GetComponent<SkinnedMeshRenderer>().material = normalmat;
    }
}
