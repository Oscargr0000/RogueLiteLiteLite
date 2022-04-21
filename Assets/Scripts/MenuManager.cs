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


    //PowerUps Para la UI
    public void Damage()
    {
        WeaponsScript.Damage += 10f;
        GameManagerScript.RoundNum = 0;
    }
    public void Speed()
    {
        PlayerControllerScript.speed += 5;
        GameManagerScript.RoundNum = 0;
    }

    public void Shield()
    {

    }

    public void Jump()
    {
        PlayerControllerScript.JumpMax++;
        GameManagerScript.RoundNum = 0;
    }
}
