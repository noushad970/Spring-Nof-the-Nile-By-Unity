using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject snake, crocodileleft, hippoleft, piranhaleft;
    public GameObject  crocodilemiddle, hippomiddle, piranhamiddle;
    public GameObject crocodileright, hipporight, piranharight,swimLayer;
    
    int randomEnemyNum,randomPosition;
    private void Awake()
    {
        spawnWaterEnemy();
    }
    private void Update()
    {
        if (PlayerController.isFighting)
        {
            swimLayer.SetActive(false);
        }
        if (!PlayerController.isFighting)
        {
            swimLayer.SetActive(true);
        }
    }

    void spawnWaterEnemy()
    {
        randomEnemyNum = Random.Range(0, 4);
        randomPosition=Random.Range(0, 3);
        if(randomEnemyNum == 0 )
        {
            snake.SetActive(true);

            crocodileleft.SetActive(false);
            crocodilemiddle.SetActive(false);
            crocodileright.SetActive(false);
            
            hippoleft.SetActive(false);
            hipporight.SetActive(false);
            hippomiddle.SetActive(false);

            piranhaleft.SetActive(false);
            piranhamiddle.SetActive(false);
            piranharight.SetActive(false);
        }
        else if(randomEnemyNum == 1 )
        {
            snake.SetActive(false);
            hippoleft.SetActive(false);
            hipporight.SetActive(false);
            hippomiddle.SetActive(false);

            piranhaleft.SetActive(false);
            piranhamiddle.SetActive(false);
            piranharight.SetActive(false);

            if (randomPosition == 0)
            {
                crocodileleft.SetActive(true);
                crocodilemiddle.SetActive(false);
                crocodileright.SetActive(false);
            }
            else if (randomPosition == 1)
            {
                crocodileleft.SetActive(false);
                crocodilemiddle.SetActive(true);
                crocodileright.SetActive(false);
            }
            else if(randomPosition == 2)
            {
                crocodileleft.SetActive(false);
                crocodilemiddle.SetActive(false);
                crocodileright.SetActive(true);
            }
        }
        else if( randomEnemyNum == 2 )
        {
            snake.SetActive(false);
            piranhaleft.SetActive(false);
            piranhamiddle.SetActive(false);
            piranharight.SetActive(false);

            crocodileleft.SetActive(false);
            crocodilemiddle.SetActive(false);
            crocodileright.SetActive(false);

            if (randomPosition == 0)
            {
                hippoleft.SetActive(false);
                hipporight.SetActive(true);
                hippomiddle.SetActive(false);
            }
            else if (randomPosition == 1)
            {
                hippoleft.SetActive(false);
                hipporight.SetActive(false);
                hippomiddle.SetActive(true);
            }
            else if (randomPosition == 2)
            {
                hippoleft.SetActive(true);
                hipporight.SetActive(false);
                hippomiddle.SetActive(false);
            }
        }
        else if(randomEnemyNum==3)
        {
            snake.SetActive(false);

            crocodileleft.SetActive(false);
            crocodilemiddle.SetActive(false);
            crocodileright.SetActive(false);

            hippoleft.SetActive(false);
            hipporight.SetActive(false);
            hippomiddle.SetActive(false);
            if (randomPosition == 0)
            {
                piranhaleft.SetActive(true);
                piranhamiddle.SetActive(false);
                piranharight.SetActive(false);
            }
            else if (randomPosition == 1)
            {
                piranhaleft.SetActive(false);
                piranhamiddle.SetActive(true);
                piranharight.SetActive(false);
            }
            else if (randomPosition == 2)
            {
                piranhaleft.SetActive(false);
                piranhamiddle.SetActive(false);
                piranharight.SetActive(true);
            }
        }

    }
}
