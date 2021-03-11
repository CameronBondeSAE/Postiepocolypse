using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace RileyMcGowan
{
    public class FlareGun : MonoBehaviour
    {
        private GameObject instantiate;
        private Vector3 spawnLocation;
        private Vector3 flareDirection;

        public GameObject objectToSpawn;
        [Tooltip("Is a flare ready.")]
        public bool flareAvailable;

        [Tooltip("Delay between flares. Expected 1-30.")]
        public int flareDelay;

        [Tooltip("The distance to spawn the flare from player. Works at 2.")]
        public float spawnDifference;

        [Tooltip("Force to fire flare. Works at 5.")]
        public int flareForce;

        [Tooltip("Changeable by other scripts.")]
        public int currentFlares;

        [Tooltip("Height for flare to travel at max. Works at 100.")]
        public int flareHeight;

        private void Start()
        {
            StartCoroutine(FlareDelay());
        }

        void Update()
        {
            FireFlare();
        }

        public void FireFlare()
        {
            if (InputSystem.GetDevice<Keyboard>().fKey.isPressed && currentFlares > 0 && flareAvailable == true)
            {
                spawnLocation = new Vector3(transform.position.x, transform.position.y + spawnDifference, transform.position.z + spawnDifference / 2);
                flareDirection = new Vector3(transform.position.x, transform.position.y + flareHeight, transform.position.z); //Where to fire the flare
                instantiate = Instantiate<GameObject>(objectToSpawn, spawnLocation, this.transform.rotation); //Store our flare to influence
                instantiate.GetComponent<Rigidbody>().AddRelativeForce(flareDirection * flareForce); //Force added to the flare
                instantiate.GetComponent<ParticleSystem>().Play();
                currentFlares -= 1; //Remove a flare from inventory
                flareAvailable = false;
                StartCoroutine(FlareDelay());
            }
        }

        IEnumerator FlareDelay()
        {
            yield return new WaitForSeconds(flareDelay);
            flareAvailable = true;
        }
    }
}
