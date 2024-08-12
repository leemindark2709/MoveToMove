using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy
    
    public List<Transform> spawnPoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
        // Check if CheckPointSpawnEnemy.Instance is properly initialized
        if (CheckPointSpawnEnemy.Instance != null)
        {
            spawnPoints = CheckPointSpawnEnemy.Instance.Enemys;
            SpawnEnemy();
        }
        else
        {
            Debug.LogError("CheckPointSpawnEnemy.Instance is not set.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("enemyPrefab is not assigned.");
            return;
        }

        // Loop through each spawn point
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Instantiate an enemy prefab at the spawn point's position and rotation
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
