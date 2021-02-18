using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeHealth : MonoBehaviour
{
	public int  amount;

	public void DoThingToHealth()
	{
		Debug.Log("Did thing to health");
	}

	public void TakeInParameter(int value)
	{
		Debug.Log("TakeInParameter : "+value);
	}

	public int ReturnParameter()
	{
		Debug.Log("ReturnParameter");
		return 5245415;
	}
	
	
	// Conditions using methods
	public bool ReturnBoolForConditionTest()
	{
		return true;
	}
}