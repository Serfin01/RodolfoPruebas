using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Invisibility : MonoBehaviour
{
    PlayerInput input;

    private float activationTime = 0;
    private bool invi = false;
    public bool canBeDamaged = true;
    public GameObject modelo;

    private bool isCooldown = false;
    private float cooldown;
    [SerializeField] float iniCooldown;
    [SerializeField] Image imageCooldown;
    [SerializeField] float inviDuration;

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Invisibility.performed += UseSpell;
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
        imageCooldown.fillAmount = 0.0f;
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
    void InviCooldown(InputAction.CallbackContext obj)
    {
        activationTime = 0;
        invi = true;
    }
    */

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

    public void UseSpell(InputAction.CallbackContext obj)
    {
        if (!isCooldown)
        {
            StartCoroutine(InviOn());
            cooldown = iniCooldown;
            invi = true;
        }
    }

}
