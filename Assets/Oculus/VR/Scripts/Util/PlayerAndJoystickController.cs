using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAndJoystickController : MonoBehaviour
{
    public static PlayerAndJoystickController Instance { get; set; }

    public bool controlByJoystick = true;

    public float walkingSpeed;
    public Transform CenterEyeView;
    public Transform player;
    public Transform hook;
    public Transform crane;
    public float craneSpeed;
    public float hookForwardsLimit;     // the furthest forward the hook can be moved
    public float hookBackwardsLimit;    // the furthest backwards the hook can be moved
    public float hookRaiseLimit;        // the highest the hook can be raised
    public float hookLowerLimit;        // the lowest the hook can be lowered
    public float craneForwardsLimit;     // the furthest forward the crane can be moved
    public float craneBackwardsLimit;    // the furthest backwards the cane can be moved

    //Action of boolean type, which will be invoked by MoveCraneUp() based on angle values of joystick
    // True -> Increase Rope, False -> Decrease rope
    public Action<bool> RopeSize;

    Vector2 playerMovement;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update

    public void MovePlayer()
    {
        playerMovement = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        Vector3 forward = CenterEyeView.forward;
        Vector3 right = CenterEyeView.right;

        forward.y = 0; right.y = 0;

        player.transform.position += forward * walkingSpeed * playerMovement.y * Time.deltaTime;
        player.transform.position += right * walkingSpeed * playerMovement.x * Time.deltaTime;
    }
    public void MoveCraneFront(float speed)
    {
        hook.transform.position += new Vector3(0, 0, speed * craneSpeed * Time.deltaTime);
    }

    public void MoveCraneUp(float angleUp)
    {
        // Hook down
        if (angleUp == 1)
        {
            // print("Front");
            //if (hook.transform.localPosition.y > hookLowerLimit)
            //{
            //    hook.transform.position += new Vector3(0, -1 * craneSpeed * Time.deltaTime, 0);
            //    print(hook.transform.localPosition.y);
            //}
            //Invoke Action to increase rope size
            if (RopeSize != null)
            {
                RopeSize.Invoke(true);
            }

        }
        //Hook up
        if (angleUp == -1)
        {
            //if (hook.transform.localPosition.y < hookRaiseLimit)
            //{
            //    print(hook.transform.localPosition.y);
            //    //hook.transform.position += new Vector3(0, 1 * craneSpeed * Time.deltaTime, 0);
            //    hook.transform.localPosition += Vector3.up * craneSpeed * Time.deltaTime;
            //}
            //Invoke Action to increase rope size
            if (RopeSize != null)
            {
                RopeSize.Invoke(false);
            }
            //print("bACK");
        }
    }
    public void MoveCraneRightSide()
    {
        // if(crane.transform.position.x < craneBackwardsLimit)
        crane.transform.position += new Vector3(-craneSpeed * Time.deltaTime, 0, 0);

    }
    public void MoveCraneLeftSide()
    {
        //if (crane.transform.position.x > craneForwardsLimit)
        crane.transform.position += new Vector3(craneSpeed * Time.deltaTime, 0, 0);
    }


}
