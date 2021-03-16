using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien
{
    public class PortalCamera : MonoBehaviour
    {
        /*There should be two instances of this script in the scene for each portal pair
         Cameras A and B should be each centered at the two portals
         View from camera A will be seen on Portal B and vis versa
         */
        public Transform playerCamera; //This is the camera that is on the player object
        public Transform thisPortal; //This is the portal that the camera is currently on
        public Transform otherPortal; //This is the other portal

        // Update is called once per frame
        void LateUpdate()
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            transform.position = thisPortal.position + playerOffsetFromPortal;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(thisPortal.rotation, otherPortal.rotation);

            Quaternion portalRotationalDifference =
                Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }
}