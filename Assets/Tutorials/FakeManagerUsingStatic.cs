using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeManagerUsingStatic : MonoBehaviour
{
	public static int numberOfCreatures;
	
    // Start is called before the first frame update
    void Start()
	{
		numberOfCreatures = 5215414;
	}

	public static void KillEverything()
	{
		numberOfCreatures = 0;
	}
}
