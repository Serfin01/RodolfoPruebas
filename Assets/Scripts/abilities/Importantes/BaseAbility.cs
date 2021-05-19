using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public abstract class BaseAbility : MonoBehaviour
{
    protected bool isCooldown = false;
    protected float cooldown;
    [SerializeField] protected float iniCooldown;
    [SerializeField] protected Image imageCooldown;

    bool usedSpell = false;
    GameObject player;
    PlayerAbilities playerAb;
    public int espacio = 0;

    private void Start()
    {
        playerAb = GameObject.Find("Player").GetComponent<PlayerAbilities>();
    }
    protected virtual void ApplyCooldown()
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
    }

    public virtual void UseSpell()
    {
        usedSpell = true;
        //Espacio();
    }

    void Espacio()
    {
        for (int i = 0; i < playerAb.espacios.Length; i++)
        {
            if (playerAb.espacios[i].isfull)
            {
                espacio++;
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enter"))
        {
            if (usedSpell == true)
            {
                Debug.Log("fuera");
                playerAb.RemoveAbilityImage(espacio);
            }
        }
    }

    public void SetImageCooldown(Image jose)
    {
        imageCooldown = jose;
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
