using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    public float EnemyHP;
    public float Damage;
    public float Speed;
    
    private GameManager GameMangerScript;
    private Rigidbody RigidBodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        GameMangerScript = FindObjectOfType<GameManager>();
        //RigidBodyComponent.constraints = RigidbodyConstraints.FreezeRotationX;
        //RigidBodyComponent.constraints = RigidbodyConstraints.FreezeRotationZ;
        //RigidBodyComponent.constraints = RigidbodyConstraints.FreezeRotationY;

    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameMangerScript.GameOver == false)
        {
            transform.LookAt(Player.transform);
        }
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameMangerScript.HpPlayer -= Damage;
            Debug.Log($"Player:{GameMangerScript.HpPlayer}");
        }
    }
}
