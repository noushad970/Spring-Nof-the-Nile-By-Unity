using UnityEngine;

public class TreeGoesDown : MonoBehaviour
{
    public float rotationSpeed = 1f; // Speed of rotation
    public float zRotationSpeed = 30f; // Speed of rotation around the z-axis
    private bool isRotating = true;
    private Quaternion targetRotation;
    private Quaternion initialRotation;

    void Start()
    {
        // Set the initial rotation
        initialRotation = transform.rotation;

        // Calculate the target rotation
        targetRotation = Quaternion.Euler(-30.29f, 0f, -90f);
    }

    void Update()
    {


        if (TriggerCollisionDetection.isTreeFalling)
        {
            // Rotate towards the target rotation over time
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, zRotationSpeed * Time.deltaTime);

            this.transform.position = new Vector3(transform.position.x, 2.35f, transform.position.z);
            // Stop rotating once the target rotation is reached
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {

                transform.rotation = targetRotation;
                isRotating = false;
                TriggerCollisionDetection.isTreeFalling= false;
            }
        }
        
    }
}
