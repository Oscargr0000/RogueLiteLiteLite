using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;

    public float speed = 10f;
    private float RunningSpeed = 5f;
    private float verticalInput;
    private float horizontalInput;
    private float rotationSpeed = 200f;
    private float MouseXInput;
    private Vector3 GravityForce = new Vector3(0, -9.8f, 0);

    public bool itsOntheGround;

    private int Jumps;
    public int JumpMax = 1;

    public float HP = 100f;

    public Rigidbody RigidBodyComponent;
    public LayerMask GroundLayer;
    public GameObject RunningPT;

    private Enemy ES;

    

    void Start()
    {
        ES = FindObjectOfType<Enemy>();
        RigidBodyComponent = GetComponent<Rigidbody>();
        RunningPT.SetActive(false);
        Physics.gravity = GravityForce;
    }

   

    void Update()
    {
        // El movimiento funciona con WASD para avanzar y para girar con el raton

        //Movimiento del Raton
        MouseXInput = Input.GetAxis("Mouse X");
        Quaternion CurrenteRotation = Quaternion.Euler(new Vector3(0f, rotationSpeed, 0f) * Time.deltaTime * MouseXInput);
        RigidBodyComponent.MoveRotation(RigidBodyComponent.rotation * CurrenteRotation);

        //Movimiento del Player
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 RbMovement = new Vector3(horizontalInput, 0, verticalInput);
        RbMovement = transform.TransformDirection(RbMovement);

        RigidBodyComponent.MovePosition(RigidBodyComponent.position + RbMovement * speed * Time.deltaTime);


        // Salto + Contador de saltos realizados
        if (Input.GetKeyDown(KeyCode.Space) && Jumps <= JumpMax)
        {
            RigidBodyComponent.AddForce(Vector3.up * 500, ForceMode.Impulse);
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

        if (other.gameObject.CompareTag("EnemyHit"))
        {
            HP -= ES.Damage;
        }
    }
}
