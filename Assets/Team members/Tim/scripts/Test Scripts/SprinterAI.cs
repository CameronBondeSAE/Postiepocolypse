using Anthill.AI;
using UnityEngine;
using ZachFrench;

namespace TimPearson
{
    public class SprinterAI : MonoBehaviour
    {
        public PatrolManager target;
        public AntAIAgent antAIAgent;
        public Rigidbody rb;
        public LayerMask RaycastHitLayer;
        private Sprint sprint;
        public PatrolPoint currentTarget;
        public bool rayOn = true;
        public Damage damage;
        public float knockbackMultiplier;
       

        // Start is called before the first frame update
        private void Start()
        {
            if (!(antAIAgent is null)) antAIAgent.SetGoal("At Position");
            sprint = GetComponent<Sprint>();
            target = FindObjectOfType<PatrolManager>();
            rayOn = true;
            
        }

        // Update is called once per frame
        private void Update()
        {
            sprintRay();
            KnockBack();
        }
        public void sprintRay()
        {
            if (rayOn == true)
            {
                if (target != null)
                {
                    var ray = new Ray(transform.position, transform.forward);
                    RaycastHit raycastBoost;
                    if (Physics.Raycast(ray, out raycastBoost, 500, RaycastHitLayer))
                    {
                        Debug.DrawLine(ray.origin, raycastBoost.point, Color.green);
                        sprint.isBoosting = true;
                    }
                    else
                    {
                        Debug.DrawLine(transform.position, currentTarget.transform.position);
                        sprint.isBoosting = false;
                    }
                }
            }
            
        }

        public void KnockBack()
        {
            if (damage.inCollider !=null)
            {
                foreach (GameObject obj in damage.inCollider)
                {
                    obj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(50,0,100)*knockbackMultiplier);
                }
            }
        }
    }
}