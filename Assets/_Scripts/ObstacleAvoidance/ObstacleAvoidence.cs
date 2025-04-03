using UnityEngine;

public class ObstacleAvoidence : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _wanderRadius = 5f;
    [SerializeField] private float _raycastDistance = 1f;
    [SerializeField] private LayerMask _obstacleLayer;
    private Vector3 _direction;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
        _direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        Move();
        CheckObstacles();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void CheckObstacles()
    {
        Vector3[] directions = new Vector3[]
        {
            Vector3.up, Vector3.down, Vector3.left, Vector3.right,
            new Vector3(1,1,0).normalized, new Vector3(-1,1,0).normalized,
            new Vector3(1,-1,0).normalized, new Vector3(-1,-1,0).normalized
        };

        foreach (Vector3 dir in directions)
        {
            if (Physics2D.Raycast(transform.position, dir, _raycastDistance, _obstacleLayer))
            {
                ChangeDirection();
                break;
            }
        }
    }

    private void ChangeDirection()
    {
        _direction = Quaternion.Euler(0, 0, Random.Range(120f, 240f)) * _direction;
    }
}
