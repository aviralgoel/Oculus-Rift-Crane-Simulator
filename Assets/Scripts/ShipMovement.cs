using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //List of points the ship will move to
    public Transform[] wayPointList;

    //Cotainer prefab to instantiate on ship
    public GameObject NewContainer;


    //List of ShipPrefabs to be spawned randomly on the ship
   // public GameObject[] containerPrefabs;

    //Waypoint Number of current target
    public int currentWayPointS = 0;
    //Speed of Ship Movement
    public float shipSpeed = 2f;

    //No. of containers to deplay on ship
    public float numOfContairners;
    // The amount of Gap to leave between placing each container on ship (has to be adjusted)
    public float heightBetweenContainers;
    public float widthBetweenContainers;
   
    //Ship floor position to place containers
    public Transform shipFloor;

    //Maximum numbers of Container
    public int maxNumOfContainers = 20;
    public int minNumOfContainers = 6;



    private void Start()
    {   
        //Start ship from waypoint 0 position
        transform.position = wayPointList[0].position;
        //Random number of containers for each ship
        numOfContairners = Random.Range(minNumOfContainers, maxNumOfContainers);
        //Add that many containers
        AddContainersOnShip();
    }
    // Update is called once per frame
    void Update()
    {
        //If ship not empty, move to port
        if (numOfContairners > 0)
        {
            MoveShipToPort();
        }
        //when ship empty, move to sea    
        else
        {
            MoveShipToSea();
            if (Vector3.Distance(transform.position, wayPointList[2].position) < 0.1f)
                DestroyThisShip();
        }
        
    }

    public void MoveShipToPort()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPointList[1].position, shipSpeed * Time.deltaTime);
    }

    public void MoveShipToSea()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPointList[2].position, shipSpeed * Time.deltaTime);
    }

    void AddContainersOnShip()
    {
        for (int j = 0; j <= 48; j += 12)
        {
            //For each container we add
            for (int i = 0; i < numOfContairners; i++)
            {
                // i/3 = The Row in which we place the container 
                // i%3 = The column in which we place the container
                GameObject con = Instantiate(NewContainer, shipFloor.position + new Vector3(j, (int)i / 5 * heightBetweenContainers, i % 5 * widthBetweenContainers), Quaternion.identity);
                //Set the container as child of ship
                con.transform.SetParent(transform);

            }
        }
       
        //for (int i = 0; i < numOfContairners; i++)
        //{
        //    // i/3 = The Row in which we place the container 
        //    // i%3 = The column in which we place the container
        //    GameObject con = Instantiate(NewContainer, shipFloor.position + new Vector3(12, (int)i / 3 * heightBetweenContainers, i % 3 * widthBetweenContainers), Quaternion.identity);
        //    //Set the container as child of ship
        //    con.transform.SetParent(transform);

        //}
        //for (int i = 0; i < numOfContairners; i++)
        //{
        //    // i/3 = The Row in which we place the container 
        //    // i%3 = The column in which we place the container
        //    GameObject con = Instantiate(NewContainer, shipFloor.position + new Vector3(24, (int)i / 3 * heightBetweenContainers, i % 3 * widthBetweenContainers), Quaternion.identity);
        //    //Set the container as child of ship
        //    con.transform.SetParent(transform);

        //}

    }
    public void DestroyThisShip()
    {
        GameManager.Instance.SpawnNewShip();
        Destroy(gameObject);
    }




}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ShipMovement : MonoBehaviour
//{
//    // put the points from unity interface
//    public Transform[] wayPointListS;

//    public int currentWayPointS = 0;
//    Transform targetWayPoint;

//    public float speed = 2f;

//    // Use this for initialization
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // check if we have somewere to walk
//        if (currentWayPointS < this.wayPointListS.Length)
//        {
//            if (targetWayPoint == null)
//                targetWayPoint = wayPointListS[currentWayPointS];

//            if (currentWayPointS != 2)
//            {
//                move();
//            }
//        }
//    }

//    void move()
//    {
//        // rotate towards the target
//        //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

//        // move towards the target
//        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

//        if (transform.position == targetWayPoint.position)
//        {
//            currentWayPointS++;
//            targetWayPoint = wayPointListS[currentWayPointS];
//        }
//    }
//}

