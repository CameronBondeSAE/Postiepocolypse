using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZachFrench
{
    public class SmellEmitter : MonoBehaviour
    {

        public GameObject smellObject;
        public float smellTimer = 0;
        public float smellCreate = 10;
        
        // Start is called before the first frame update
        void Start()
        {

        }

        //We use a smell timer that counts to 10 seconds
        //after that we run the function to create a smell object 
        //then reset smellTimer to 0
        void Update()
        {
            smellTimer += Time.deltaTime;
            if (smellTimer >= smellCreate)
            {
                CreatingSmell();
                smellTimer = 0f;
            }
        }

        
        //when called will create an empty game object with the smell code in it
        private void CreatingSmell()
        {
            Instantiate(smellObject, transform.position, Quaternion.Euler(0, 0, 0));
        }


    }
}
