using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Laser : BaseAbility
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject socket;
    bool canShoot;
    float shotDuration = 2;

    [SerializeField] ParticleSystem jamau1;
    [SerializeField] ParticleSystem jamau2;
    public LineRenderer linea;

    rayoLaser rayo;

    bool activo = true;

    private void Start()
    {
        socket = GameObject.Find("Socket");
        //laser = GameObject.FindGameObjectWithTag("Laser");
        //laser = Resources.Load<GameObject>("Laser");
        laser = GameObject.Find("Laser");
        iniCooldown = 3;
        //laser.SetActive(false);
        linea = laser.GetComponentInChildren<LineRenderer>();
        jamau1 = GameObject.Find("Beam").GetComponent<ParticleSystem>();
        jamau2 = GameObject.Find("paaarticulas").GetComponent<ParticleSystem>();
        rayo = laser.GetComponentInChildren<rayoLaser>();
    }

    private void Update()
    {
        if (isCooldown)
        {
            ApplyCooldown();
        }
        if (!activo)
        {
            if (canShoot == true)
            {
                //laser.SetActive(true);
                linea.enabled = true;
                jamau1.Play();
                jamau2.Play();
                activo = true;
                rayo.activo(activo);
            }
        }
        if (canShoot == false)
        {
            //laser.SetActive(false);
            linea.enabled = false;
            jamau1.Stop();
            jamau2.Stop();
            activo = false;
            rayo.activo(activo);
        }
    }

    public override void UseSpell()
    {
        //rayo.activo(activo);
        base.UseSpell();
        Debug.Log("Laser");
        if (isCooldown)
        {
            //StartCoroutine(Shot());
        }
        else
        {
            StartCoroutine(Shot());
            isCooldown = true;
        }
        /*

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

    private IEnumerator Shot()
    {
        canShoot = true;
        cooldown = iniCooldown;
        Debug.Log("on");
        yield return new WaitForSeconds(shotDuration);
        canShoot = false;
        //overlayCooldown.GetComponent<Image>().fillAmount = 0.5;
        Debug.Log("off");
    }
    /*
    [SerializeField] GameObject rayo;

    private bool canShoot;
    [SerializeField] float shotDuration = 2;

    private bool isCooldown = false;
    private float cooldown;
    [SerializeField] float iniCooldown = 2;
    [SerializeField] Image imageCooldown;

    PlayerInput input;

    void Start()
    {
        //rayo = GameObject.Find("Laser");
        rayo = GameObject.FindGameObjectWithTag("Laser");
        //rayo.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    private void Awake()
    {
        input = new PlayerInput();
        //input.CharacterControls.Ability1.performed += UseSpell;
    }

    void Update()
    {
        
        if (Input.GetKeyDown("4"))
        {
            UseSpell();
        }
        
        if (canShoot == true)
        {
            rayo.SetActive(true);
        }
        if (canShoot == false)
        {
            rayo.SetActive(false);
        }

        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldown -= Time.deltaTime;

        if(cooldown < 0.0f)
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
        if (isCooldown)
        {
            //StartCoroutine(Shot());
        }
        else
        {
            StartCoroutine(Shot());
            //isCooldown = true;
            cooldown = iniCooldown;
        }
    }

    private IEnumerator Shot()
    {
        canShoot = true;
        Debug.Log("on");
        yield return new WaitForSeconds(shotDuration);
        canShoot = false;
        isCooldown = true;
        //overlayCooldown.GetComponent<Image>().fillAmount = 0.5;
        Debug.Log("off");
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
