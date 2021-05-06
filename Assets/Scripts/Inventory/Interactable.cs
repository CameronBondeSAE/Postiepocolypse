using System;
using UnityEngine;

namespace JonathonMiles
{ 
    public class Interactable : MonoBehaviour
	{
		public ItemBase item;
		
        public void Interact(GameObject owner)
		{
			item.Use(owner);
			if (item.isConsumable)
			{
				Destroy(this.gameObject);
			}
		}
	}
}
