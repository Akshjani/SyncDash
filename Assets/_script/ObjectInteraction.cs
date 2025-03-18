using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public enum ObjectType { Orb, Enemy }
    public ObjectType objectType; // Assign in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (objectType == ObjectType.Orb && other.CompareTag("Player"))
        {
            // Handle orb collection
            Debug.Log("Orb Collected!");

            // Return the object to the pool instead of destroying it
            FindObjectOfType<ObjectPooler>().ReturnObject(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (objectType == ObjectType.Enemy && collision.gameObject.CompareTag("Player"))
        {
            // Handle enemy collision
            Debug.Log("Player Hit by Enemy! Game Over or Lose Life!");

            // Optionally, return the object to the pool or trigger game over logic
            FindObjectOfType<ObjectPooler>().ReturnObject(gameObject);
        }
    }
}
