using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(PlayerAndJoystickController.Instance.controlByJoystick)
        {
            RightJoystickControls();
            LeftJoystickControls();
        }
    }

    void RightJoystickControls()
    {
        //TutorialsControls();
        //If Right Joystick (Joystick 1) is Up on it's Y AXIS
        if (Input.GetAxis("RJoystickY") > 0.5f)
        {
            PlayerAndJoystickController.Instance.MoveCraneFront(-1);
        }
        //If Right Joystick (Joystick 1) is Down on it's Y AXIS
        if (Input.GetAxis("RJoystickY") < -0.5f)
        {
            PlayerAndJoystickController.Instance.MoveCraneFront(1);
        }
        //if (Input.GetButton("RJoystickB3"))
        //{
        //    print("We pressed button 3 on right joystick");
        //}
       
    }
    private void LeftJoystickControls()
    {
        //If Left Joystick (Joystick 2) is Up on it's Y AXIS
        if (Input.GetAxis("LJoystickY") > 0.5f)
        {
            PlayerAndJoystickController.Instance.MoveCraneUp(-1);
        }
        //If Left Joystick (Joystick 2) is Down on it's Y AXIS
        if (Input.GetAxis("LJoystickY") < -0.5f)
        {
            PlayerAndJoystickController.Instance.MoveCraneUp(1);
        }
    }
}
        