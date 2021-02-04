using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Policy;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public GameObject currentTarget;
    public Transform turretHead;

    public float attackDist;
    public float attackDamage;
    public float shotCoolDown;
    private float timer;
    public float lookSpeed = 2f;

    public bool showRange = false;

    public TurretShoot_Base shotScript;

    private void Start()
    {
        InvokeRepeating("CheckForTarget", 0, 0.5f);
        shotScript = GetComponent<TurretShoot_Base>();
    }

    private void Update()
    {
        CheckForTarget();

        if (currentTarget != null)
        {
            FollowTarget();
        }

        timer += Time.deltaTime;

        if (timer >= shotCoolDown)
        {
            timer = 0;
            Shoot();
        }
    }

    private void CheckForTarget()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, attackDist, 4);

        Debug.Log(colls[0].gameObject.name);
    }

    private void FollowTarget()
    {
        Vector3 targetDir = currentTarget.transform.position - transform.position;
        targetDir.y = 0;
        turretHead.forward = targetDir;
    }

    private void Shoot()
    {
        shotScript.Shoot(currentTarget);
    }

    private void OnDrawGizmos()
    {
        if(showRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackDist);
        }
    }
}
