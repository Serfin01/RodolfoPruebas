using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rb : MonoBehaviour
{
    private Rigidbody rbody;
    private Vector3 inputVector;
    [SerializeField] float velocity;
    [SerializeField] float gravity;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * velocity, gravity, Input.GetAxisRaw("Vertical") * velocity);
    }

    private void FixedUpdate()
    {
        rbody.velocity = inputVector;
    }
}
