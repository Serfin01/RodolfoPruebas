using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaaaaaaaaaaaa : MonoBehaviour
{
    private void Update()
    {
        FindSpawn();
    }
    void FindSpawn()
    {
        float distanceToClosestSpawn = Mathf.Infinity;
        FollowEnemy closestEnemy = null;
        FollowEnemy[] allEnemies = GameObject.FindObjectsOfType<FollowEnemy>();

        foreach (FollowEnemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distanceToClosestSpawn)
            {
                distanceToClosestSpawn = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
    }
}
