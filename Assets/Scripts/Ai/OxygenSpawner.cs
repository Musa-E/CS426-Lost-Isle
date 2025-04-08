using UnityEngine;

public class OxygenSpawner : MonoBehaviour
{
    [SerializeField] private OxygenCounter oxygenCounter;
    public GameObject oxygenTankPrefab;
    public Transform player;
    public PathFinder pathfinder; // Reference to your PathFinder script

    public float spawnRadius = 30f;
    public float criticalOxygenLevel = 20f;
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
            oxygenSpawned = false;
        }
    }

    private void SpawnOxygenTank()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject spawnedTank = Instantiate(oxygenTankPrefab, spawnPosition, Quaternion.identity);

        // Set the target in the PathFinder
        pathfinder.SetCurrentTarget(spawnedTank.transform);

        // Trigger Pathfinding
        pathfinder.FindPath(player.position, spawnedTank.transform.position);

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
