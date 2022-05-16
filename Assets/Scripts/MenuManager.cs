using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Weapons WeaponsScript;
    private PlayerController PlayerControllerScript;
    private GameManager GameManagerScript;
    private SpawnManager SpawnManagerScript;
    private FollowPlayer FollowPlayerScript;

    

    public bool HondaAttack = true;

    public GameObject PowerUpsCanvas;
    public GameObject PauseGameCanvas;
    public GameObject PauseAlert;


    //POWERUPS
    public GameObject[] PowerUpsButtons;
    

    
    void Start()
    {
        WeaponsScript = FindObjectOfType<Weapons>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        GameManagerScript = FindObjectOfType<GameManager>();
        SpawnManagerScript = FindObjectOfType<SpawnManager>();
        FollowPlayerScript = FindObjectOfType<FollowPlayer>();
        PowerUpsCanvas.SetActive(false);
        PauseGameCanvas.SetActive(false);
        FollowPlayerScript.ShieldActive = false;
        PauseAlert.SetActive(false);
    }

    private void Update()
    {
        if(SpawnManagerScript.ShowPowerUps == true)
        {
            PowerUpsCanvas.SetActive(true);
            //ActivateButtons(); 
        }
        else
        {
            PowerUpsCanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    //PowerUps Para la UI
    public void Damage()
    {
        WeaponsScript.Damage += 10f;
        GeneralDataPower();
    }
    public void Speed()
    {
        PlayerControllerScript.speed += 2;
        GeneralDataPower();
    }

    public void Shield()
    {
        FollowPlayerScript.ShieldActive = true;
        GeneralDataPower();
    }

    public void Jump()
    {
        PlayerControllerScript.JumpMax =+ 1;
        GeneralDataPower();
    }

    public void EffectSword()
    {
        HondaAttack = true;
    }



    // PauseMenu
    public void PauseMenu()
    {
        PauseGameCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnPlay()
    {
        PauseGameCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void Escape()
    {
        PauseAlert.SetActive(true);
    }

    public void OkayEscape()
    {
        SceneManager.LoadScene(0);
    }

    public void NoEscape()
    {
        PauseAlert.SetActive(false);
    }

    




    private void GeneralDataPower()
    {
        GameManagerScript.RoundNum = 0;
        SpawnManagerScript.SpawnEnemyWave(Random.Range(2, 3));
        SpawnManagerScript.ShowPowerUps = false;
    }
}
