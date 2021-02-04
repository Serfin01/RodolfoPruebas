using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlace : MonoBehaviour
{
    public Rigidbody rb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            rb.AddForce(Vector3.back * 100, ForceMode.VelocityChange);
        }
    }
}
