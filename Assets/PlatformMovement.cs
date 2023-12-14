using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float distance = 5f;

    private float startPos;

    private void Start()
    {
        startPos = transform.position.x;
    }

    private void Update()
    {
        float newPos = startPos + Mathf.PingPong(Time.time * speed, distance);
        transform.position = new Vector3(newPos, transform.position.y, transform.position.z);
    }
}