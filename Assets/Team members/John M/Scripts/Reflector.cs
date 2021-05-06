using UnityEngine;

public class Reflector : MonoBehaviour
{
    public int bounces;
    
   public void Update()
   {
       Vector3 initialPosition = transform.position;
       Vector3 initialDirection = transform.forward;
        
        for (int i = 0; i < bounces; i++)
        {
            Ray ray = new Ray(initialPosition, initialDirection);
            RaycastHit hitInfo = new RaycastHit();
            Physics.Raycast(ray, out hitInfo);
            Vector3 reflect = Vector3.Reflect(ray.direction, hitInfo.normal);
            if (hitInfo.collider != null)
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.green);
                initialPosition = hitInfo.point;
            }

            initialDirection = reflect;
        }
    
        
       

   
        
        
        
    }
}
