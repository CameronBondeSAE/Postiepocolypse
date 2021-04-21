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
        

        
        public override void Create(GameObject aGameObject)
        {
            startingPosition = transform.position;
            base.Create(aGameObject);
            owner = aGameObject;
            
        }

       

        public override void Enter()
        {
            base.Enter();
            float x = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.x) * scale.x;
            float y = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.y) * scale.y;
            float z = Mathf.PerlinNoise(Time.time * timeScale, startingPosition.z) * scale.z;

            transform.parent.position = startingPosition + new Vector3(x, y, z);

            if (owner.GetComponent<FOV>().listOfTargets.Count != 0)
            {
                Finish();
            }
        }
    }
}