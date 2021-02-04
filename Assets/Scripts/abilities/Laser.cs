using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject rayo;

    private bool canShoot;
    [SerializeField] float shotDuration;

    private bool isCooldown = false;
    private float cooldown;
    [SerializeField] float iniCooldown;
    [SerializeField] Image imageCooldown;

    void Start()
    {
        rayo.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
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

    public void UseSpell()
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
}
