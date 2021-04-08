using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbours : MonoBehaviour
{
	public List<Transform> insideTrigger;
	
	void OnTriggerEnter(Collider other)
	{
		insideTrigger.Add(other.transform);
	}

	void OnTriggerExit(Collider other)
	{
		insideTrigger.Remove(other.transform);
	}
}
