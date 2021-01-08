using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
     
    
    // Update is called once per frame
    void Update()
    {

        if (PlayerAndJoystickController.Instance.controlByJoystick)
            InputByJoystick();
        else
            InputByOculus();


    }
    
    //Takes input from Oculus Rift Controller Buttons
    void InputByOculus()
    {
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            PlayerAndJoystickController.Instance.MovePlayer();
        }
        if (OVRInput.Get(OVRInput.Button.One))
        {
            PlayerAndJoystickController.Instance.MoveCraneRightSide();
        }
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            PlayerAndJoystickController.Instance.MoveCraneLeftSide();
        }
    }

    //Takes Input from Joystick Buttons
    void InputByJoystick()
    {
       
        if (Input.GetButton("RJoystickB6"))
        {
            PlayerAndJoystickController.Instance.MoveCraneRightSide();
        }
        if (Input.GetButton("RJoystickB5"))
        {
            PlayerAndJoystickController.Instance.MoveCraneLeftSide();
        }
    }
   

}
