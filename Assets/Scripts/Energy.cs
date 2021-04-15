using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimPearson
{
    
public class Energy : MonoBehaviour
{
    public float Amount;
    private bool isUsing = true;
    public float Drain;
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
            // Reduce energy by the Drain value per second
            Amount -= Drain * Time.deltaTime;
        }

        if (isUsing == false)
        {
            Amount += Regen * Time.deltaTime;
        }
    }
}
}