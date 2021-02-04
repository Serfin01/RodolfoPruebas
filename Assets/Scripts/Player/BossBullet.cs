using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] int damage;
    //[SerializeField] GameObject charco;
    //private int countCharco;
    [SerializeField] float bulletForce;


    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damaged(damage);
            //Debug.Log("damage");

            /*
            countCharco = countCharco + 1;
            if(countCharco >= 3)
            {
                Instantiate(charco);
                Debug.Log("charco");
                countCharco = 0;
            }
            */
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit"))
        {
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Shield"))
        {
            bulletForce = bulletForce / 10;
            Debug.Log("dentro");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            bulletForce = bulletForce * 10;
            Debug.Log("fuera");
        }
    }
}
