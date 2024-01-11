using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ftnrjgnkrk4m : MonoBehaviour
{
    private float y;
      
       public float speedOne = 0f; 
       public float speedMax = 80f; 
       public float speedMin = -20f; 
       public float speedUpA = 4f; 
       public float speedDownS = 6.29f; 
       public float speedTend = 3f; 
       public float speedBack = 2f; 
      
      void Update()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
        if (Input.GetKey(KeyCode.W) && speedOne < speedMax)
       {
          speedOne = speedOne + Time.deltaTime * speedUpA;
       }
       
       if (Input.GetKey(KeyCode.S) && speedOne > 0f)
      {
         speedOne = speedOne - Time.deltaTime * speedDownS;
      }
     
      if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne > 0f)
      {
         speedOne = speedOne - Time.deltaTime * speedTend;
      }
      if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && speedOne < 0f)
      {
        speedOne = speedOne + Time.deltaTime * speedTend;
      }

      
      if (Input.GetKey(KeyCode.S) && speedOne > speedMin && speedOne<=0)
      {
        speedOne = speedOne - Time.deltaTime * speedBack;
      }

        
      if (Input.GetKey(KeyCode.Space) && speedOne != 0)
      {
        speedOne = Mathf.Lerp(speedOne, 0, 0.4f);
        if (speedOne < 5) speedOne = 0;
       }
      transform.Translate(Vector3.forward * speedOne * Time.deltaTime);
     
       if(speedOne>1f||speedOne<-1f)
       {
           y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
           transform.Rotate(0, y, 0);
       }
    
       /* if (transform.eulerAngles.z != 0)
       {
           transform.eulerAngles = new Vector3(transform.eulerAngles.x, t 
           ransform.eulerAngles.y, 0);
       }*/
     }

}
