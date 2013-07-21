using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoidControl : MonoBehaviour {

	public float minVelocity = 1;
	public float maxVelocity = 8;
	public int flockSize = 20;
	public float centerWeight = 1;
	public float velocityWeight = 1;
	public float separationWeight = 1;
	public float followWeight = 1;
	public float randomizeWeight = 1;
	
	public Boid prefab;
	public Transform target;
	
	internal Vector3 flockCenter;
	internal Vector3 flockVelocity;
	
	public List<Boid> boids = new List<Boid>();

	void Start()
	{
		for (int i = 0; i < flockSize; i++)
		{
			Boid boid = Instantiate(prefab, transform.position, transform.rotation) as Boid;
			boid.transform.parent = transform;
			boid.transform.localPosition = new Vector3(
							Random.value * collider.bounds.size.x,
							Random.value * collider.bounds.size.y,
							Random.value * collider.bounds.size.z) - collider.bounds.extents;
			boid.controller = this;
			boids.Add(boid);
		}
	}

	void Update()
	{
		Vector3 center = Vector3.zero;
		Vector3 velocity = Vector3.zero;
		foreach (Boid boid in boids)
		{
			center += boid.transform.localPosition;
			velocity += boid.rigidbody.velocity;
		}
		flockCenter = center / flockSize;
		flockVelocity = velocity / flockSize;
		}
}