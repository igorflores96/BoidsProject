using UnityEngine;

public class Seeker : MonoBehaviour
{
    [SerializeField] private float _goToSpeed = 3f;
    [SerializeField] private Transform _flee;

    private void Update()
    {
        Vector3 targetPosition = _flee.position;
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _goToSpeed);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        

        transform.position = newPosition;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _goToSpeed * 5f * Time.deltaTime);
    }
}
