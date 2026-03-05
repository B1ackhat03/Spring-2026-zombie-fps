using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public float spawnRate = 2f;
    public int maxZombies = 10;
    public float spawnRadius = 10f;

    private float timer;

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Zombie").Length < maxZombies)
        {
            timer += Time.deltaTime;

            if (timer >= spawnRate)
            {
                SpawnZombie();
                timer = 0f;
            }
        }
    }

    void SpawnZombie()
    {
        Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPos.y = 1;

        Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
    }
}