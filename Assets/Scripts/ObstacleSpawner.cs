using UnityEngine;
using UnityEngine.Serialization;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform dino;
    public float spawnOffsetX = 5;
    public float spawnY = 0.2f;
    public GameObject[] obstaclePrefabs;

    public float minSpawnInterval = 1f, maxSpawnInterval = 3f;
    public Vector3 spawnOffsetNext = new Vector3(0.5f, 0, 0);
    
    float timer, nextSpawnTime;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextSpawnTime)
        {
            int count = Random.value > 0.5f ? Random.Range(2, 4) : 1;
            for (int i = 0; i < count; i++)
            {
                int randId = Random.Range(0, obstaclePrefabs.Length);
                var prefab = obstaclePrefabs[randId];
                
                Vector3 pos = dino.position;
                pos.x += spawnOffsetX;
                pos.y = spawnY;
                
                Instantiate(prefab, pos + (spawnOffsetNext * i), Quaternion.identity);
            }

            timer = 0;
            nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }
}