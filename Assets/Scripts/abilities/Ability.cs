using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] string abilityName = "New Ability Name";
    [SerializeField] float abilityCooldown = 1f;
    [SerializeField] KeyCode abilityKey;

    public string AbilityName { get { return abilityName; } }

    public float AbilityCooldown { get { return abilityCooldown; } }


    //public abstract void Cast();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
