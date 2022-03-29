using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 15f;
    private float verticalInput;
    private float rotationSpeed = 200f;
    private float MouseXInput;

    public bool itsOntheGround;

    private Rigidbody RigidBodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        RigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // El movimiento funciona con W y S para avanzar y para girar con el raton
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput); 

        MouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * MouseXInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RigidBodyComponent.AddForce(Vector3.up * 20000);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            itsOntheGround = true;
        }
        else
        {
            itsOntheGround = false;
        }
    }
}