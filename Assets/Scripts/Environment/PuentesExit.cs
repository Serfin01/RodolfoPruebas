using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuentesExit : MonoBehaviour
{
    [SerializeField] GameObject puenteExit;
    [SerializeField] GameObject[] enemies;
    //int starterHealth;

    private void OnTriggerEnter(Collider other)
    {
        puenteExit.SetActive(false);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
        }

    }
    /*
    public void Pergaminos(int vidaRodolfo)
    {
        starterHealth = vidaRodolfo;
    }
    */
}
