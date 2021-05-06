using Mirror;
using UnityEngine;

public class LightController : NetworkBehaviour
{
    public Light light;

    public bool flashOn = false;


    private void Update()
    {
        if (isClient)
        {
            RpcFlash();
        }
        
    }

    [ClientRpc]
    void RpcFlash()
    {
        if (isClient)
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
                Debug.Log("Flash Off");
            }
        }
        
    }
}