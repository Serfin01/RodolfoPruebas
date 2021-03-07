using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public abstract class BaseAbility : MonoBehaviour
{
    

    protected bool isCooldown = false;
    protected float cooldown;
    protected float iniCooldown;
    protected Image imageCooldown;

    

    public virtual void UseSpell()
    {
        
    }
    /*
    void Start()
    {
        imageCooldown.fillAmount = 0.0f;
    }

    void Update()
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    protected void ApplyCooldown()
    {
        cooldown -= Time.deltaTime;

        if (cooldown < 0.0f)
        {
            isCooldown = false;
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            imageCooldown.fillAmount = cooldown / iniCooldown;
        }
    }*/
}
