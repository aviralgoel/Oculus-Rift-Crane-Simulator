using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedJoystick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        print("We Touch Somethng");
        if (other.gameObject.tag == "Hand")
        {
            PlayerMovement.Instance.MoveRedJoystick();
            print("We Touch Hand");
            
            other.transform.position = transform.position;
        }
    }
}
