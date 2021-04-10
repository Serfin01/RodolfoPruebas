using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuentesEnter : MonoBehaviour
{
    [SerializeField] GameObject puenteEnter;
    bool roomClear = false;
    [SerializeField] int enemiesNum;

    [SerializeField]List<GameObject> listOfEnemies = new List<GameObject>();

    /*
    public void Clear(int currentEnemiesNum)
    {
        if (enemiesNum == currentEnemiesNum)
        {
            roomClear = true;
        }
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        //puenteEnter.SetActive(true);
        if (listOfEnemies.Count == 0)
        {
            puenteEnter.SetActive(true);
        }
        Debug.Log(listOfEnemies.Count);
    }
    /*
    public void KilledOpponent(GameObject opponent)
    {
        if (listOfEnemies.Contains(opponent))
        {
            listOfEnemies.Remove(opponent);
        }

        print(listOfEnemies.Count);
    }
    */
    private void OnTriggerExit(Collider other)
    {
        /*
        if (enemiesNum == 0)
        {
            puenteEnter.SetActive(true);
            Debug.Log("abrete");
        }
        if(other.CompareTag("Enemy"))
        {
            enemiesNum -= 1;
        }
        */
    }
}
