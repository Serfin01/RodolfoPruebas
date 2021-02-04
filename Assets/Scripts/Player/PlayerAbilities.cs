using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilities : MonoBehaviour
{
    PlayerInput input;

    //public GameObject modelo;
    
    private float activationTime;
    private bool invi;
    //public bool canBeDamaged = true;
    
    bool stance = true;
    int ability;
    bool IsSkillUnlocked = false;

    [SerializeField] GameObject rayo;

    public int AbilitiesNum;
    /*
    public Mano mano;
    */
    [Header("Inventario")]
    bool ability1 = false;
    bool ability2 = false;
    bool ability3 = false;
    bool ability4 = false;

    bool dentro = false;

    private void Awake()
    {
        input = new PlayerInput();
        //input.CharacterControls.Invisibility.performed += InviCooldown;
        input.CharacterControls.GetAbility.performed += GetAbility;
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
        rayo.SetActive(false);
        //invi = false;
        //activationTime = 0;
        gameObject.GetComponent<Laser>().enabled = false;
        gameObject.GetComponent<CreateShield>().enabled = false;
    }

    void Update()
    {
        /*
        activationTime += Time.deltaTime;
        
        if(invi == true && activationTime >= 3)
        {
            invi = false;
            //this.GetComponent<Collider>().enabled = true;
            Debug.Log("me ves");
            canBeDamaged = true;
            modelo.SetActive(true);
        }
        if(invi == true)
        {
            Invisibility();
        }
        */
    }
    /*
    void InviCooldown(InputAction.CallbackContext obj)
    {
        activationTime = 0;
        invi = true;
    }
    
    void Invisibility()
    {
        //this.GetComponent<Collider>().enabled = false;
        Debug.Log("no me ves");
        canBeDamaged = false;
        modelo.SetActive(false);
    }
    */
    void GetAbility(InputAction.CallbackContext obj)
    {
        if (dentro)
        {
            dentro = false;
            if (AbilitiesNum < 4)
            {
                ability = Random.Range(1, 3);

                switch (ability)
                {
                    case 5:

                        break;
                    case 4:
                        /*
                        mano.cadencia = mano.cadencia / 2;
                        Debug.Log("3");
                        */
                        break;
                    case 3:
                        /*
                        if (gameObject.GetComponent<Invisibility>().enabled == false)
                        {
                            gameObject.GetComponent<Invisibility>().enabled = true;
                            AbilitiesNum++;
                        }
                        else
                        {
                            input.CharacterControls.GetAbility.performed += GetAbility;
                        }
                        */
                        break;
                    case 2:
                        if (gameObject.GetComponent<CreateShield>().enabled == false)
                        {
                            gameObject.GetComponent<CreateShield>().enabled = true;
                            AbilitiesNum++;
                        }
                        else
                        {
                            input.CharacterControls.GetAbility.performed += GetAbility;
                        }
                        break;
                    case 1:
                        if (gameObject.GetComponent<Laser>().enabled == false)
                        {
                            gameObject.GetComponent<Laser>().enabled = true;
                            AbilitiesNum++;
                        }
                        else
                        {
                            input.CharacterControls.GetAbility.performed += GetAbility;
                        }
                        Debug.Log("1");
                        break;
                    default:
                        input.CharacterControls.GetAbility.performed += GetAbility;
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pergamino"))
        {
            dentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pergamino"))
        {
            dentro = false;
        }
    }

    /*
    private List<SkillType> unlockedSkillTypeList;

    private void UnlockSkill(SkillType skillType)
    {
        if (!IsSkillUnlocked(skillType))
        {
            unlockedSkillTypeList.Add(skillType);
        }
    }
    */
}
