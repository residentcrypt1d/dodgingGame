using UnityEngine;

public class StubbornAsteroidBehavior : MonoBehaviour
{
    [SerializeField] private float distanceToCover;
    [SerializeField] private float speed;
    public Vector3 startingPosition;
    public Transform targetPosition;
    void Start()
    {
        startingPosition = transform.position;

    }
    
    void Update()
    {
        Vector3 v = startingPosition;
        v.y += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = v;
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, 2 * Time.deltaTime);
    }
}