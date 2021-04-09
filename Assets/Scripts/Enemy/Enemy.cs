using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health = 50;
    // Start is called before the first frame update
    private bool died = false;

    [SerializeField] GameObject puente;
    public void Damaged(int damage)
    {
        health -= damage;
        FindObjectOfType<AudioManager>().Play("enemyHitted");
        if (!died)
        {
            if (health <= 0)
            {
                //Die();
                puente.GetComponent<PuentesEnter>().Clear(+1);
                StartCoroutine("Die");
                died = true;
            }
        }
    }
}
