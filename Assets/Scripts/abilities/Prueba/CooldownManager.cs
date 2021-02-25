using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    public static CooldownManager instance;

    private List<Spell> spellsOnCooldown = new List<Spell>();
    //https://www.youtube.com/watch?v=LylU2h438hQ&ab_channel=DapperDino
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        for (int i = 0; i < spellsOnCooldown.Count; i++)
        {
            spellsOnCooldown[i].currentCooldown -= Time.deltaTime;

            if(spellsOnCooldown[i].currentCooldown <= 0)
            {
                spellsOnCooldown[i].currentCooldown = 0;
                spellsOnCooldown.Remove(spellsOnCooldown[i]);
            }
        }
    }

    public void StartCooldown(Spell spell)
    {
        if (!spellsOnCooldown.Contains(spell))
        {
            spell.currentCooldown = spell.maxCooldown;
            spellsOnCooldown.Add(spell);
        }
    }
}
