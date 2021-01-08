using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPosition : MonoBehaviour
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
        transform.position = other.transform.position;
        transform.rotation = other.transform.rotation;
    }
    private void OnTriggerExit(Collider other)
    {
        transform.position = Vector3.zero;
    }
}
