﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuentesEnter : MonoBehaviour
{
    [SerializeField] GameObject [] puenteEnter;
    [SerializeField] GameObject [] pergamino;

    bool count = false;

    private void Update()
    {
        if (transform.childCount == 0 && puenteEnter.Length == 1)
        {
            puenteEnter[0].SetActive(true);
            GetComponent<PuentesEnter>().enabled = false;
        }
        if (transform.childCount == 0 && puenteEnter.Length == 2)
        {
            puenteEnter[1].SetActive(true);
            puenteEnter[0].SetActive(true);
        }
        if (transform.childCount == 0 && puenteEnter.Length == 3)
        {
            puenteEnter[2].SetActive(true);
            puenteEnter[0].SetActive(true);
            puenteEnter[1].SetActive(true);
        }
        if (!count)
        {
            if (transform.childCount == 0 && puenteEnter.Length == 1)
            {
                pergamino[0].SetActive(true);
                count = true;
            }
            if (transform.childCount == 0 && puenteEnter.Length == 2)
            {
                pergamino[1].SetActive(true);
                pergamino[0].SetActive(true);
                count = true;
            }
            if (transform.childCount == 0 && puenteEnter.Length == 3)
            {
                pergamino[2].SetActive(true);
                pergamino[1].SetActive(true);
                pergamino[0].SetActive(true);
                count = true;
            }
        }
    }
}
