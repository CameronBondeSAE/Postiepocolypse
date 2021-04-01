using JonathonMiles;
using RileyMcGowan;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CamItem", menuName = "Inventory/CamItem")]
public class CamItem : ItemBase
{
	public Inventory Inventory;
	
	public override void Use(GameObject owner)
	{
		base.Use(owner);
		
		Debug.Log("CamItem got USED!");
		owner.GetComponent<Health>().DoHeal(100000);
	}

	public override void Pickup(GameObject owner)
	{
		base.Pickup(owner);
		
		Debug.Log("I'm being pickup up by : "+owner.name);
	}
}
