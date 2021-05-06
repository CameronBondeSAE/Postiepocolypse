using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRotation : MonoBehaviour
{

	// Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
	void LateUpdate()
	{
		transform.rotation = Quaternion.identity;
	}
}
