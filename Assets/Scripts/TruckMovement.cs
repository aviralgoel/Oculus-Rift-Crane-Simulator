using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TruckMovement : MonoBehaviour
{
    // put the points from unity interface
    public Transform[] wayPointList;

    //Cotainer prefab to instantiate on ship
    //    public GameObject Truck;
    //Waypoint Number of current target for truck
    public int currentWayPointT = 0;

    //Speed of Truck Movement
    public float truckSpeed = 2f;
    public bool loaded = false;

    //public float turnSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        //For smooth turning
        //initalPos = wayPointList[0].position;
        //endPos = wayPointList[2].position;
        //Start ship from waypoint 0 position
        transform.position = wayPointList[0].position;
        loaded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!loaded)
        {
            MoveTruckToPort();
        }
        else
        {
            MoveTruckToFinish();
            if (Vector3.Distance(transform.position, wayPointList[2].position) < 0.1f)
                DestroyTruck(); ;
        }


        if (GameManager.Instance.CollidersCount == 2)
        {
            loaded = true;
        }
    }
    public void MoveTruckToPort()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPointList[1].position, truckSpeed * Time.deltaTime);
    }
    public void MoveTruckToFinish()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPointList[2].position, truckSpeed * Time.deltaTime);
    }
    public void DestroyTruck()
    {
        GameManager.Instance.SpawnNewTruck();
        print("Spawn!");
        Destroy(gameObject);
    }
}

//void OnTriggerExit(Collider other)
//{
//    if (other.gameObject.tag == ("Hook"))
//    {
//        print("Hook exit");
//        if (loaded == true)
//        {
//            print("leave");
//            hookLeaves = true;
//        }
//    }
//}
//void OnTriggerStay(Collider other)
//{
//    if (other.gameObject.tag == ("Loaded"))
//    {
//        print("Container loaded");
//        loaded = true;
//    }
//}
//Vector3 initalPos;
//Vector3 endPos;
//float yRotation;
//void RotateTruck()
//{
//    yRotation = Vector3.Angle(new Vector3(endPos.x, 0, endPos.z), new Vector3(initalPos.x, 0, initalPos.z));
//    Quaternion targetRotation = Quaternion.Euler(0, yRotation, 0);
//    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 20 * Time.deltaTime);
//}
//IEnumerator loading()
//{
//    yield return new WaitForSeconds(5);
//}
//void move()
//{
//    // rotate towards the target
//    //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);
//    //RotateTruck();
//    // move towards the target
//    transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);
//    if (transform.position == targetWayPoint.position)
//    {
//        currentWayPoint++;
//        targetWayPoint = wayPointList[currentWayPoint];
//    }
//}









