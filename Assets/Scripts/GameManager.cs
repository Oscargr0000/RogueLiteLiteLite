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
    private AnimatorController ACS;

    public bool GOP;

    // Start is called before the first frame update
    void Start()
    {
        ACS = FindObjectOfType<AnimatorController>();
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

        if(GOP == true)
        {
            ACS.enabled = false;
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
