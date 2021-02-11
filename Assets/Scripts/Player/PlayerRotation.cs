using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] Transform planePosition;

    public int sensivility = 10;
    void Update()
    {
        Plane plane = new Plane(Vector3.up, planePosition.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0.0f;

        if(plane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.z = transform.rotation.z;
            targetRotation.x = transform.rotation.x;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, sensivility * Time.deltaTime);
        }
    }
}
