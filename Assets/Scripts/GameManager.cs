using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public int RoundNum = 1;

    private Enemy EnemyScript;
    private SpawnManager SpawnManagerScript;
    private MenuManager MenuManagerScript;
    private PlayerController PlayerControllerScript;

    public bool GOP;

    // Start is called before the first frame update
    void Start()
    {

        MenuManagerScript.GameOverCanvas.SetActive(false);
        SpawnManagerScript = FindObjectOfType<SpawnManager>();
        EnemyScript = FindObjectOfType<Enemy>();
        MenuManagerScript = FindObjectOfType<MenuManager>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();

        GOP = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerControllerScript.HP <= 0)
        {
            GameOverPlayer();
        }

    }

    void GameOverPlayer()
    {
        Destroy(PlayerControllerScript.Player);
        GOP = true;
        MenuManagerScript.GameOverCanvas.SetActive(true);
        //HUD
        //Particulas
        //Sonidos
    }
}
