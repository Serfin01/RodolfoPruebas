using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Damaged(int damage)
    {
        health -= damage;
        FindObjectOfType<AudioManager>().Play("enemyHitted");

    }
}
