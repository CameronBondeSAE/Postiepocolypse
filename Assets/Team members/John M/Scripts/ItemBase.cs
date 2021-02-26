using UnityEngine;

namespace JonathonMiles
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class ItemBase : ScriptableObject
    {
        new public string name = "Item Name";
        public Sprite icon;
        public int amount;
        public bool isConsumable;
        public bool isCoin;

        public virtual void Use()
        {
            //code to be overwritten for each items use
        }
        
        
    } 
}

