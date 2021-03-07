using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scrolls : MonoBehaviour
{
    PlayerAbilities playerTr;
    public int currentAbility;
    private Dictionary<int, Type> abilitiesLibrary = new Dictionary<int, Type>()
    {
        {0, typeof(CreateShield)},
        {1, typeof(Laser) },
        {2, typeof(Invisibility) },
        {3, typeof(AttackSpeed) },
    };

    void OnEnable()
    {
        currentAbility = UnityEngine.Random.Range(0, abilitiesLibrary.Count);
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilities>();
    }

    public void AddScroll(GameObject player)
    {
        Type scrollType = abilitiesLibrary[currentAbility];
        
        BaseAbility abiliti = (BaseAbility)player.AddComponent(scrollType);

        player.GetComponent<PlayerAbilities>().AddAbilityImage(currentAbility, abiliti);

        Disable();
            /*
            PlayerAbilities playerAbilities = GetComponent<PlayerAbilities>();
            int slot = playerAbilities.AddAbilityImage(currentAbility);

            CreateShield createShield = GetComponent<CreateShield>();
            Laser laser = GetComponent<Laser>();
            Invisibility invisibility = GetComponent<Invisibility>();
            AttackSpeed attackSpeed = GetComponent<AttackSpeed>();
            switch (currentAbility)
            {
                case 1:
                    createShield.NotifyAddedAtSlot(slot);
                    break;
                case 2:
                    laser.NotifyAddedAtSlot(slot);
                    break;
                case 3:
                    invisibility.NotifyAddedAtSlot(slot);
                    break;
                case 4:
                    attackSpeed.NotifyAddedAtSlot(slot);
                    break;
            }
            */
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTr.ScrollRange(true, this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTr.ScrollRange(false, null);
        }
    }
    //rayo.NotifyAddedAtSlot(slot);
}
