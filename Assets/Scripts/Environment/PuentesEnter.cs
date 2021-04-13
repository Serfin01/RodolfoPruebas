using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuentesEnter : MonoBehaviour
{
    [SerializeField] GameObject [] puenteEnter;


    private void Update()
    {
        if (transform.childCount == 0 && puenteEnter.Length == 1)
        {
            puenteEnter[0].SetActive(true);
        }
        if (transform.childCount == 0 && puenteEnter.Length == 2)
        {
            puenteEnter[2].SetActive(true);
        }
        if (transform.childCount == 0 && puenteEnter.Length == 3)
        {
            puenteEnter[3].SetActive(true);
        }
    }
}
