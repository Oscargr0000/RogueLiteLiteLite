using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Weapons WeaponsScript;
    private PlayerController PlayerControllerScript;
    private GameManager GameManagerScript;
    private SpawnManager SpawnManagerScript;

    public GameObject PowerUpsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        WeaponsScript = FindObjectOfType<Weapons>();
        PlayerControllerScript = FindObjectOfType<PlayerController>();
        GameManagerScript = FindObjectOfType<GameManager>();
    }

    private void Update() //Arreglar
    {
        if (SpawnManagerScript.EnemyLeft == 0 && GameManagerScript.RoundNum == 5)
        {
            PowerUpsCanvas.SetActive(true);
        }
        else
        {
            PowerUpsCanvas.SetActive(false);
        }
    }


    //PowerUps Para la UI
    public void PowerTest1()
    {
        WeaponsScript.Damage += 10f;
        GameManagerScript.RoundNum = 0;
    }
    public void PowerUp2Test()
    {
        PlayerControllerScript.speed += 10;
        GameManagerScript.RoundNum = 0;
    }
}
