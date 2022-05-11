using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    private int RandomNum;
    public int TotalRounds = 1;
    private float RandomSpawn;
    public bool ShowPowerUps;

    

    public int totalEnemy = 1;
    public int EnemyLeft;

    

    private float RandomX;
    private float RandomZ;


    private GameManager GameManagerScrpipt;
    

    
    void Start()
    {
        GameManagerScrpipt = FindObjectOfType<GameManager>();
        RandomNum = Random.Range(0, 2);

        SpawnEnemyWave(totalEnemy);
        

    }

    
    void Update()
    {
        EnemyLeft = FindObjectsOfType<Enemy>().Length;
        if (EnemyLeft <= 0)
        {
            MostrarPowerUps();
            while (ShowPowerUps)
            {
                return;
            }

            totalEnemy++;
            SpawnEnemyWave(totalEnemy);
            
        }
    }

    Vector3 RandomSpawnPos()
    {
        RandomX = Random.Range(7.5f, 31.2f );
        RandomZ = Random.Range(1.7f, 28.5f);

       return new Vector3(RandomX, 1, RandomZ);
    }

    void SpawnEnemies()
    {
        RandomNum = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[RandomNum], RandomSpawnPos(), Enemies[RandomNum].transform.rotation);
    }

    public void SpawnEnemyWave(int enemyInMap)
    {
        for (int i = 0; i < enemyInMap; i++)
        {
            SpawnEnemies();
            Debug.Log(TotalRounds);
        }
        TotalRounds++;
    }


    private void MostrarPowerUps()
    {
        if (TotalRounds % 5 == 0)
        {
            ShowPowerUps=  true;
        }
        else
        {
            ShowPowerUps = false;
        }
    }

}
