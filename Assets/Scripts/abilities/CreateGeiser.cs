using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGeiser : BaseAbility
{
    [SerializeField] GameObject shield;

    Ray myRay;
    RaycastHit hit;

    private void Start()
    {
        shield = Resources.Load<GameObject>("Laser");
        iniCooldown = 3;
    }

    private void Update()
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    public override void UseSpell()
    {
        Debug.Log("Geiser");
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hit))
        {
            if (isCooldown)
            {
                //StartCoroutine(Shot());
            }
            else
            {
                InstantiateGeiser();
                isCooldown = true;
            }
        }/*

        if (isCooldown)
        {
            //StartCoroutine(Shot());
        }
        else
        {
            InstantiateShield();
            isCooldown = true;
            cooldown = iniCooldown;
        }
        */
    }

    void InstantiateGeiser()
    {
        Instantiate(shield, hit.point, Quaternion.identity);
        cooldown = iniCooldown;
    }
}
