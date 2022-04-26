using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float Damage;
    private Enemy EnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScript = other.gameObject.GetComponent<Enemy>();


            EnemyScript.EnemyHP -= Damage;
            Debug.Log($"Enemy:{EnemyScript.EnemyHP}");
            
            if( EnemyScript.EnemyHP <= 0f)
            {
                EnemyScript.DestroyEnemy();
            }
        }
    }
}
