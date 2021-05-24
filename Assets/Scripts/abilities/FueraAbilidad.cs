using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FueraAbilidad : MonoBehaviour
{
    public UnityEvent onPlayerExit;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerExit?.Invoke();
        }
    }
}
