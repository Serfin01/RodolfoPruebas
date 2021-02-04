using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefabDisparo;
    [SerializeField] int cuantas;
    [SerializeField] float anguloDeApertura;
    [SerializeField] float distanciaInicial;
    [SerializeField] bool testSpawnea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testSpawnea)
        {
            testSpawnea = false;
            Spawnea();
        }
    }

    public void Spawnea()
    {
        for (int i = 0; i < cuantas; i++)
        {
            float currentRotation = (-anguloDeApertura / 2) + (anguloDeApertura / cuantas * i);

            Quaternion newRotation = Quaternion.AngleAxis(currentRotation, Vector3.up);
            Vector3 newForward = newRotation * Vector3.forward;

            Vector3 posicionSpawn = transform.position + (transform.TransformDirection(newForward) * distanciaInicial);
            GameObject newBulletGO = Instantiate(prefabDisparo, posicionSpawn, transform.rotation * newRotation);
        }

    }
}
