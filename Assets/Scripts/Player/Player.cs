using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth;

    public HealthBar healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {
        //currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    public virtual void Damaged(int damage)
    {
        currentHealth -= damage;

        //healthBar.SetHealth(currentHealth);
    }

}
