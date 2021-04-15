using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZachFrench
{
    public class ColourManRotation : MonoBehaviour
    {
        public Transform cam;
        public float hori;
        public float verti;
        private new Vector3 directionCam;
        public float turnSmoothVelocity;
        public float turnSmoothTime;
        public Vector3 moveDir;

        // Start is called before the first frame update
        void Start()
        {
            turnSmoothTime = 0.01f;
        }

        // Update is called once per frame
        void Update()
        {
            hori = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            verti = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            directionCam = new Vector3(hori, 0f, verti).normalized;

            //if (directionCam.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(directionCam.x, directionCam.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                    turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        }
    }
}
