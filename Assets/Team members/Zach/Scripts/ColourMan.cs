using UnityEngine;

public class ColourMan : MonoBehaviour
{
    public Transform cam;
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    //public Rigidbody rb;

    public bool isGrounded;

    public float jumpForce = 2.0f;

    public Vector3 jump;

    public float gravity = 1f;

    public Vector3 gravityForce;

    public float maxSpeed;

    private CharacterController controller;

    private float lastSpeed;

    private float turnSmoothVelocity;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = 10f;
        maxSpeed = 20f;

        jump = new Vector3(0, jumpForce, 0);
    }


    // Update is called once per frame
    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0f, vertical).normalized;

        /*if (direction.magnitude >= 0.01f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f );

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }*/

        gravityForce = new Vector3(0, -gravity, 0);
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump");
            controller.Move(jump * speed * Time.deltaTime);
            isGrounded = false;
        }
        else if (!isGrounded)
        {
            controller.Move(gravityForce * gravity * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.W))
        {
            //Increase speed over time
            if (speed < maxSpeed)
                speed += 0.9f * Time.deltaTime;
            else if (Input.GetKeyDown(KeyCode.W))
                //Reset once key is released
                if (speed != lastSpeed)
                {
                    speed = 10;
                    lastSpeed = speed;
                }
        }
    }


    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }
}