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

        private void Awake()
        {
            soundLevel1 = gameObject.AddComponent<SphereCollider>();
            soundLevel1.isTrigger = true;
            soundRadius1 = 10;
        }

        private void Update()
        {
            soundLevel1.radius = soundRadius1;
        }

        private void OnTriggerEnter(Collider soundLevel1)
        {
            Ears ears = soundLevel1.GetComponent<Ears>();
            if (ears)
            {
                ears.Hearing(soundLevel1.transform.position);
                listOfEars.Add(soundLevel1.gameObject);
            }
        }

        private void OnTriggerExit(Collider soundLevel1)
        {
            listOfEars.Remove(soundLevel1.gameObject);
        }
    }
}

