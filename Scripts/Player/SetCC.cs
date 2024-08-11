using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCC : MonoBehaviour
{
    
    public CharacterController controller;
    // Start is called before the first frame update
    void Awake()
    {
        controller.center = new Vector3(0, 0, 0.34f);
    }

    
}
