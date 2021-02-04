using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scrolls : MonoBehaviour
{
    /*
    [SerializeField] GameObject[] typeScrolls;
    //private int random;

    private int currenIndex = 0;
    // Start is called before the first frame update

    private Type myAbility;

    enum Abilities
    {
        A1, A2, A3, None
    }

    private Abilities currentAbility = Abilities.None;
    
    private Dictionary<int, Type> abilities = new Dictionary<int, Type>()
    {
        //{1, typeof(A1) },
        //{2, typeof(A2) },
        //{3, typeof(A3) },

    };

    void Start()
    {
        int newIndex = UnityEngine.Random.Range(0, typeScrolls.Length);
        typeScrolls[currenIndex].SetActive(false);
        currenIndex = newIndex;
        typeScrolls[currenIndex].SetActive(true);

        int random = UnityEngine.Random.Range(0, abilities.Count);
        myAbility = abilities[random];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.AddComponent(myAbility);
        }
    }

    
    /*
    // Update is called once per frame
    void Update()
    {
        //random = Random.Range(0, typeScrolls.Length);
        int newIndex = Random.Range(0, typeScrolls.Length);
        typeScrolls[currenIndex].SetActive(false);
        currenIndex = newIndex;
        typeScrolls[currenIndex].SetActive(true);
        //Instantiate(typeScrolls[random], transform.position, transform.rotation);
    }
    */
}
