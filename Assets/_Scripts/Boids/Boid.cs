using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float neighborRadius = 2f;
    [SerializeField] private float separationRadius = 1f;
    [SerializeField] private float alignmentWeight = 1f;
    [SerializeField] private float cohesionWeight = 1f;
    [SerializeField] private float separationWeight = 1.5f;
    
    
    private Vector3 velocity;
    private BoidManager manager;

    void Start()
    {
        velocity = Random.insideUnitCircle.normalized * speed;
        manager = FindObjectOfType<BoidManager>();
    }

    void Update()
    {
        List<Boid> neighbors = manager.GetNeighbors(this, neighborRadius);
        
        Vector3 alignment = ComputeAlignment(neighbors) * alignmentWeight;
        Vector3 cohesion = ComputeCohesion(neighbors) * cohesionWeight;
        Vector3 separation = ComputeSeparation(neighbors) * separationWeight;

        velocity += alignment + cohesion + separation;
        velocity = velocity.normalized * speed;

        transform.position += velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, velocity);
    }

    private Vector3 ComputeAlignment(List<Boid> neighbors)
    {
        if (neighbors.Count == 0) return Vector3.zero;

        Vector3 avgVelocity = Vector3.zero;
        foreach (var neighbor in neighbors)
        {
            avgVelocity += neighbor.velocity;
        }
        avgVelocity /= neighbors.Count;
        return (avgVelocity - velocity).normalized;
    }

    private Vector3 ComputeCohesion(List<Boid> neighbors)
    {
        if (neighbors.Count == 0) return Vector3.zero;

        Vector3 center = Vector3.zero;
        foreach (var neighbor in neighbors)
        {
            center += neighbor.transform.position;
        }
        center /= neighbors.Count;
        return (center - transform.position).normalized;
    }

    private Vector3 ComputeSeparation(List<Boid> neighbors)
    {
        if (neighbors.Count == 0) return Vector3.zero;

        Vector3 separationForce = Vector3.zero;
        foreach (var neighbor in neighbors)
        {
            float distance = Vector3.Distance(transform.position, neighbor.transform.position);
            if (distance < separationRadius)
            {
                separationForce += (transform.position - neighbor.transform.position).normalized / distance;
            }
        }
        return separationForce.normalized;
    }
}
