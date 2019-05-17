using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerDB : MonoBehaviour
{
    private GameObject player;
    public Transform enemySpawn;
    public Rigidbody[] enemyPrefab;
    public int a;
    Rigidbody clone;

    // Start is called before the first frame update
    void Start()
    {
        Connection.WorldEnemies();

         switch (a)
         {
            case 1:
                enemySpawn = GameObject.Find("SpawnerDB" + a).transform;
                clone = Instantiate(enemyPrefab[Connection.DBEnemiesSpawn[0]], enemySpawn.position, enemySpawn.rotation) as Rigidbody;
                break;
            case 2:
                 enemySpawn = GameObject.Find("SpawnerDB" + a).transform;
                 clone = Instantiate(enemyPrefab[Connection.DBEnemiesSpawn[1]], enemySpawn.position, enemySpawn.rotation) as Rigidbody;
                 break;
            case 3:
                enemySpawn = GameObject.Find("SpawnerDB" + a).transform;
                clone = Instantiate(enemyPrefab[Connection.DBEnemiesSpawn[2]], enemySpawn.position, enemySpawn.rotation) as Rigidbody;
                break;
            case 4:
                enemySpawn = GameObject.Find("SpawnerDB" + a).transform;
                clone = Instantiate(enemyPrefab[Connection.DBEnemiesSpawn[3]], enemySpawn.position, enemySpawn.rotation) as Rigidbody;
                break;

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
