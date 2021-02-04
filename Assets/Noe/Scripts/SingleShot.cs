using System.Collections;
using UnityEngine;

public class SingleShot : TurretShoot_Base
{
    public Transform muzzle;

    public override void Shoot(GameObject go)
    {
        Debug.Log("Shot from Single Shot");
    }
}
