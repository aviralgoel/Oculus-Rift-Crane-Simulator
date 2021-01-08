using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance {get; set;}

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

    public Vector2 playerMovement;
    public Vector2 joystickMovement;
    public GameObject redJoystick;

    public float walkingSpeed;
    public float rotateSpeed = 2.5f;
    public Transform CenterEyeView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        //if JoyStick RedGrabbed
        
        //MoveJoystick1

        // if Joystick2 Grabbed
        //MoveJoystick2

        //if nothing is grabbed 
        MovePlayer();


    }
    
    private void MovePlayer()
    {
        playerMovement = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        Vector3 forward = CenterEyeView.forward;
        Vector3 right = CenterEyeView.right;

        forward.y = 0; right.y = 0;

        transform.position += forward * walkingSpeed * playerMovement.y * Time.deltaTime;
        transform.position += right * walkingSpeed * playerMovement.x * Time.deltaTime;
    }
    public void MoveRedJoystick()
    {
        joystickMovement = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);


        redJoystick.transform.Rotate(new Vector3(joystickMovement.y * rotateSpeed, 0, -joystickMovement.x * rotateSpeed));



    }

}
