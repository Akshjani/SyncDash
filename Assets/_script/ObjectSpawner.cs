using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectPooler objectPool; // Reference to Object Pool
    public Transform[] spawnPoints; // Two fixed spawn locations
    public float initialSpeed = 5f;
    public float speedIncreaseRate = 0.2f; // Increases speed over time
    public float spawnInterval = 1.5f; // Time between each spawn
    private float currentSpeed;

    private void Start()
    {
        currentSpeed = initialSpeed;
        StartSpawning();
    }

    private void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval); // Spawns continuously
        InvokeRepeating(nameof(IncreaseSpeed), 5f, 5f); // Speed increases every 5 seconds
    }

    private void SpawnObject()
    {
        // Select a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Get an object from the pool
        GameObject obj = objectPool.GetObject(spawnPoint.position);

        // Assign the movement script and set speed
        ObjectMover mover = obj.GetComponent<ObjectMover>();
        if (mover == null)
        {
            mover = obj.AddComponent<ObjectMover>();
        }
        mover.SetSpeed(currentSpeed);
    }

    private void IncreaseSpeed()
    {
        currentSpeed += speedIncreaseRate; // Increment speed over time
    }
}
