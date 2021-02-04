using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] float duration;
    
    float iniDuration;

    void Start()
    {
        iniDuration = duration;
    }

    void Update()
    {
        duration -= Time.deltaTime;

        if(duration <= 0)
        {
            DestroyShield();
        }
    }
    
    void DestroyShield()
    {
        Destroy(gameObject);
    }
}
