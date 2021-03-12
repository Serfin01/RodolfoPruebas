using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hijo2 : Padre
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseNumber();
        }
    }
}
