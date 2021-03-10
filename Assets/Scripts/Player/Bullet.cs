using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletForce;
    [SerializeField] int damage;
    //[SerializeField] GameObject charco;
    //private int countCharco;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, bulletForce * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Damaged(damage);
            GameObject.Destroy(gameObject);
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
        if (other.CompareTag("Limit"))
        {
            Destroy(this.gameObject);
        }
    }
}
