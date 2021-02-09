using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[System.Serializable]
public class Espacios
{
    public bool isfull = false;
    public Image abilityImage;

}

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

    [SerializeField] Espacios[] espacios = new Espacios[4];

    [SerializeField] Sprite[] abilitySprite = new Sprite[4];

    enum AbilityImages
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
        for (int i = 0; i < espacios.Length; i++)
        {
            espacios[i].abilityImage.sprite = null;
        }
    }

    void Update()
    {
        //Debug.Log(dentro);
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
    void GetAbility()
    {
        //Debug.Log("empezando");
        if (dentro)
        {
            
            Debug.Log("empezando");
            if (AbilitiesNum < 4)
            {
                ability = Random.Range(1, 3);
                Debug.Log(ability);
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
                        {
                            CreateShield createShield = GetComponent<CreateShield>();
                            if (createShield.enabled == false)
                            {
                                AbilitiesNum++;
                                int slot = AddAbilityImage(AbilityImages.Shield);
                                createShield.NotifyAddedAtSlot(slot);
                                //createShield.enabled = true;
                                Debug.Log("obtener escudo");
                                dentro = false;
                            }
                            else
                            {
                                Debug.Log("repetir escudo");
                                GetAbility();
                            }
                        }
                        break;
                    case 1:
                        {
                            Laser rayo = GetComponent<Laser>();
                            if (rayo.enabled == false)
                            {
                                AbilitiesNum++;
                                int slot = AddAbilityImage(AbilityImages.Rayo);
                                rayo.NotifyAddedAtSlot(slot);
                                Debug.Log("obtener rayo");
                                dentro = false;
                            }
                            else
                            {
                                Debug.Log("repetir rayo");
                                GetAbility();
                            }
                        }
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

    int AddAbilityImage(AbilityImages abilityImage)
    {
        int espacioSeleccionado = -1;

        for (int i = 0; (i < espacios.Length) && (espacioSeleccionado == -1); i++)
        {
            if (!espacios[i].isfull)
            {
                espacioSeleccionado = i;
                espacios[i].abilityImage.sprite = abilitySprite[(int)abilityImage];
                espacios[i].isfull = true;
            }
        }

        if (AbilitiesNum >= 4)
        {
            //tamo lleno bro
        }

        return espacioSeleccionado;
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
