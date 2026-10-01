using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class AsteroidBehavior : MonoBehaviour
{
    public Transform targetPosition;
    private Vector3 startPosition;
    private Vector3 enemyPosition;
    void Awake()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, 2 * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.5f)
        {
            transform.position = startPosition;
        }
    }
}