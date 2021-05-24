using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Espacios
{
    public bool isfull = false;
    public Image abilityImage;
    public BaseAbility slotAbility;
    public Image cooldownImage;
    public bool abilityUsed = false;
}

public class PlayerAbilities : MonoBehaviour
{
    PlayerInput input;
    public int AbilitiesNum;

    public bool dentro = false;

    public Espacios[] espacios = new Espacios[4];

    [SerializeField] Sprite[] abilitySprite = new Sprite[5];

    Scrolls closeScroll;

    public Spell abilityTest;

    int numberKey;

    public enum AbilityImages
    {
        Shield,
        Rayo,
        Invisibility,
        AttackSpeed,
    };

    private void Awake()
    {
        input = new PlayerInput();
        //input.CharacterControls.Invisibility.performed += InviCooldown;
        input.CharacterControls.GetAbility.performed += ctx => GetAbility();
        input.CharacterControls.Ability1.performed += ctx => { numberKey = 0; CastSpell(); };
        input.CharacterControls.Ability2.performed += ctx => { numberKey = 1; CastSpell(); };
        input.CharacterControls.Ability3.performed += ctx => { numberKey = 2; CastSpell(); };
        input.CharacterControls.Ability4.performed += ctx => { numberKey = 3; CastSpell(); };
    }

    void CastSpell()
    {
        if (espacios[numberKey].slotAbility != null)
        {
            espacios[numberKey].slotAbility.UseSpell();
            espacios[numberKey].abilityUsed = true;
        }
        else
        {
            //sonidito de aqui no hay hab
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

    void Start()
    {
        for (int i = 0; i < espacios.Length; i++)
        {
            espacios[i].abilityImage.sprite = null;
        }
    }
    void GetAbility()
    {
        if (dentro)
        {
            if(closeScroll != null)
            {
                closeScroll.AddScroll(gameObject);
                dentro = false;
            }
        }
    }

    public void ScrollRange(bool isInside, Scrolls pergamino)
    {
        dentro = isInside;
        closeScroll = pergamino;
    }

    public void AddAbilityImage(int currentAbility, BaseAbility baseAbility)
    {
        if (AbilitiesNum < 4)
        {
            for (int i = 0; (i < espacios.Length); i++)
            {
                if (!espacios[i].isfull)
                {
                    espacios[i].slotAbility = baseAbility;
                    espacios[i].slotAbility.SetImageCooldown(espacios[i].cooldownImage);
                    espacios[i].abilityImage.sprite = abilitySprite[currentAbility];
                    espacios[i].isfull = true;
                    return;
                }
            }
        }
        else
        {
            //tamo lleno bro
        }
    }
    

    public void RemoveAbilityImage()
    {
        for (int i = 0; i < espacios.Length; i++)
        {
            if (espacios[i].isfull && espacios[i].abilityUsed)
            {
                Destroy(espacios[i].slotAbility);
                espacios[i].slotAbility = null;
                espacios[i].abilityImage.sprite = null;
                espacios[i].isfull = false;
                espacios[i].abilityUsed = false;
            }
        }
    }
}
