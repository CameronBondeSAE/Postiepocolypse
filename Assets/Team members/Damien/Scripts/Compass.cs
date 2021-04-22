using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject compassNeedle;

    // Update is called once per frame
    void Update()
    {
        compassNeedle.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
