using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    Plane plane;
    Ray ray;

    float hitDist;

    [SerializeField]float bulletForce;
    Vector3 targetPoint;
    bool move = true;

    void Start()
    {
        plane = new Plane(Vector3.up, transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        hitDist = 0.0f;
    }

    void Update()
    {
        if (plane.Raycast(ray, out hitDist))
        {
            targetPoint = ray.GetPoint(hitDist);
            //transform.Translate(targetPoint.x,targetPoint.y, bulletForce * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, bulletForce * Time.deltaTime);
        }

        if (transform.position == targetPoint)
        {
            move = false;
            Debug.Log("falso");
        }

        if (!move)
        {
            Explosion();
        }
    }

    void Explosion()
    {

    }
}
