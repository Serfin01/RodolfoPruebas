using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] GameObject shadow;

    Ray myRay;
    RaycastHit hit;

    public LayerMask _layerMask;

    void Update()
    {
        /*
        myRay = (transform.position, -Vector3.up);
        if (Physics.Raycast(myRay, out hit))
        {
            
        }
        */
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100f, _layerMask))
        {
            shadow.SetActive(true);
        }
        else
        {
            shadow.SetActive(false);
        }
    }
}
