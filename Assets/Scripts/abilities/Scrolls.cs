using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scrolls : MonoBehaviour
{
    PlayerInput input;

    bool dentro = false;
    GameObject playerTr;
    public int currentAbility;
    private Dictionary<int, Type> abilitiesLibrary = new Dictionary<int, Type>()
    {
        {1, typeof(Shield)},
        {2, typeof(Laser) },
        {3, typeof(Invisibility) },
        {4, typeof(AttackSpeed) },
    };

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.GetAbility.performed += ctx => AddScroll(playerTr);
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
        currentAbility = UnityEngine.Random.Range(0, abilitiesLibrary.Count+1);
        playerTr = GameObject.Find("Player");
    }

    public void AddScroll(GameObject player)
    {
        if (dentro)
        {
            Type scrollType = abilitiesLibrary[currentAbility];

            player.AddComponent(scrollType);

            Destroy();
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
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentro = false;
        }
    }
    //rayo.NotifyAddedAtSlot(slot);
}
