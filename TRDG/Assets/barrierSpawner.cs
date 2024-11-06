using UnityEngine;

public class barrierSpawner : MonoBehaviour
{
    // Reference to the BoxCollider2D component
    public BoxCollider2D spawnArea;

    // Range for the number of objects to spawn
    public int minSpawnCount = 5;
    public int maxSpawnCount = 10;

    // The prefabs to spawn
    public GameObject[] spawnPrefabs;

    private void Start()
    {
        SpawnObjects();
    }

    public void SpawnObjects()
    {
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);
        Debug.Log($"Spawning {spawnCount} objects at {transform.position}");

        for (int i = 0; i < spawnCount; i++)
        {
            // Get a random position within the local bounds of the BoxCollider2D
            Vector2 localRandomPosition = GetRandomLocalPositionInBounds(spawnArea);

            // Convert local position to world position
            Vector2 worldPosition = transform.TransformPoint(localRandomPosition);

            // Select a random prefab from the list
            GameObject prefabToSpawn = spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];
            Debug.Log($"Spawning {prefabToSpawn.name} at {worldPosition}");

            // Instantiate the prefab at the calculated world position
            Instantiate(prefabToSpawn, worldPosition, Quaternion.identity);
        }
    }

    // Helper method to get a random position within the BoxCollider2D bounds in local space
    private Vector2 GetRandomLocalPositionInBounds(BoxCollider2D collider)
    {
        float x = Random.Range(-collider.size.x / 2, collider.size.x / 2);
        float y = Random.Range(-collider.size.y / 2, collider.size.y / 2);
        return new Vector2(x, y);
    }

    // Optional: Draw the spawn area in the Scene view
    private void OnDrawGizmos()
    {
        if (spawnArea != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(spawnArea.bounds.center, spawnArea.bounds.size);
        }
    }
}
