using UnityEngine;

public class OxygenSpawner : MonoBehaviour
{
    [SerializeField] private OxygenCounter oxygenCounter; // Ensure this is dragged from Inspector
    public GameObject oxygenTankPrefab; // Prefab of the Oxygen Tank
    public Transform player;
    public float spawnRadius = 30f;
    public float criticalOxygenLevel = 98f; // Testing high value to trigger spawning quickly
    public float minSpawnDistance = 10f;
    public float maxSpawnDistance = 25f;

    private bool oxygenSpawned = false;

    private void Update()
    {
        int playerOxygen = oxygenCounter.oxygenLevel;

        if (playerOxygen <= criticalOxygenLevel && !oxygenSpawned)
        {
            SpawnOxygenTank();
            oxygenSpawned = true;
        }

        if (playerOxygen > criticalOxygenLevel)
        {
            oxygenSpawned = false; // Reset to allow spawning when oxygen is low again
        }
    }

    private void SpawnOxygenTank()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(oxygenTankPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Oxygen Tank Spawned at: " + spawnPosition);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * maxSpawnDistance;
        randomDirection += player.position;
        randomDirection.y = player.position.y;

        float distanceFromPlayer = Vector3.Distance(player.position, randomDirection);

        while (distanceFromPlayer < minSpawnDistance)
        {
            randomDirection = Random.insideUnitSphere * maxSpawnDistance + player.position;
            randomDirection.y = player.position.y;
            distanceFromPlayer = Vector3.Distance(player.position, randomDirection);
        }

        return randomDirection;
    }
}
