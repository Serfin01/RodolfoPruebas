using System.Collections;
using UnityEngine;

public class PruebaVel : MonoBehaviour
{
    public float belbel;

    void Update()
    {
        transform.Translate(belbel * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, belbel * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
