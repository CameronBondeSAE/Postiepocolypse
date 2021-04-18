using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class CreatureManager : MonoBehaviour
    {
        public List<CreatureBase> creatures;
        public int creatureAmountInScene;
        
        static CreatureManager instance;
        
        public static CreatureManager Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject go = new GameObject("Creature Manager");
                    instance = go.AddComponent<CreatureManager>();
                    return instance;
                }

                return instance;
            }
        }
        
        void Awake()
        {
            instance = this;
        }

        public void Start()
        {
            creatures.AddRange(FindObjectsOfType<CreatureBase>());
        }

        public void Update()
        {
            creatureAmountInScene = creatures.Count;

            foreach (CreatureBase creature in creatures)
            {
                creature.transform.SetParent(this.transform);
            }
        }
    }
}
