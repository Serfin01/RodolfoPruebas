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

    Scrolls closeScroll;

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
        //gameObject.GetComponent<Laser>().enabled = false;
        //gameObject.GetComponent<CreateShield>().enabled = false;
        //gameObject.GetComponent<Invisibility>().enabled = false;
        //gameObject.GetComponent<AttackSpeed>().enabled = false;
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
        if (dentro)
        {
            if(closeScroll != null)
            {
                closeScroll.AddScroll(gameObject);
            }
        }
        /*
        //Debug.Log("empezando");
        if (dentro)
        {
            
            Debug.Log("empezando");
            if (AbilitiesNum < 4)
            {
                ability = Random.Range(1, 5);
                Debug.Log(ability);
                switch (ability)
                {
                    case 5:

                        break;
                    case 4:
                        {
                            AttackSpeed attSpeed = GetComponent<AttackSpeed>();
                            if (attSpeed.enabled == false)
                            {
                                AbilitiesNum++;
                                int slot = AddAbilityImage(AbilityImages.AttackSpeed);
                                attSpeed.NotifyAddedAtSlot(slot);
                                Debug.Log("obtener speed");
                                dentro = false;
                            }
                            else
                            {
                                Debug.Log("repetir speed");
                                GetAbility();
                            }
                        }
                        break;
                    case 3:
                        {
                            Invisibility invi = GetComponent<Invisibility>();
                            if (invi.enabled == false)
                            {
                                AbilitiesNum++;
                                int slot = AddAbilityImage(AbilityImages.Invisibility);
                                invi.NotifyAddedAtSlot(slot);
                                Debug.Log("obtener invi");
                                dentro = false;
                            }
                            else
                            {
                                Debug.Log("repetir invi");
                                GetAbility();
                            }
                        }
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
        */
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

    public int AddAbilityImage(int currentAbility)
    {
        int espacioSeleccionado = -1;

        for (int i = 0; (i < espacios.Length) && (espacioSeleccionado == -1); i++)
        {
            if (!espacios[i].isfull)
            {
                espacioSeleccionado = i;
                espacios[i].abilityImage.sprite = abilitySprite[currentAbility];
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
