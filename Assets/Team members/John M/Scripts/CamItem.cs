using JonathonMiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CamItem", menuName = "Inventory/CamItem")]
public class CamItem : ItemBase
{
	public override void Use()
	{
		base.Use();
		
		Debug.Log("CamItem got USED!");
	}
}
