using System;
using UnityEngine;

namespace JonathonMiles
{ 
    public class Interactable : MonoBehaviour 
    {
        public float radius = 3f;
        public Transform interactionTransform;
        public Transform player;
        
        public virtual void Interact ()
        {
            //code can be overwritten here for each interactable item to have unique functions
        }

        private void Update()
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
            }
        }

        void OnDrawGizmosSelected ()
        {
            if (interactionTransform == null)
                interactionTransform = transform;

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(interactionTransform.position, radius);
        }

    }
}
