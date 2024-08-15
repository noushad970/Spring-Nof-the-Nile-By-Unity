using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectArrowAndMachete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //player weapon enemy detection Start;
        if ((other.CompareTag("Hippo")) && (this.CompareTag("PlayerMachete") || this.CompareTag("PlayerArrow")))
        {
            TriggerCollisionDetection.isKilledWaterHippo = true;
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Snake") && (this.CompareTag("PlayerMachete") || this.CompareTag("PlayerArrow")))
        {
            TriggerCollisionDetection.isKilledWaterSnake = true;
            Destroy(this.gameObject);
        }
        if ((other.CompareTag("Crocodile")) && (this.CompareTag("PlayerMachete") || this.CompareTag("PlayerArrow")))
        {
            TriggerCollisionDetection.isKilledWaterCroco = true;
            Destroy(this.gameObject);
        }
        if(this.CompareTag("PlayerMachete") || this.CompareTag("PlayerArrow"))
        {
            StartCoroutine(des());
        }
    }
    IEnumerator des()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}
