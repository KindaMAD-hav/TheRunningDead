using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Reference to the BoxCollider component for the spawn area
    public BoxCollider spawnArea;

    // Range for the number of coins to spawn
    public int minSpawnCount = 3;
    public int maxSpawnCount = 8;

    // The coin prefab to spawn
    public GameObject coinPrefab;

    private void Start()
    {
        SpawnCoins();
    }

    public void SpawnCoins()
    {
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
        Debug.Log($"Spawning {spawnCount} coins at {transform.position}");

        for (int i = 0; i < spawnCount; i++)
        {
            // Get a random position within the local bounds of the BoxCollider
            Vector3 localRandomPosition = GetRandomLocalPositionInBounds(spawnArea);

            // Convert local position to world position
            Vector3 worldPosition = transform.TransformPoint(localRandomPosition);

            // Instantiate the coin prefab at the calculated world position
            Instantiate(coinPrefab, worldPosition, Quaternion.identity);
        }
    }

    // Helper method to get a random position within the BoxCollider bounds in local space
    private Vector3 GetRandomLocalPositionInBounds(BoxCollider collider)
    {
        float x = Random.Range(-collider.size.x / 2, collider.size.x / 2);
        float y = Random.Range(-collider.size.y / 2, collider.size.y / 2);
        float z = Random.Range(-collider.size.z / 2, collider.size.z / 2);
        return new Vector3(x, y, z);
    }

    // Optional: Draw the spawn area in the Scene view
    private void OnDrawGizmos()
    {
        if (spawnArea != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(spawnArea.bounds.center, spawnArea.bounds.size);
        }
    }
}
