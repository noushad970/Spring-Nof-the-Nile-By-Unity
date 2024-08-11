using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [Header("BoatItemSpawner")]
    public GameObject raft;
    public GameObject canoe, nutshell, fishingBoat, ship;
    
    // Start is called before the first frame update
    void Start()
    {
        raft.SetActive(false);
        canoe.SetActive(false);
        nutshell.SetActive(false);
        fishingBoat.SetActive(false);
        ship.SetActive(false);
        vehicleSpawner();
        ShipSpawn();
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ScoreCount.isUnlockedCanoe + " : " + ScoreCount.isUnlockedNutshell + " : " + ScoreCount.isUnlockedFishingBoat);

    }
    void vehicleSpawner()
    {
        int randomVal;
        if (!ScoreCount.isUnlockedCanoe && !ScoreCount.isUnlockedNutshell && !ScoreCount.isUnlockedFishingBoat)
        {
            //total vehicle 1
            //unlocked: raft
            randomVal= 0;
            if (randomVal == 0)
            {
                raft.SetActive(true);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
        }
        else if (ScoreCount.isUnlockedCanoe && !ScoreCount.isUnlockedNutshell && !ScoreCount.isUnlockedFishingBoat)
        {
            //total vehicle 2
            //unlocked: raft canoe
            randomVal = Random.Range(0, 2);
            if (randomVal == 0)
            {
                raft.SetActive(true);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
            if (randomVal == 1)
            {
                raft.SetActive(false);
                canoe.SetActive(true);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
        }
        else if (ScoreCount.isUnlockedCanoe && ScoreCount.isUnlockedNutshell && !ScoreCount.isUnlockedFishingBoat)
        {
            //total vehicle 3
            //unlocked: raft canoe nutshell
            randomVal = Random.Range(0, 3);
            if (randomVal == 0)
            {
                raft.SetActive(true);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
            if (randomVal == 1)
            {

                raft.SetActive(false);
                canoe.SetActive(true);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
            if (randomVal == 2)
            {

                raft.SetActive(false);
                canoe.SetActive(false);
                nutshell.SetActive(true);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
        }
        else if (ScoreCount.isUnlockedCanoe && !ScoreCount.isUnlockedNutshell && ScoreCount.isUnlockedFishingBoat)
        {
            //total vehicle 3
            //unlocked: raft canoe fishing
            randomVal = Random.Range(0, 3);
            if (randomVal == 0)
            {
                raft.SetActive(true);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
            if (randomVal == 1)
            {

                raft.SetActive(false);
                canoe.SetActive(true);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
            if (randomVal == 2)
            {

                raft.SetActive(false);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(true);
                ship.SetActive(false);
            }
        }
        else if (!ScoreCount.isUnlockedCanoe && ScoreCount.isUnlockedNutshell && ScoreCount.isUnlockedFishingBoat)
        {
            //total vehicle 3
            //unlocked: raft fishing nutshell
            randomVal = Random.Range(0, 3);
            if (randomVal == 0)
            {
                raft.SetActive(true);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
            if (randomVal == 1)
            {

                raft.SetActive(false);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(true);
                ship.SetActive(false);
            }
            if (randomVal == 2)
            {

                raft.SetActive(false);
                canoe.SetActive(false);
                nutshell.SetActive(true);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
        }
        else if (!ScoreCount.isUnlockedCanoe && !ScoreCount.isUnlockedNutshell && ScoreCount.isUnlockedFishingBoat)
        {
            //total vehicle 2
            //unlocked: raft fishing
            randomVal = Random.Range(0, 2);
            if (randomVal == 0)
            {
                raft.SetActive(true);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
            if (randomVal == 1)
            {

                raft.SetActive(false);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(true);
                ship.SetActive(false);
            }
        }
        else if (!ScoreCount.isUnlockedCanoe && ScoreCount.isUnlockedNutshell && !ScoreCount.isUnlockedFishingBoat)
        {
            //total vehicle 2
            //unlocked: raft nutshell
            randomVal = Random.Range(0, 2);
            if (randomVal == 0)
            {
                raft.SetActive(true);
                canoe.SetActive(false);
                nutshell.SetActive(false);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
            if (randomVal == 1)
            {
                raft.SetActive(false);
                canoe.SetActive(false);
                nutshell.SetActive(true);
                fishingBoat.SetActive(false);
                ship.SetActive(false);
            }
        }
        else if (ScoreCount.isUnlockedCanoe && ScoreCount.isUnlockedNutshell && ScoreCount.isUnlockedFishingBoat)
        {
            randomVal = Random.Range(0, 4);
            {
                if (randomVal == 0)
                {
                    raft.SetActive(true);
                    canoe.SetActive(false);
                    nutshell.SetActive(false);
                    fishingBoat.SetActive(false);
                    ship.SetActive(false);
                }
                else if (randomVal == 1)
                {

                    raft.SetActive(false);
                    canoe.SetActive(true);
                    nutshell.SetActive(false);
                    fishingBoat.SetActive(false);
                    ship.SetActive(false);
                }
                else if (randomVal == 2)
                {

                    raft.SetActive(false);
                    canoe.SetActive(false);
                    nutshell.SetActive(true);
                    fishingBoat.SetActive(false);
                    ship.SetActive(false);
                }
                else if (randomVal == 3)
                {

                    raft.SetActive(false);
                    canoe.SetActive(false);
                    nutshell.SetActive(false);
                    fishingBoat.SetActive(true);
                    ship.SetActive(false);
                }
            }
        }
        
    }
    void ShipSpawn()
    {
        if (TriggerCollisionDetection.shipSpawn == 0 && ScoreCount.isUnlockedShip && TriggerCollisionDetection.isHarbourShore)
        {

            raft.SetActive(false);
            canoe.SetActive(false);
            nutshell.SetActive(false);
            fishingBoat.SetActive(false);
            ship.SetActive(true);
        }
    }
}
