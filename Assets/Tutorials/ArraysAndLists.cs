using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
	public bool   isBlocked;
	public Color  colour;
	public string type;
}

public class ArraysAndLists : NetworkBehaviour
{
	public bool    boolTest;
	public bool[]  boolsTest;
	public bool[,] bool2DArrayTest;

	public Node[,]    nodes2D;
	public GameObject thingToSpawn;

	// Start is called before the first frame update
	void Start()
	{
		nodes2D[0, 0]           = new Node();
		nodes2D[0, 0].colour    = Color.red;
		nodes2D[0, 0].isBlocked = true;


		Debug.Log(boolsTest[0]);
		Debug.Log(bool2DArrayTest[1919, 1079]);

		GameObject newGO = Instantiate(thingToSpawn, Vector3.zero, Quaternion.identity);
		NetworkServer.Spawn(newGO);
	}

	// Update is called once per frame
	void Update()
	{
	}
}