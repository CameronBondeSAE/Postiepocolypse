using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.VFX;
using ZachFrench;

namespace TimPearson
{
    public class SprinterAI : CreatureBase
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
        public VisualEffect visualEffect;
        public AudioSource audioSource;
       

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
            StartCoroutine(PlaySound());
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
                        visualEffect.SetVector4("Color",new Vector4(253,0,0,1));
                    }
                    else
                    {
                        if (currentTarget != null)
                        {
                            Debug.DrawLine(transform.position, currentTarget.transform.position);
                            sprint.isBoosting = false;
                            visualEffect.SetVector4("Color",new Vector4(15,250,0,1));
                        }
                        
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

        public IEnumerator PlaySound()
        {
            yield return new WaitForSeconds(2f);
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
    }
}