using UnityEngine;

public class ObjectReturner : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.z < -10) // Adjust this value based on the camera position
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        FindObjectOfType<ObjectPooler>().ReturnObject(gameObject);
    }
}
