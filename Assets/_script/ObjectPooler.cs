using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{


    public GameObject[] objectPrefabs; // Array to hold both Orbs & Enemies
    public int poolSize = 10; // Initial number of objects

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        // Pre-instantiate objects and store them in the pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = InstantiateRandomObject();
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject GetObject(Vector3 spawnPosition)
    {
        GameObject obj;

        // If pool is empty, create a new object
        if (pool.Count == 0)
        {
            obj = InstantiateRandomObject();
        }
        else
        {
            obj = pool.Dequeue();
        }

        obj.transform.position = spawnPosition;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    private GameObject InstantiateRandomObject()
    {
        GameObject obj = Instantiate(objectPrefabs[Random.Range(0, objectPrefabs.Length)]);
        obj.AddComponent<ObjectReturner>(); // Add return-to-pool logic
        obj.SetActive(false);
        return obj;
    }
}
