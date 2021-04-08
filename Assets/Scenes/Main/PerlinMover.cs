using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMover : MonoBehaviour
{
	public Vector3 scale     = Vector3.one;
	public float   timeScale = 1;
	Vector3        startingPosition;

	// Start is called before the first frame update
	void Start()
	{
		startingPosition = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		float x = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.x) * scale.x;
		float y = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.y) * scale.y;
		float z = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.z) * scale.z;

		transform.position = startingPosition + new Vector3(x, y, z);
	}
}