using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployEnemies : MonoBehaviour
{
    public GameObject MEnemyPrefab;
    public float respawnTime = 100.0f;
    private Vector2 screenBounds;
    int i;

    public Transform[] spawnPoints;
    int randomSpawnPoint;
    public static bool spawnAllowed;


    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("spawnEnemy", 0f, 1f);
    }



    private void spawnEnemy()
    {
    //spawns enemies
      if(spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(MEnemyPrefab, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }


}
