using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerGrab : MonoBehaviour
{
    public bool isGrabbed = false;
    bool first = false;
    Rigidbody rb;
    public Transform grabbedAnchor;

    //Array of container materials
    public Material[] containerMaterials;

    //Mass affects the stability of container when attached to the crane
    //public float massOfContainers = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.mass = massOfContainers;

        //Randomly assign a material to the spawned container
        transform.GetComponent<Renderer>().material = containerMaterials[Random.Range(0, 4)];

    }

    // Update is called once per frame
    void Update()
    {
        //Check if touched by correct object, and correct key is pressed. (Oculus Controller or Joystick)
        if (isGrabbed && ((OVRInput.Get(OVRInput.Button.Four) || (Input.GetButton("RJoystickB4"))))) 
        {
            isGrabbed = false;

            rb.useGravity = true;
            rb.isKinematic = false;
        }
        if(GameManager.Instance.CollidersCount ==2)
        {
            print("Container is in position");
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {   
        //Check if touched by correct object, and correct key is pressed. (Oculus Controller or Joystick)
        if (collision.gameObject.tag == "Grabber" &&  ((OVRInput.Get(OVRInput.Button.Two) || (Input.GetButton("RJoystickB3")))))
        {
            //print("We touch container with grabber");
            if (GameManager.Instance.CollidersCountOnSpreader == 2)
            {
                //print("both collider on position");
                isGrabbed = true;
                //first = true;
                rb.useGravity = false;
            }
            
        }
        if (GameManager.Instance.CollidersCount == 2)
        {
            transform.parent.SetParent(collision.transform, true);
        }

        //if (collision.gameObject.tag == "Container")

        ////if (other.gameObject.tag == "Container")
        //{
        //    print("Game Over");
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Container")
        //if (other.gameObject.tag == "Container")
        {
            print("Game Over");
}
    }

    private void LateUpdate()
    {
        if (isGrabbed)
        {
            transform.position = grabbedAnchor.position;
        }
       
    }
    //private void IncreaseMass()
    //{
    //    rb.mass = massOfContainers++;
    //}
    //private void DecreaseMass()
    //{
    //    rb.mass = massOfContainers--;
    //}

    ////private void OnTriggerStay(Collider other)
    ////{
    ////    //if (other.gameObject.tag == "Grabber" && (OVRInput.Get(OVRInput.Button.Start)))
    ////    //{
    ////    //    
    ////    //   
    ////    //}
    ////}

    //////private void OnCollisionStay(Collision collision)
    ////{
    ////    if (collision.gameObject.tag == "Grabber" && (OVRInput.Get(OVRInput.Button.Start)) )
    ////    {
    ////        isGrabbed = true; //first = true;
    ////        transform.parent.SetParent(collision.transform, true);
    ////    }
    ////}

    ////private void OnCollisonStay(Collider other)
    ////{
    ////    if(other.gameObject.tag == "Grabber" && (OVRInput.Get(OVRInput.Button.Four)) && !first)
    ////    {
    ////        isGrabbed = true; first = true;
    ////        transform.SetParent(other.transform);
    ////    }
    ////}

}
