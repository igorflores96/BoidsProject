using UnityEngine;

public class Flee : MonoBehaviour
{
    [Header("Speed Infos")]
    [SerializeField] private float _speed = 3f;
    private Vector3 _direction;
    
    void Start()
    {
        _direction = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {
        Move();
        CheckScreenBounds();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void CheckScreenBounds()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.x < 0f || viewportPos.x > 1f || viewportPos.y < 0f || viewportPos.y > 1f)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _direction = Quaternion.Euler(0, 0, Random.Range(120f, 240f)) * _direction;
    }
}
