using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScoreManager : MonoBehaviour
{
	public int amount;

	public event Action<int> UpdateScoreEvent;
	
	// Update is called once per frame
	void Update()
	{
		if (Random.Range(0,1f)>0.96f)
		{
			amount = amount + 1;
			
			UpdateScoreEvent?.Invoke(amount);
		}
	}
}