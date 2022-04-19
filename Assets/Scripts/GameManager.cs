using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float HpPlayer;
    public bool GameOver;
    public int RoundNum = 1;


    private Enemy EnemyScript;
    private SpawnManager SpawnManagerScript;
    private MenuManager MenuManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;

        SpawnManagerScript = FindObjectOfType<SpawnManager>();
        EnemyScript = FindObjectOfType<Enemy>();
        MenuManagerScript = FindObjectOfType<MenuManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (RoundNum >= 5)
        {
            SpawnManagerScript.enabled = false;
        }
        else
        {
            SpawnManagerScript.enabled = true;
        }
    }

    
}
