using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Zach
{


    public class CubeCar : MonoBehaviour
    {
        public Rigidbody Rigidbody;
        public float XSpeed;
        public float YSpeed;
        public Vector3 localVelocity;
        public float friction = 1;
        public Vector3 Origin;
        public float rayCastDistance = 10;
        public float maxForce = 2;
        public AnimationCurve springCurve;
        public Transform[] wheels;
        // Start is called before the first frame update

        void Start()
        {
            XSpeed = 1;
            YSpeed = 5;
        }

        // Update is called once per frame
        void Update()
        {
          Wheels();
          SpringForce();
        }


        void Wheels()
        {
            foreach (var wheel in wheels)
            {
                Vector3 wheelLocations = transform.InverseTransformPoint(wheel.transform.position);
                
                //Front and Back Driving
                if (InputSystem.GetDevice<Keyboard>().wKey.isPressed)
                {
                    Rigidbody.AddRelativeForce(0, 0, XSpeed);
                }

                if (InputSystem.GetDevice<Keyboard>().sKey.isPressed)
                {
                    Rigidbody.AddRelativeForce(0, 0, -XSpeed);
                }

                //Left and Right turning 
                if (InputSystem.GetDevice<Keyboard>().wKey.isPressed || InputSystem.GetDevice<Keyboard>().sKey.isPressed)
                {
                    if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
                    {
                        Rigidbody.AddRelativeTorque(0, -YSpeed, 0);
                    }

                    if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
                    {
                        Rigidbody.AddRelativeTorque(0, YSpeed, 0);
                    }
                }
            }
        }

        void SpringForce()
        {
            //Raycast for the height of car/spring 
            Origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            localVelocity = transform.InverseTransformDirection(Rigidbody.velocity);
            Rigidbody.AddRelativeForce(-localVelocity.x * friction, 0, 0);

            RaycastHit hitinfo;
            hitinfo = new RaycastHit();
            Physics.Raycast(transform.position, -transform.up, out hitinfo, rayCastDistance, 255,
                QueryTriggerInteraction.Ignore);
            
            //draw line when something is hit
            if (hitinfo.collider)
            {
                Debug.DrawLine(transform.position,hitinfo.point,Color.green);
            }

            Rigidbody.AddRelativeForce(0,maxForce - hitinfo.distance,0);

        }
    }
}
