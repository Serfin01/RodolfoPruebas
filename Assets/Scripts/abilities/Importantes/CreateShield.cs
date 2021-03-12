using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CreateShield : BaseAbility
{
    [SerializeField] GameObject shield;
    
    Ray myRay;
    RaycastHit hit;

    private void Start()
    {
        shield = Resources.Load<GameObject>("Escudo");
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
        Debug.Log("Shield");
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hit))
        {
            if (isCooldown)
            {
                //StartCoroutine(Shot());
            }
            else
            {
                InstantiateShield();
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

    void InstantiateShield()
    {
        Instantiate(shield, hit.point, Quaternion.identity);
        cooldown = iniCooldown;
    }
    /*
    [SerializeField] GameObject shield;

    //[SerializeField] Image overlayCooldown;
    //[SerializeField] GameObject bola;

    //private bool canShoot;
    

    Ray myRay;
    RaycastHit hit;

    //[SerializeField] float cooldown = 1;

    private bool isCooldown = false;
    private float cooldown;
    [SerializeField] float iniCooldown;
    [SerializeField] Image imageCooldown;
    //float iniCooldown;

    PlayerInput input;

    void Start()
    {
        //shield.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    private void Awake()
    {
        input = new PlayerInput();
        //input.CharacterControls.Ability1.performed += UseSpell;
    }

    void Update()
    {
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (isCooldown)
        {
            ApplyCooldown();
        }

        if (Physics.Raycast(myRay, out hit))
        {
            /*
            if (Input.GetKeyDown("3"))
            {
                UseSpell();
            }
            
        }
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
        if (Physics.Raycast(myRay, out hit))
        {
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
        }
        
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
        
    }

    void InstantiateShield()
    {
        Instantiate(shield, hit.point, Quaternion.identity);
        cooldown = iniCooldown;
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

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }
*/
}
