using System.Collections;
using UnityEngine;

public class MissileShot : TurretShoot_Base
{
    public override void Shoot(GameObject go)
    {
        Debug.Log("Shot from Missile Shot");
    }
}
