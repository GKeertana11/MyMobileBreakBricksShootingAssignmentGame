using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationWithInputTouch : MonoBehaviour
{
    #region PRIVATE VARIABLES
  private Vector3 firstpoint; //Starting touch position
  private Vector3 secondpoint;//last touch position after touch movement
  private float xAngle= 0.0f; //angle for axes x for rotation
  private float xAngTemp= 0.0f; //temp variable for angle
  private Vector2 movement;
    #endregion


    #region PUBLIC VARIABLES
    #endregion

    #region MONOBEHAVIOUR METHODS
    // Start is called before the first frame update
    void Start()
    {
        xAngle = 0.0f;
        
        this.transform.rotation = Quaternion.Euler(0.0f, ((float)xAngle), 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)//To find out no of touches greater than 0 or not.
        {
            Touch touch = Input.touches[0];//Need to find out no of touches on the screen. If there are more no of touches, need to call array.

           
            if (Input.GetTouch(0).phase == TouchPhase.Began)//Checking if touch phase is at began phase.
            {
                movement = Vector2.zero;//Made movement to zero.
                firstpoint = Input.GetTouch(0).position;//saving position of starting touch.
                xAngTemp = xAngle;
               
            }
           
            if (Input.GetTouch(0).phase == TouchPhase.Moved)//Checking if finger is moved on screen.
            {
               // movement=movement+ touch.deltaPosition;//Calculation the distance of movement.
                secondpoint = Input.GetTouch(0).position;//saving position of last touch.
                
                xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;//For screen width rotating camera on 180 degrees. 
               
                
                this.transform.rotation = Quaternion.Euler(0.0f, xAngle, 0.0f);//Rotating camera around Y-axis using xAngle.
            }
        }
    }
}
#endregion

#region PUBLIC METHODS
#endregion

#region PRIVATE METHODS
#endregion
