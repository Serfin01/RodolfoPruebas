using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuentesEnter : MonoBehaviour
{
    [SerializeField] GameObject puenteEnter;
    bool roomClear = false;
    [SerializeField] int enemiesNum;

    public void Clear(int currentEnemiesNum)
    {
        if (enemiesNum == currentEnemiesNum)
        {
            roomClear = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //puenteEnter.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (enemiesNum == 0)
        {
            puenteEnter.SetActive(true);
            Debug.Log("abrete");
        }
        if(other.CompareTag("Enemy"))
        {
            enemiesNum -= 1;
        }
    }
}
