using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JonathonMiles
{
	public class PickUpItem : MonoBehaviour
	{
		public ItemBase item;

		// Pick up the item
		public void PickUp(GameObject owner)
		{
			Debug.Log("Picking up " + item.name);
			item.Pickup(owner);

			// TODO check networking
			Destroy(gameObject); // Destroy item from scene
		}
	}
}