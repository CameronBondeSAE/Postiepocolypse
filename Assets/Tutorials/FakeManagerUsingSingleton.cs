using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeManagerUsingSingleton : MonoBehaviour
{
	public int numberOfCreatures;

	static FakeManagerUsingSingleton instance;

	public static FakeManagerUsingSingleton Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject go = new GameObject("FakeManagerUsingSingleton");
				instance = go.AddComponent<FakeManagerUsingSingleton>();
			}

			return instance;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		instance = this;


		numberOfCreatures = 54254;
	}

	public void KillEverything()
	{
		numberOfCreatures = 0;
	}
}