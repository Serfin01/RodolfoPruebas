﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Invisibility : BaseAbility
{
    private float activationTime = 0;
    private bool invi = false;
    public bool canBeDamaged = true;
    public GameObject modelo;
    float inviDuration = 2;

    void Start()
    {
        base.UseSpell();
        modelo = GameObject.Find("RodolfoBasicAnim");
        iniCooldown = 3;
    }

    public override void UseSpell()
    {
        Debug.Log("Invi");
        if (!isCooldown)
        {
            StartCoroutine(InviOn());
            cooldown = iniCooldown;
            invi = true;
        }
    }

    void Update()
    {
        activationTime += Time.deltaTime;
        /*
        if (invi == true && activationTime >= 3)
        {
            invi = false;
            Debug.Log("me ves");
            canBeDamaged = true;
            modelo.SetActive(true);
        }
        */
        /*
        if (invi == true)
        {
            InviOn();
        }
        */
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }
    /*
    void InviOn()
    {
        //this.GetComponent<Collider>().enabled = false;
        Debug.Log("no me ves");
        canBeDamaged = false;
        modelo.SetActive(false);
    }
    */
    private IEnumerator InviOn()
    {
        canBeDamaged = false;
        modelo.SetActive(false);
        Debug.Log("on");
        yield return new WaitForSeconds(inviDuration);
        canBeDamaged = true;
        modelo.SetActive(true);
        isCooldown = true;
        //overlayCooldown.GetComponent<Image>().fillAmount = 0.5;
        Debug.Log("off");
    }
    /*
    PlayerInput input;

    private float activationTime = 0;
    private bool invi = false;
    public bool canBeDamaged = true;
    public GameObject modelo;

    private bool isCooldown = false;
    private float cooldown;
    [SerializeField] float iniCooldown = 2;
    [SerializeField] Image imageCooldown;
    [SerializeField] float inviDuration = 2;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    void Start()
    {
        modelo = GameObject.Find("RodolfoBasicAnim");
        imageCooldown.fillAmount = 0.0f;
    }

    void Update()
    {
        activationTime += Time.deltaTime;
        
        if (invi == true && activationTime >= 3)
        {
            invi = false;
            Debug.Log("me ves");
            canBeDamaged = true;
            modelo.SetActive(true);
        }
        if (invi == true)
        {
            InviOn();
        }
        
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    
    void InviCooldown(InputAction.CallbackContext obj)
    {
        activationTime = 0;
        invi = true;
    }
    

    
    void InviOn()
    {
        //this.GetComponent<Collider>().enabled = false;
        Debug.Log("no me ves");
        canBeDamaged = false;
        modelo.SetActive(false);
    }
    

    private IEnumerator InviOn()
    {
        canBeDamaged = false;
        modelo.SetActive(false);
        Debug.Log("on");
        yield return new WaitForSeconds(inviDuration);
        canBeDamaged = true;
        modelo.SetActive(true);
        isCooldown = true;
        //overlayCooldown.GetComponent<Image>().fillAmount = 0.5;
        Debug.Log("off");
    }

    void ApplyCooldown()
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

    protected virtual void UseSpell()
    {
        if (!isCooldown)
        {
            StartCoroutine(InviOn());
            cooldown = iniCooldown;
            invi = true;
        }
    }

    public void NotifyAddedAtSlot(int slot)
    {
        enabled = true;
        //input = new PlayerInput();
        switch (slot)
        {
            case 0:
                input.CharacterControls.Ability1.performed += ctx => UseSpell();
                break;
            case 1:
                input.CharacterControls.Ability2.performed += ctx => UseSpell();
                break;
            case 2:
                input.CharacterControls.Ability3.performed += ctx => UseSpell();
                break;
            case 3:
                input.CharacterControls.Ability4.performed += ctx => UseSpell();
                break;
        }
    }
    */
}
