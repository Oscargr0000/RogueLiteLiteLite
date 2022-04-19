using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    private int RandomNum;
    private float RandomSpawn;

    public int totalEnemy = 1;
    public int EnemyLeft;

    

    private float RandomX;
    private float RandomZ;


    private GameManager GameManagerScrpipt;
    

    // Start is called before the first frame update
    void Start()
    {
        GameManagerScrpipt = FindObjectOfType<GameManager>();
        RandomNum = Random.Range(0, 2);

        SpawnEnemyWave(totalEnemy);

    }

    // Update is called once per frame
    void Update()
    {
        EnemyLeft = FindObjectsOfType<Enemy>().Length;
        if (EnemyLeft <= 0)
        {
            totalEnemy++;
            GameManagerScrpipt.RoundNum++;
            SpawnEnemyWave(totalEnemy);
        }
        
        
    }

    Vector3 RandomSpawnPos()
    {
        RandomX = Random.Range(5, -5);
        RandomZ = Random.Range(5, -5);

       return new Vector3(RandomX, 1, RandomZ);
    }

    void SpawnEnemies()
    {
        Instantiate(Enemies[RandomNum], RandomSpawnPos(), Enemies[RandomNum].transform.rotation);
    }

    public void SpawnEnemyWave(int enemyInMap)
    {
        for (int i = 0; i < enemyInMap; i++)
        {
            SpawnEnemies();
            
        }
    }

}
