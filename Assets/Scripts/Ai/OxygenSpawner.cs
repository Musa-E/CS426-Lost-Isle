using UnityEngine;

public class OxygenSpawner : MonoBehaviour
{
    [SerializeField] private OxygenCounter oxygenCounter;
    public GameObject oxygenTankPrefab;
    public Transform player;
    public PathFinder pathfinder;
    public UIArrowIndicator uiArrowIndicator;

    public float spawnRadius = 30f;
    public float criticalOxygenLevel = 30f;
    public float minSpawnDistance = 10f;
    public float maxSpawnDistance = 25f;

    private bool oxygenSpawned = false;

    private void Update()
    {
        if (oxygenCounter == null || pathfinder == null || uiArrowIndicator == null)
        {
            Debug.LogError("One or more required references are missing in the OxygenSpawner. Check Inspector settings.");
            return;
        }

        int playerOxygen = oxygenCounter.oxygenLevel;

        if (playerOxygen <= criticalOxygenLevel && !oxygenSpawned)
        {
            SpawnOxygenTank();
            oxygenSpawned = true;
        }

        if (playerOxygen > criticalOxygenLevel)
        {
            oxygenSpawned = false;
            uiArrowIndicator.ClearTarget(); // Hide arrow when oxygen level is safe
        }
    }

    private void SpawnOxygenTank()
    {
        if (pathfinder == null || uiArrowIndicator == null)
        {
            Debug.LogError("PathFinder or UIArrowIndicator reference is missing. Check Inspector settings.");
            return;
        }

        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject spawnedTank = Instantiate(oxygenTankPrefab, spawnPosition, Quaternion.identity);

        pathfinder.SetCurrentTarget(spawnedTank.transform);
        pathfinder.FindPath(player.position, spawnedTank.transform.position);

        uiArrowIndicator.SetTarget(spawnedTank.transform); // Only show arrow when a tank is spawned

        Debug.Log("Oxygen Tank Spawned at: " + spawnPosition);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * maxSpawnDistance;
        randomDirection += player.position;
        randomDirection.y = player.position.y + 4f;

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
