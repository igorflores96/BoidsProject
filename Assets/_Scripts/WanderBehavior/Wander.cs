using UnityEngine;

public class Wander : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _wanderRadius = 5f;
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
        CheckWanderRadius();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void CheckWanderRadius()
    {
        if (Vector3.Distance(transform.position, _startPosition) > _wanderRadius)
        {
            ChangeDirection();
            _startPosition = transform.position;
        }
    }

    private void ChangeDirection()
    {
        _direction = Quaternion.Euler(0, 0, Random.Range(120f, 240f)) * _direction;
    }
}
