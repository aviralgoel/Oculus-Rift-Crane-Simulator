﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckContainer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Container")
        {
            GameManager.Instance.CollidersCount++;
            //True;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Container")
        {
            GameManager.Instance.CollidersCount--;
            //True;
        }

    }
}
