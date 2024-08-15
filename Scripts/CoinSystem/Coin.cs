using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Coin : MonoBehaviour
{
   
    void Update()
    {
        transform.Rotate(80* Time.deltaTime, 0,0);
    }

}
