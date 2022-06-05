using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private Weapons WeaponsScript;
    private PlayerController PlayerControllerScript;
    private SpawnManager SpawnManagerScript;
    private FollowPlayer FollowPlayerScript;

    public int RoundNum = 1;

    public GameObject PowerUpsCanvas;
    public GameObject PauseGameCanvas;
    public GameObject PauseAlert;
    public GameObject GameOverCanvas;
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI RoundText;
    private AudioManager AMS;
    public ParticleSystem SparkPS;



    //POWERUPS
    public GameObject[] PowerUpsButtons;
    

    
    void Start()
    {
        AMS = FindObjectOfType<AudioManager>();

        GameOverCanvas.SetActive(false);
        WeaponsScript = FindObjectOfType<Weapons>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        SpawnManagerScript = FindObjectOfType<SpawnManager>();
        FollowPlayerScript = FindObjectOfType<FollowPlayer>();
        PowerUpsCanvas.SetActive(false);
        PauseGameCanvas.SetActive(false);
        FollowPlayerScript.ShieldActive = false;
        PauseAlert.SetActive(false);
        
    }

    private void Update()
    {
        string getHP = PlayerControllerScript. HP.ToString();
        int Round = SpawnManagerScript.totalEnemy;
        string getRound = Round.ToString();

        HpText.text = getHP;
        RoundText.text = getRound;
       


        if (SpawnManagerScript.ShowPowerUps == true)
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
        StartCoroutine("DesactivarEscudo");
    }

    public void Jump()
    {
        PlayerControllerScript.JumpMax =+ 1;
        GeneralDataPower();
    }



    // PauseMenu
    public void PauseMenu()
    {
        PauseGameCanvas.SetActive(true);
        Time.timeScale = 0;
        AMS.PlaySound(10);
    }

    public void ReturnPlay()
    {
        PauseGameCanvas.SetActive(false);
        Time.timeScale = 1;
        AMS.PlaySound(10);
    }

    public void Escape()
    {
        PauseAlert.SetActive(true);
        AMS.PlaySound(10);
    }

    public void OkayEscape()
    {
        SceneManager.LoadScene(0);
        AMS.PlaySound(10);
    }

    public void NoEscape()
    {
        PauseAlert.SetActive(false);
        AMS.PlaySound(10);
    }

    

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        AMS.PlaySound(10);
    }


    private void GeneralDataPower()
    {
        SpawnManagerScript.SpawnEnemyWave(Random.Range(2, 3));
        SpawnManagerScript.ShowPowerUps = false;
        AMS.PlaySound(4);
        Instantiate(SparkPS, PlayerControllerScript.Player.transform.position, PlayerControllerScript.Player.transform.rotation);
    }

    IEnumerator DesactivarEscudo()
    {
        yield return new WaitForSeconds(30f);
        FollowPlayerScript.ShieldActive = false;
    }
}
