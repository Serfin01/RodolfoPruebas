using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuentesExit : MonoBehaviour
{
    [SerializeField] GameObject puenteExit;
    private void OnTriggerEnter(Collider other)
    {
        puenteExit.SetActive(false);
    }
}
