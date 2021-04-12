using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuentesEnter : MonoBehaviour
{
    [SerializeField] GameObject puenteEnter;
    bool roomClear = false;

    private int enemiesNum;
    [SerializeField] int enemiesClear;

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
        //enemiesNum = listOfEnemies.Count;
        for (int nullSearch = 0; listOfEnemies.Count < listOfEnemies.Count; nullSearch++)
        {
            if(listOfEnemies[nullSearch] == null)
            {
                Debug.Log("aaaaaaa");
                enemiesNum++;
            }
            else
            {
                Debug.Log(nullSearch);
                return;
            }
        }
        //puenteEnter.SetActive(true);
        if (enemiesNum == enemiesClear)
        {
            puenteEnter.SetActive(true);
        }
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
