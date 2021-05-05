using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UIElements;

namespace RileyMcGowan
{
    public class FlareGun : MonoBehaviour
    {
        private GameObject instantiate;
        private Vector3 spawnLocation;
        private Vector3 flareDirection;
        private bool isCoroutineRunning;
        private Rigidbody currentFlareRigidbody;
        
        public GameObject objectToSpawn;
        [Tooltip("Is a flare ready.")]
        public bool flareAvailable;

        [Tooltip("Delay between flares. Expects 1-30.")]
        public int flareDelay = 5;

        [Tooltip("Force to fire flare. Expects 1-5.")]
        public int flareForce = 2000;

        [Tooltip("Changeable by other scripts.")]
        public int currentFlares = 1;

        [Tooltip("Height for flare to travel at max. Works at 100.")]
        public int flareHeight = 2000;
        
        [Tooltip("Flare Drag. Expects between 1-10.")]
        public int flareDecent = 10;

        public GameObject placeToSpawn;

        private GameObject cameraRef;
        
        private void Start()
        {
            StartCoroutine(FlareDelay());
            if (GetComponentInChildren<HDAdditionalCameraData>() != null)
            {
                cameraRef = GetComponentInChildren<HDAdditionalCameraData>().gameObject;
            }
        }

        void Update()
        {
            if (cameraRef == null && GetComponentInChildren<HDAdditionalCameraData>() != null)
            {
                cameraRef = GetComponentInChildren<HDAdditionalCameraData>().gameObject;
            }
            FireFlare();
            if (flareAvailable == true && isCoroutineRunning == true)
            {
                StopCoroutine(FlareDelay());
                isCoroutineRunning = false;
            }
        }

        public void FireFlare()
        {
            if (InputSystem.GetDevice<Keyboard>().digit2Key.isPressed && currentFlares > 0 && flareAvailable == true)
            {
                if (placeToSpawn != null)
                {
                    spawnLocation = placeToSpawn.transform.position;
                }
                else
                {
                    spawnLocation = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                }
                //Where to fire the flare
                instantiate = Instantiate<GameObject>(objectToSpawn, spawnLocation, cameraRef.transform.rotation); //Store our flare to influence
                currentFlareRigidbody = instantiate.GetComponent<Rigidbody>();
                StartCoroutine(DragController());
                currentFlareRigidbody.AddForce(cameraRef.transform.forward * flareForce, ForceMode.Impulse); //Force added to the flare
                currentFlares -= 1; //Remove a flare from inventory
                flareAvailable = false;
                StartCoroutine(FlareDelay());
            }
        }
        
        IEnumerator FlareDelay()
        {
            isCoroutineRunning = true;
            yield return new WaitForSeconds(flareDelay);
            flareAvailable = true;
            isCoroutineRunning = false;
        }
        IEnumerator DragController()
        {
            currentFlareRigidbody.drag = 1;
            yield return new WaitForSeconds(2);
            currentFlareRigidbody.drag = flareDecent;
        }
    }
}
