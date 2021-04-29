using UnityEngine;

namespace JonathonMiles
{
    public class ItemBase : ScriptableObject
    {
        new public string     name = "Item Name";
        // public     Sprite     icon;
        public     int        amount;
        public     bool       isConsumable;
		public     GameObject prefab;
        

        public virtual void Use(GameObject owner)
        {
            //code to be overwritten for each items use
        }

		public virtual void Pickup(GameObject owner)
		{
			
		}
	} 
}

