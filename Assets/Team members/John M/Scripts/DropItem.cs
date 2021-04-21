using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JonathonMiles
{
    public class DropItem : MonoBehaviour
    {
        public ItemBase item;
        private Rigidbody rb;

        void Drop(GameObject owner)
        {
            Debug.Log("Dropping item - " + item.name);
            Instantiate(item.prefab, owner.transform.position, Quaternion.identity);
            
        }
        
    }
}

