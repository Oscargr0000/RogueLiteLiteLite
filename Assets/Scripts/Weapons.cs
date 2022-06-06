using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float Damage;
    private Enemy EnemyScript;
    private AudioManager AMS;


    private void Start()
    {
        AMS = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScript = other.gameObject.GetComponent<Enemy>();
            EnemyScript.Empuje(750f);
            AMS.PlaySound(3);

            EnemyScript.EnemyHP -= Damage;
            Debug.Log($"Enemy:{EnemyScript.EnemyHP}");
            
            if( EnemyScript.EnemyHP <= 0f)
            {
                EnemyScript.DestroyEnemy();
            }
        }
    }
}
