using UnityEngine;

namespace TimPearson
{
    /// <summary>
    ///     Needs to have the Energy Script to function.
    ///     Also needs to have a rigidbody component
    /// </summary>
    public class Sprint : MonoBehaviour
    {
        public bool isBoosting;
        private Rigidbody rb;
        public float Boost;
        public Energy energy;
        public float Drain;


        // Start is called before the first frame update
        private void Start()
        {
            energy = GetComponent<Energy>();
            rb = gameObject.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (isBoosting)
            {
                // Reduce energy by the Drain amount per second
                energy.Amount -= Drain * Time.deltaTime;

                // double the move distance
                Boost = 50f;
                Boost = Mathf.Clamp(Boost, 0, 100f);
            }

            if (isBoosting == false) Boost = 0f;
            rb.AddRelativeForce(0, 0, Boost);
        }
    }
}