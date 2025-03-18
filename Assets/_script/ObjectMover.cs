using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private float speed;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime; // Move toward player in Z-axis only
    }
}
