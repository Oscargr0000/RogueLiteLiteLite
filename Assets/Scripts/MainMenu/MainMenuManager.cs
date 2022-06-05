using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public GameObject[] GeneralCanvas;
    private AudioManager AMS;

    private void Start()
    {
        AMS = FindObjectOfType<AudioManager>();
        GeneralCanvas[0].SetActive(true);
        GeneralCanvas[1].SetActive(false);
        GeneralCanvas[2].SetActive(false);
    }
    public void Options()
    {
        GeneralChange(0, 1);
        Sounds();
    }

    public void Play()
    {
        //GeneralChange(0, 2);
        SceneManager.LoadScene(1);
        Sounds();
    }

    public void Return()
    {
        GeneralChange(1, 0);
        Sounds();
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
    void Sounds()
    {
        AMS.PlaySound(9);
    }
}
