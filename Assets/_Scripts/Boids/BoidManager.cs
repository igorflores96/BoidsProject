using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
    public Boid boidPrefab;
    public int boidCount = 20;
    public float spawnRadius = 5f;
    private List<Boid> boids = new List<Boid>();

    void Start()
    {
        for (int i = 0; i < boidCount; i++)
        {
            Vector3 spawnPosition = transform.position + (Vector3)Random.insideUnitCircle * spawnRadius;
            Boid boid = Instantiate(boidPrefab, spawnPosition, Quaternion.identity);
            boids.Add(boid);
        }
    }

    public List<Boid> GetNeighbors(Boid boid, float radius)
    {
        List<Boid> neighbors = new List<Boid>();
        foreach (var other in boids)
        {
            if (other != boid && Vector3.Distance(boid.transform.position, other.transform.position) <= radius)
            {
                neighbors.Add(other);
            }
        }
        return neighbors;
    }
}