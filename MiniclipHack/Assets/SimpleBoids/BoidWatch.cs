using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoidWatch : MonoBehaviour {

	public BoidControl boidController;

	void LateUpdate()
	{
		if (boidController)
		{
			transform.LookAt(boidController.flockCenter + boidController.transform.position);
		}
	}
}
