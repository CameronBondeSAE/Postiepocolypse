using Anthill.AI;
using UnityEngine;

namespace Damien
{
    public class EntityIdle : AntAIState
    {
        public GameObject owner;
        public Vector3 scale     = Vector3.one;
        public float   timeScale = 1f;
        Vector3 startingPosition;

        private void Start()
        {
            startingPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            
                float x = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.x) * scale.x;
                float y = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.y) * scale.y;
                float z = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.z) * scale.z;

                transform.parent.position = startingPosition + new Vector3(x, y, z);
            
        }
    }
}