using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinMover : NetworkBehaviour
{
	public Vector3 scale     = Vector3.one;
	public float   timeScale = 1;
	Vector3        startingPosition;
	float          randomStartingPerlinOffset;

	public override void OnStartServer()
	{
		base.OnStartServer();

		startingPosition = transform.position;

		// This is needed otherwise multiple ones will move exactly the same. So I pick a random starting point for the perlin values.
		randomStartingPerlinOffset = Random.Range(0, 10000f);
	}

	// Update is called once per frame
	void Update()
	{
		if (isServer)
		{
			float x = Mathf.PerlinNoise(randomStartingPerlinOffset + Time.time * timeScale, startingPosition.x) * scale.x;
			float y = Mathf.PerlinNoise(randomStartingPerlinOffset + Time.time * timeScale, startingPosition.y) * scale.y;
			float z = Mathf.PerlinNoise(randomStartingPerlinOffset + Time.time * timeScale, startingPosition.z) * scale.z;

			transform.position = startingPosition + new Vector3(x, y, z);
		}
	}
}