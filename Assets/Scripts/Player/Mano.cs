using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mano : MonoBehaviour
{
    PlayerInput input;

    [SerializeField] GameObject bala;
    private float timer;
    [SerializeField] ParticleSystem Muzzle;
    [SerializeField] GameObject granada;
    /*
    Vector3 mousePos;
    [SerializeField] Camera cam;
    private Rigidbody rb; 
    */
    public float cadencia;

    [SerializeField] Animator _animator;

    private void Awake()
    {
        input = new PlayerInput();
        input.CharacterControls.Shoot.performed += Disparar;
        input.CharacterControls.Invisibility.performed += Granada;
        //input.CharacterControls.Shoot.started += IniciarRafaga;
        //input.CharacterControls.Shoot.canceled += FinalizarRafaga;
    }

    private void OnEnable()
    {
        input.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        input.CharacterControls.Disable();
    }

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        timer = 0;
        cadencia = 0.5f;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
    }

    void Disparar(InputAction.CallbackContext obj)
    {
        if (timer >= cadencia)
        {

            Instantiate(bala, transform.position, transform.rotation);
            
            Muzzle.Play();
            
            timer = 0;

            _animator.SetTrigger("shoot");
        }
    }
    void Granada(InputAction.CallbackContext obj)
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0.0f;


        if (plane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Instantiate(granada, transform.position, transform.rotation);
        }

    }

    /*
    void FixedUpdate()
    {
        Vector3 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan(lookDir.y) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    */
}
