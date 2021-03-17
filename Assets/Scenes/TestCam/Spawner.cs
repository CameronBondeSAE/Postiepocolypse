using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Spawner : MonoBehaviour
{
	public GameObject prefab;
	public int        number;
	public float      range;
	public float    offset = 1f;

	// Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < number; i++)
		{
			Vector3 position = transform.position + new Vector3(Random.Range(-range, range), 100, Random.Range(-range, range));

			GameObject  newGo       = Instantiate(prefab, position, Quaternion.identity);
			PerlinMover perlinMover = newGo.GetComponent<PerlinMover>();

			if (perlinMover)
			{
				perlinMover.scale = new Vector3(Random.Range(10f, 100f), Random.Range(1f, 10f), Random.Range(10f, 100f));
			}

			RaycastHit hitInfo;
			Physics.Raycast(new Ray(position, Vector3.down), out hitInfo, 200f);
			if (hitInfo.collider)
			{
				newGo.transform.position = hitInfo.point + new Vector3(0,offset, 0);
			}
			else
			{
				Destroy(newGo);
			}
		}
    }
}
