using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSection : MonoBehaviour
{
    public GameObject[] sections;
    //public GameObject StartSection;
    float zPos;
    bool creatingSection=false;
    // Start is called before the first frame update
    void Start()
    {
      //  StartSection.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!creatingSection && TriggerCollisionDetection.createNewSection)
        {
            creatingSection = true;
            generateSection();
          //  StartSection.SetActive(true);
            TriggerCollisionDetection.createNewSection = false;
        }
        
    }
    void generateSection()
    {

        zPos += 88;
        
        Instantiate(sections[0], new Vector3(-5.870299f, .8f, zPos), Quaternion.identity);
        creatingSection = false;
    }
}
