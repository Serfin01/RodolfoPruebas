using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTurretAnimation : MonoBehaviour
{
    TurretEnemy turretEnemy;
    // Start is called before the first frame update
    void Start()
    {
        turretEnemy = GetComponentInParent<TurretEnemy>();
        //Debug.LogError(turretEnemy.gameObject.name);
        
    }


    public void Shoot()
    {
        turretEnemy.Shoot();
    }
    
}
