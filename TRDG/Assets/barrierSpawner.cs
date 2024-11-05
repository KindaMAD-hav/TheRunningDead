using UnityEngine;

public class barrierSpawner : MonoBehaviour
{
    // Reference to the BoxCollider2D component
    private BoxCollider2D spawnArea;

    // Range for the number of objects to spawn
    public int minSpawnCount = 5;
    public int maxSpawnCount = 10;

    // The prefabs to spawn
    public GameObject[] spawnPrefabs;

    private void Start()
    {
        // Get the BoxCollider2D component attached to this GameObject
        spawnArea = GetComponent<BoxCollider2D>();
        SpawnObjects();
    }

    public void SpawnObjects()
    {
        // Randomize the count of objects to spawn
        int spawnCount = Random.Range(minSpawnCount, maxSpawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            // Get a random position within the BoxCollider2D bounds
            Vector2 randomPosition = GetRandomPositionInBounds(spawnArea.bounds);

            // Select a random prefab from the list
            GameObject prefabToSpawn = spawnPrefabs[Random.Range(0, spawnPrefabs.Length)];

            // Instantiate the prefab at the random position
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }
    }

    // Helper method to get a random position within specified bounds
    private Vector2 GetRandomPositionInBounds(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(x, y);
    }

    // Optional: Draw the spawn area in the Scene view
    private void OnDrawGizmos()
    {
        BoxCollider2D area = GetComponent<BoxCollider2D>();
        if (area != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(area.bounds.center, area.bounds.size);
        }
    }
}
