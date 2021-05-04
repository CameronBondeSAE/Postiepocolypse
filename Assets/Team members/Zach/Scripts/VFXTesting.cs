using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXTesting : MonoBehaviour
{
    public VisualEffect visualEffect;
    public GradientSwitch stateSwitch;
    public enum GradientSwitch
    {
        Calm,
        Angry,
        LowEnergy
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        visualEffect.SetInt("SwitchGradient",(int)stateSwitch);
    }

    
}
