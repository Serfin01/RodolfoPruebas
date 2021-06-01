using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDescription : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite []habilities;
    //[SerializeField] GameObject pergamino;
    [SerializeField] Scrolls scrolls;

    void Start()
    {
        spriteRenderer.sprite = habilities[scrolls.currentAbility];
    }
}
