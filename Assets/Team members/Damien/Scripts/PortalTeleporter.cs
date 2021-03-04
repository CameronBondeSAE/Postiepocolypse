using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien
{
    public class PortalTeleporter : MonoBehaviour
    {
        public Transform player;

        public Transform reciever;

        private bool playerIsOverlapping = false;

        public float dotProduct;

        public Vector3 portalToPlayer;

        void Update()
        {
            portalToPlayer = player.position - transform.position;
            dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (playerIsOverlapping)
            {
                if (dotProduct < 0f)
                {
                    //check current rotation and compare to end portal rotation.
                    float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                    rotationDiff += 180f;
                    player.Rotate(Vector3.up, rotationDiff);

                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                    player.position = reciever.position + positionOffset;

                    playerIsOverlapping = false;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                playerIsOverlapping = true;
                Debug.Log("Portal ON");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                playerIsOverlapping = false;
                Debug.Log("Portal OFF");
            }
        }
    }
}