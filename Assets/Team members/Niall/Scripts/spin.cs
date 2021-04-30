using System.Collections;
using System.Collections.Generic;
using ParadoxNotion.Design;
using UnityEngine;

public class spin : MonoBehaviour
{
    
    public float speed = 10;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,speed * Time.deltaTime,0);
    }
}
