using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MenuManager : MonoBehaviour
{
    private Weapons WeaponsScript;
    private PlayerController PlayerControllerScript;
    private GameManager GameManagerScript;
    private SpawnManager SpawnManagerScript;
    private FollowPlayer FollowPlayerScript;

    private List<int> PickCardRandom;

    public bool HondaAttack = true;

    public GameObject PowerUpsCanvas;
    public GameObject PauseGameCanvas;


    //POWERUPS
    public GameObject[] PowerUpsButtons;
    

    // Start is called before the first frame update
    void Start()
    {
        WeaponsScript = FindObjectOfType<Weapons>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        GameManagerScript = FindObjectOfType<GameManager>();
        SpawnManagerScript = FindObjectOfType<SpawnManager>();
        PowerUpsCanvas.SetActive(false);
        PauseGameCanvas.SetActive(false);
        FollowPlayerScript.ShieldActive = false;
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




    private void GeneralDataPower()
    {
        GameManagerScript.RoundNum = 0;
        SpawnManagerScript.SpawnEnemyWave(Random.Range(2, 3));
        SpawnManagerScript.ShowPowerUps = false;
    }

    /*public void ActivateButtons()
    {
        int random1 = Random.Range(0, PowerUpsButtons.Length);
        int random2 = Random.Range(0, PowerUpsButtons.Length);
        int random3 = Random.Range(0, PowerUpsButtons.Length);
        PowerUpsButtons[random1].SetActive(true);
        PowerUpsButtons[random2].SetActive(true);
        PowerUpsButtons[random3].SetActive(true);

        //int RandomPick = Random.Range(0, 3);
       // PickCardRandom.Add(RandomPick);
        
    }*/
}
