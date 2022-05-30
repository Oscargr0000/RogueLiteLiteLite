using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    rojo,
    lila
}
public class Enemy : MonoBehaviour
{
    private GameObject Player;
    public float EnemyHP;
    public float Damage;
    public float Speed;
    public int HPprobability;
    public GameObject HpRecover;

    private float knokback = 10f;
    private Rigidbody enemyRigidbody;

    private GameManager GameMangerScript;
    private PlayerController PlayerControllerScript;
    private FollowPlayer FollowPlayerScript;

    public EnemyType Type;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        enemyRigidbody = GetComponent<Rigidbody>();

        GameMangerScript = FindObjectOfType<GameManager>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        FollowPlayerScript = FindObjectOfType<FollowPlayer>();

        if (Type == EnemyType.rojo)
        {
            // enemyHp == DataPersistanceHProjo + Multiplicador
        }
        else if( Type == EnemyType.lila)
        {
            // enemyHp == DataPersistanceHPlila + Multiplicador
        }
       


    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameMangerScript.GOP == false)
        {
            transform.LookAt(Player.transform);
        }
        else
        {
            Speed = 0f;
        }
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        //Quitar esta linea de codigo
        if (Input.GetKeyDown(KeyCode.J))
        {
            DestroyEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControllerScript.HP -= Damage;
            Debug.Log($"Player:{PlayerControllerScript.HP}");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            Vector3 direction = (Player.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(direction * knokback);
            FollowPlayerScript.ShieldActive = false;
        }
    }

    public void DestroyEnemy()
    {
        
        HPprobability = Random.Range(1, 10);
        if(HPprobability == 1)
        {
            Instantiate(HpRecover, transform.position, transform.rotation);
        }
        Destroy(gameObject);
        //Partoculas
        //sonido 
    }
}
