using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class MathsExperiments : MonoBehaviour
{
	[SerializeField]
	int numberOfBounces = 5;

	Vector3    hitPosition;
	Vector3    reflectedDirection;
	Ray        ray;
	float      maxDistance;
	RaycastHit hitInfo;
	bool       raycast;

	// List<Vector3> hitInfoPoint;
	Vector3[] hitInfoPoint;


	void Start()
	{
		maxDistance = 99999f;
		ray         = new Ray();

		// hitInfoPoint = new List<Vector3>(numberOfBounces);
		hitInfoPoint = new Vector3[numberOfBounces];
	}

	void Update()
	{
		hitPosition        = transform.position;
		reflectedDirection = transform.forward;
		
		Array.Clear(hitInfoPoint, 0, numberOfBounces);
		for (int i = 0; i < numberOfBounces; i++)
		{
			if (!ShootRay(hitPosition, reflectedDirection, out hitPosition, out reflectedDirection, i))
			{
				break;
			}
		}

		// for (int bounce = 0; bounce < numberOfBounces - 1; bounce++)
		// {
			// Debug.DrawLine(hitInfoPoint[bounce], hitInfoPoint[bounce + 1], new Color(0, 1f - (float) bounce / numberOfBounces, 0), 0, true);
			// Debug.DrawLine(hitInfoPoint[bounce], hitInfoPoint[bounce + 1]);
		// }
	}

	bool ShootRay(Vector3 origin, Vector3 direction, out Vector3 _hitPosition, out Vector3 _reflectedDirection, int bounce)
	{
		ray.origin    = origin;
		ray.direction = direction;

		raycast = Physics.Raycast(ray, out hitInfo, maxDistance);
		if (raycast)
		{
			// hitInfoPoint[bounce] = hitInfo.point; // Debug draw caching
			Debug.DrawLine(origin, hitInfo.point);
			_hitPosition         = hitInfo.point;
			_reflectedDirection  = Vector3.Reflect(direction, hitInfo.normal);
			return true;
		}
		else
		{
			_hitPosition        = Vector3.zero;
			_reflectedDirection = Vector3.zero;
			return false;
		}
	}
}