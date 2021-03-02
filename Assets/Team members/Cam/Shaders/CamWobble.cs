using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamWobble : MonoBehaviour
{
	public Renderer renderer;
	public Gradient gradient;
	NetworkManager  networkManager;

	public float amount;

    // Start is called before the first frame update
    void Start()
    {
		networkManager = FindObjectOfType<NetworkManager>();


		renderer.material.SetColor("_colour", Color.blue);
    }

	void Update()
	{
		
	}

	void DoSomething()
	{
		Debug.Log("LAME");
	}

	public virtual void DoThingToOverride()
	{
		Debug.Log("I'm a base class!");
	}
}

class AnothingThing : CamWobble
{
	public override void DoThingToOverride()
	{
		base.DoThingToOverride();
		
		Debug.Log("I'm an overridden function");
	}
}