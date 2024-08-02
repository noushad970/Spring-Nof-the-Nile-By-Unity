using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDetectEnemy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("PlayerMachete") && (other.CompareTag("Hippo")|| other.CompareTag("Crocodile")))
        {
            Debug.Log("Collided");
        }
    }
    
}
