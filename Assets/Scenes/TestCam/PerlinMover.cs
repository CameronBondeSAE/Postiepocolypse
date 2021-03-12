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
		transform.position = startingPosition + new Vector3(Mathf.PerlinNoise(Time.time * timeScale, startingPosition.x) * scale.x, Mathf.PerlinNoise(Time.time * timeScale, startingPosition.y) * scale.y, Mathf.PerlinNoise(Time.time * timeScale, startingPosition.z) * scale.z);
	}
}
