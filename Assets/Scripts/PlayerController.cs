using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 15f;
    private float verticalInput;
    private float horizontalInput;
    private float rotationSpeed = 400f;
    private float MouseXInput;

    public bool itsOntheGround;

    private int Jumps;
    public int JumpMax = 1;

    public float HP;

    private Rigidbody RigidBodyComponent;

    

    // Start is called before the first frame update
    void Start()
    {
        RigidBodyComponent = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
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

        
    }


    // Resetea la cantidad de saltos realizados al tocar el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Jumps = 0;
        }
    }
}
