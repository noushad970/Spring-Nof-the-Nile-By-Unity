using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject apple, banana, orange, pear, pineapple;
    int randomVal;
    private void Awake()
    {
        spawnRandomFruits();
    }
    void spawnRandomFruits()
    {
        randomVal = Random.Range(0, 5);
        if(randomVal == 0 )
        {
            apple.SetActive(true);
            pineapple.SetActive(false);
            pear.SetActive(false);
            banana.SetActive(false);
            orange.SetActive(false);
        }
        else if (randomVal == 1)
        {
            apple.SetActive(false);
            pineapple.SetActive(true);
            pear.SetActive(false);
            banana.SetActive(false);
            orange.SetActive(false);
        }
        else if(randomVal == 2)
        {
            apple.SetActive(false);
            pineapple.SetActive(false);
            pear.SetActive(true);
            banana.SetActive(false);
            orange.SetActive(false);
        }
        else if(randomVal==3)
        {
            apple.SetActive(false);
            pineapple.SetActive(false);
            pear.SetActive(false);
            banana.SetActive(true);
            orange.SetActive(false);
        }
        else
        {
            apple.SetActive(false);
            pineapple.SetActive(false);
            pear.SetActive(false);
            banana.SetActive(false);
            orange.SetActive(true);
        }
    }
}
