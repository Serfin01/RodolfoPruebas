using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletForce;
    [SerializeField] int damage;
    //[SerializeField] GameObject charco;
    //private int countCharco;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bulletForce * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Damaged(damage);
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
