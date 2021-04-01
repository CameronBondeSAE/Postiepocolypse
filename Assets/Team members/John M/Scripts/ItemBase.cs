using UnityEngine;

namespace JonathonMiles
{
    public class ItemBase : ScriptableObject
    {
        new public string    name = "Item Name";
        public     Sprite    icon;
        public     int       amount;
        public     bool      isConsumable;
        

        public virtual void Use()
        {
            //code to be overwritten for each items use
        }
        
        
    } 
}

