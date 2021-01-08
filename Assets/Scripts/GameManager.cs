using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; set; }
    

    

    //Ship prefab to spawn ship
    public GameObject shipPrefab;
    public GameObject truckPrefab;

    public Transform spawnPointS;
    public Transform spawnPointT;

    public List<Transform> WayPointsS = new List<Transform>();
    public List<Transform> WayPointsT = new List<Transform>();

    public int CollidersCount;
    public int CollidersCountOnSpreader;

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

    public void SpawnNewShip()
    {

        ShipMovement shipMovement = Instantiate(shipPrefab, spawnPointS.position, shipPrefab.transform.rotation).GetComponent<ShipMovement>();
        shipMovement.wayPointList = WayPointsS.ToArray();
    }

    public void SpawnNewTruck()
    {
        TruckMovement truckMovement = Instantiate(truckPrefab, spawnPointT.position, truckPrefab.transform.rotation).GetComponent<TruckMovement>();
        truckMovement.wayPointList = WayPointsT.ToArray();
        CollidersCount = 0;
    }
}