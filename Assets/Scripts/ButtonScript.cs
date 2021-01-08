using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private float stayCount;
    // Start is called before the first frame update
    void Start()
    {
        stayCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (stayCount > 3f)
        {
            Destroy(gameObject);
        }
        else
        {
            stayCount = stayCount + Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        stayCount = 0f;
    }
}
