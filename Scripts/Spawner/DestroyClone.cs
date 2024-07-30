using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClone : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (TriggerCollisionDetection.destroyPreviousSection)
        {
            TriggerCollisionDetection.destroyPreviousSection = false;
            Destroy(gameObject);
        }
    }
}
