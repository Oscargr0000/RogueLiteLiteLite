using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] GeneralCanvas;

    private void Start()
    {
        GeneralCanvas[0].SetActive(true);
        GeneralCanvas[1].SetActive(false);
        GeneralCanvas[2].SetActive(false);
    }
    public void Options()
    {
        GeneralChange(0, 1);
    }

    public void Play()
    {
        GeneralChange(0, 2);
    }

    public void Return()
    {
        GeneralChange(1, 0);
    }

    public void Espada()
    {
        
    }

    public void Lanza()
    {

    }

    public void Maza()
    {

    }
    void GeneralChange(int FalseCanvas, int TrueCanvas)
    {
        GeneralCanvas[FalseCanvas].SetActive(false);
        GeneralCanvas[TrueCanvas].SetActive(true);
    }
}
