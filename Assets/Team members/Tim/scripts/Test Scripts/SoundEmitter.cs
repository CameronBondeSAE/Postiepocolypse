using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimPearson
{
    public class SoundEmitter : MonoBehaviour
    {
        private SphereCollider soundLevel1;
        private SphereCollider soundLevel2;
        private SphereCollider soundLevel3;
        public float soundRadius1;
        public List<GameObject> listOfEars = new List<GameObject>();
        private Ears ears;

        private void Awake()
        {
            soundLevel1 = gameObject.AddComponent<SphereCollider>();
            soundLevel1.isTrigger = true;
            soundRadius1 = 10;
            ears = GetComponent<Ears>();
        }

        private void Update()
        {
            soundLevel1.radius = soundRadius1;
        }

        private void OnTriggerEnter(Collider other)
        {
            ears = other.GetComponent<Ears>();
            if (ears)
            {
                listOfEars.Add(ears.gameObject);
                //ears = null;
            }
        }

        private void OnTriggerExit(Collider soundLevel1)
        {
            listOfEars.Remove(ears.gameObject);
        }

        public void EmitSound(Vector3 sourcePosition)
        {
            foreach (var ears in listOfEars)
            {
                this.ears.Hearing(sourcePosition);
            }
        }
    }
}

