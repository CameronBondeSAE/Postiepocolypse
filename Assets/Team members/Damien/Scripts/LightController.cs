using Mirror;
using UnityEngine;

public class LightController : NetworkBehaviour
{
    public Light light;
    
    public bool flashOn;
    

    private void Start()
    {
        if (isClient)
        {
            flashOn = false;
            RpcFlash(flashOn);
        }
        
        
    }

    private void Update()
    {

        
        
            if (flashOn)
            {
                light.intensity = 200000000f;
                Debug.Log("Flash On");
                flashOn = false;
            }

            if (!flashOn)
            {
                light.intensity = 0.2f;
                //Debug.Log("Flash Off");
            }
        
            
    }

    void RpcFlash(bool flashEnabled)
    {
        flashOn = flashEnabled;
    }

    void IsOnOff()
    {
        flashOn = !flashOn;
        RpcFlash(flashOn);
    }
}