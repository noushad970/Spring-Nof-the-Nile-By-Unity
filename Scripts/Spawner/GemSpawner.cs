using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gemObject;
    int rand;
    private void Awake()
    {
        rand = Random.Range(0, 5);
        if (rand == 3)
        {
            gemObject.SetActive(true);
        }
        else
        {
            gemObject.SetActive(false);
        }
    }
}
