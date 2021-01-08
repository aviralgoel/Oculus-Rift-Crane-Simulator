using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TJoystickInput : MonoBehaviour
{
    bool f, b, u;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAndJoystickController.Instance.controlByJoystick)
        {
            RightJoystickControls();
            LeftJoystickControls();
        }
        //TutorialsControls();
    }

    void RightJoystickControls()
    {
        //TutorialsControls();
        //If Right Joystick (Joystick 1) is Up on it's Y AXIS
        if (Input.GetAxis("RJoystickY") > 0.5f)
        {
            PlayerAndJoystickController.Instance.MoveCraneFront(-1);
            f = true;
        }
        //If Right Joystick (Joystick 1) is Down on it's Y AXIS
        if ((Input.GetAxis("RJoystickY") < -0.5f) && f)
        {
            PlayerAndJoystickController.Instance.MoveCraneFront(1);
            b = true;
        }
        //if (Input.GetButton("RJoystickB3"))
        //{
        //    print("We pressed button 3 on right joystick");
        //}

    }
    private void LeftJoystickControls()
    {
        //If Left Joystick (Joystick 2) is Up on it's Y AXIS
        if ((Input.GetAxis("LJoystickY") > 0.5f) && b)
        {
            PlayerAndJoystickController.Instance.MoveCraneUp(-1);
            u = true;
        }
        //If Left Joystick (Joystick 2) is Down on it's Y AXIS
        if ((Input.GetAxis("LJoystickY") < -0.5f) && u)
        {
            PlayerAndJoystickController.Instance.MoveCraneUp(1);
            //print("LeftJoystickDown");
        }
    }

    void TutorialsControls()
    {
        if (f == false)
        {
            print("Spreader Forward");
        }
        if (f)
        {
            print("Spreader Backward");
        }
        if (b)
        {
            print("Spreader Down");
        }
        if (u)
        {
            print("Spreader Up");
        }
    }
}
