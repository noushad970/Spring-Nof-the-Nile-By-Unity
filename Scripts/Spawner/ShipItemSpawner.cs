using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipItemSpawner : MonoBehaviour
{
    public GameObject shipItems1, shipItems2, shipItems3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerCollisionDetection.shipSpawn == 1)
        {
            if(shipItems1 != null)
            {

                shipItems1.SetActive(false);
            }
            if(shipItems2 != null)
            {

                shipItems2.SetActive(false);
            }
            if(shipItems3 != null)
            {

                shipItems3.SetActive(false);
            }
        }
        else
        {
            if (shipItems1 != null)
            {

                shipItems1.SetActive(true);
            }
            if (shipItems2 != null)
            {
                
            shipItems2.SetActive(true);
            }
            if (shipItems3 != null)
            {

                shipItems3.SetActive(true);
            }
        }
    }
}
