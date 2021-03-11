using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimPearson
{
    
public class Energy : MonoBehaviour
{
    [Range(0f,100f)]
    public float Amount;
    private bool isUsing = false;
    public float Regen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isUsing == true)
        {
            // Reduce energy by decreaseSpeed per second
            Amount -= Regen * Time.deltaTime;
        }

        if (isUsing == false)
        {
            Amount += Regen * Time.deltaTime;
        }
    }
}
}