using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class CreatureManager : MonoBehaviour
    {
        public List<CreatureBase[]> creatures;
        public int creatureAmountInScene;
        
        static CreatureManager instance;
        
        public static CreatureManager Instance
        {
            get
            {
                GameObject go = new GameObject("Creature Manager");
                instance = go.AddComponent<CreatureManager>();
                return instance;
            }
        }
        
        void Awake()
        {
            //checking to see if there is a manager already there
            if (instance == null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            instance = this;
            //won't delete, continue to next scene
            DontDestroyOnLoad(this.gameObject);
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            // creatures.AddRange();
            creatureAmountInScene = creatures.Count;
        }
    }
}
