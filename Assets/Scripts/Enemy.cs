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

    private float knokback = 1000f;
    private Rigidbody enemyRigidbody;

    private GameManager GameMangerScript;
    private PlayerController PlayerControllerScript;
    private FollowPlayer FollowPlayerScript;
    public Animator EnemyAttack;
    private AudioManager AMS;

    Vector3 direction;

    public EnemyType Type;



    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.Find("Player");
        enemyRigidbody = GetComponent<Rigidbody>();
        GameMangerScript = FindObjectOfType<GameManager>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        FollowPlayerScript = FindObjectOfType<FollowPlayer>();
        AMS = FindObjectOfType<AudioManager>();

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
        direction = (Player.transform.position - transform.position).normalized;

        if (GameMangerScript.GOP == false)
        {
            //Look at con fisicas
            Quaternion RotationP = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = RotationP;
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
            EnemyAttack.SetTrigger("AttaqueEnemigo");
            EnemyAttack.SetTrigger("RedAttack");

            int RandomSaound = Random.Range(1, 3);
            AMS.PlaySound(RandomSaound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield"))
        {

            Empuje(knokback);
            AMS.PlaySound(7);
            FollowPlayerScript.ShieldActive = false;

        }
    }

    public void DestroyEnemy()
    {
        
        HPprobability = Random.Range(1, 10);
        if(HPprobability == 1)
        {
            Instantiate(HpRecover, transform.position, transform.rotation);
        }else if( HPprobability == 2)
        {
            Instantiate(HpRecover, transform.position, transform.rotation);
        }

        Destroy(gameObject);
        //Partoculas
        AMS.PlaySound(6);
    }

    public void Empuje(float Fuerza)
    {
        enemyRigidbody.AddForce(-direction * Fuerza, ForceMode.Impulse);
    }
}
