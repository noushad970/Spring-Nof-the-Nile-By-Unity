using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSection : MonoBehaviour
{
    public GameObject[] sections;
    public GameObject harborShoreSection;
    //public GameObject StartSection;
    float zPos;
    int rando, randomValue;
    int totalGeneralSection;
    bool creatingSection=false;
    bool firstTime;
    // Start is called before the first frame update
    void Start()
    {
        //  StartSection.SetActive(true);
        randomValue = UnityEngine.Random.Range(15, 25);
        totalGeneralSection = 0;
        firstTime=true;
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
        
        if (randomValue==totalGeneralSection && ScoreCount.isUnlockedShip)
        {
            if (firstTime)
            {
                zPos += 88;
                firstTime = false;
            }
            else { 
                zPos += 977; 
            }
            Instantiate(harborShoreSection, new Vector3(-0.2f, .8f, zPos), Quaternion.identity);
            
            creatingSection = false;
        }
        else {
            rando = UnityEngine.Random.Range(0, sections.Length);
            zPos += 88;
            totalGeneralSection += 1;
            Instantiate(sections[rando], new Vector3(-5.870299f, .8f, zPos), Quaternion.identity);
            creatingSection = false;
        }
    }
}
