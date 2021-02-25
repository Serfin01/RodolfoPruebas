using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell : ScriptableObject
{
    [Header("About this Spell")]
    public string spellName = "New Spell";
    public string spellDescription = "Spell Description";
    public Texture2D spellSprite;

    [Header("Spell Stats")]
    public float currentCooldown = 0;
    public float maxCooldown;

    public void PutOnCooldown()
    {
        CooldownManager.instance.StartCooldown(this);
    }
    public bool IsSpellReady()
    {
        return currentCooldown <= 0;
    }
}
