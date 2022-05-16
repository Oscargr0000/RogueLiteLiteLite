using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 15f;
    private float RunningSpeed = 5f;
    private float verticalInput;
    private float horizontalInput;
    private float rotationSpeed = 400f;
    private float MouseXInput;

    public bool itsOntheGround;

    private int Jumps;
    public int JumpMax = 1;

    public float HP;

    private Rigidbody RigidBodyComponent;
    public LayerMask GroundLayer;
    public GameObject RunningPT;

    

    void Start()
    {
        RigidBodyComponent = GetComponent<Rigidbody>();
        RunningPT.SetActive(false);
           
    }



    void Update()
    {
        // El movimiento funciona con WASD para avanzar y para girar con el raton
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        MouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * MouseXInput);

         

        // Salto + Contador de saltos realizados
        if (Input.GetKeyDown(KeyCode.Space) && Jumps <= JumpMax)
        {
            RigidBodyComponent.AddForce(Vector3.up * 20000);
            Jumps++;
        }

        //Running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += RunningSpeed;
            RunningPT.SetActive(true);
        }else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= RunningSpeed;
            RunningPT.SetActive(false);
        }

        /*if(ItsOnTheGround() == true)
        {
            Jumps = 0;
        }*/
        
    }


    // Resetea la cantidad de saltos realizados al tocar el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Jumps = 0;
        }
    }

    private bool ItsOnTheGround() // MIRAR DE UTILIZAR
    {
        float yOffset = 0.2f;
        Vector3 origin = transform.position;
        CapsuleCollider PlayerCollider = GetComponent<CapsuleCollider>();

        Physics.Raycast(origin, Vector3.down, out RaycastHit hit, PlayerCollider.height + yOffset, GroundLayer);

        Color raycastColor = hit.collider != null ? Color.green : Color.magenta;
        Debug.DrawRay(origin, Vector3.down * (PlayerCollider.height + yOffset), raycastColor, 0, false);
        return hit.collider != null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            HP += 5;
            Debug.Log(HP);
            Destroy(other.gameObject);
        }
    }
}
