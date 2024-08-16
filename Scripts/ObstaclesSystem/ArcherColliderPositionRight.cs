using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherColliderPositionRight : MonoBehaviour
{
    BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.forwardSpeed <= 4)
        {
            col.center = new Vector3(col.center.x, col.center.y, -15f);
        }
        else if (PlayerController.instance.forwardSpeed <= 5)
        {
            col.center = new Vector3(col.center.x, col.center.y, -17f);
        }
        else if (PlayerController.instance.forwardSpeed <= 6)
        {
            col.center = new Vector3(col.center.x, col.center.y, -22f);
        }
        else if (PlayerController.instance.forwardSpeed <= 7)
        {
            col.center = new Vector3(col.center.x, col.center.y, -27f);
        }
        else
        {
            col.center = new Vector3(col.center.x, col.center.y, -32f);

        }
    }
}
