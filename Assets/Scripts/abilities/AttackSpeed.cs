using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AttackSpeed : MonoBehaviour
{
    PlayerInput input;

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

    public void UseSpell()
    {
        Mano mano = GetComponentInChildren<Mano>();
        mano.cadencia = mano.cadencia / 2;
    }
}
