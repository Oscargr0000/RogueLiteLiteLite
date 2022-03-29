using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Enemies;
    private int RandomNum;
    private float RandomSpawn;



    private float RandomX;
    private float RandomZ;
    

    // Start is called before the first frame update
    void Start()
    {
        RandomNum = Random.Range(0, 2);

        SpawnEnemies();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomSpawnPos()
    {
        RandomX = Random.Range(5, -5);
        RandomZ = Random.Range(5, -5);

       return new Vector3(RandomX, 0, RandomZ);
    }

    void SpawnEnemies()
    {
        Instantiate(Enemies[RandomNum], RandomSpawnPos(), Enemies[RandomNum].transform.rotation);
    }
}
