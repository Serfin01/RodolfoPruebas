using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InviHijo : BaseAbility
{
    PlayerInput input;

    private bool invi = false;
    public bool canBeDamaged = true;
    public GameObject modelo;

    [SerializeField] float inviDuration = 2;

    void Start()
    {
        modelo = GameObject.Find("RodolfoBasicAnim");
        imageCooldown.fillAmount = 0.0f;
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
        Debug.Log("off");
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
}
