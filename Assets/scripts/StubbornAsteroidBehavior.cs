using UnityEngine;

public class StubbornAsteroidBehavior : MonoBehaviour
{
    [SerializeField] private float distanceToCover;
    [SerializeField] private float speed;
    public Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;

    }
    
    void Update()
    {
        Vector3 v = startingPosition;
        v.y += distanceToCover * Mathf.Sin(Time.time * speed); // not gonna lie, i know this works because of the unity documentation, not because i fully understand it
        transform.position = v;
    }
}