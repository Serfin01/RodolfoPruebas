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
        puenteEnter.SetActive(true); ;
    }
}
