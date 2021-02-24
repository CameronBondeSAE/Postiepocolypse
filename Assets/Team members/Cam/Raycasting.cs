using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
	void Update()
	{
		RaycastHit hitinfo;
		hitinfo = new RaycastHit();

		Physics.Raycast(transform.position, Vector3.down, out hitinfo, 10f, 255, QueryTriggerInteraction.Ignore);

		// Only draw line if we hit something
		if (hitinfo.collider)
		{
			Debug.DrawLine(transform.position, hitinfo.point, Color.green);

			// Rigidbody r;
			// r.GetRelativePointVelocity()
		}
	}


}
