using UnityEngine;

public class TriggerCollisionDetection : MonoBehaviour
{
    public static bool createNewSection=false;
    public static bool destroyPreviousSection=false;
    public static bool isGetBoatItem=false;
    public static bool isDestroyBoat=false;
    public static bool isSnakeAttack = false;
    public static bool isVillageShore=false,isHarbourShore=false,isDeepDarkShore=false;
    public static bool isHitArrow = false;
    public static bool isCrocodileAttack = false;
    public static bool isHippoAttack = false;
    public static bool isMosquitoAttack=false;
    public static bool ableToAttack=false;
    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider has the tag "Player"
        if (other.CompareTag("Player") && this.CompareTag("CreateSection"))
        {
            createNewSection=true;
        }
        if (other.CompareTag("Player") && this.CompareTag("DestroyPreviousSection"))
        {
            destroyPreviousSection=true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Boat"))
        {
            isGetBoatItem = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles"))
        {
            isDestroyBoat = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("VillageShore"))
        {
            isVillageShore = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("HarborShore"))
        {
            isHarbourShore = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("DeepDarkShore"))
        {
            isDeepDarkShore = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("SnakeArea"))
        {
            isSnakeAttack = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Arrow"))
        {
            isHitArrow = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Crocodile"))
        {
            Debug.Log("Hit With Crocodile");
            isCrocodileAttack = true;
            ableToAttack = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Hippo"))
        {
            Debug.Log("Hit With Crocodile");
            isHippoAttack = true;
            ableToAttack=true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Mosquito"))
        {
            Debug.Log("Hit With Crocodile");
            isMosquitoAttack = true;
        }
        if (!this.CompareTag("SnakeArea") && !this.CompareTag("Crocodile") && !this.CompareTag("Hippo") && !this.CompareTag("Mosquito") )
        {
            Destroy(gameObject);
        }
    }
}
