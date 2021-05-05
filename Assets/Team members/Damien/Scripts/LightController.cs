using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;
    
    public bool flashOn;
    

    private void Start()
    {
       
        flashOn = false;
        
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
}