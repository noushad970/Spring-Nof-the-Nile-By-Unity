using System.Collections;
using UnityEngine;

public class TriggerCollisionDetection : MonoBehaviour
{
    public static bool createNewSection=false;
    public static bool destroyPreviousSection=false;
    public static bool isGetBoatItem=false, isPlayerWithBoat = false;
    public static bool isDestroyBoat=false;
    public static bool isSnakeAttack = false;
    public static bool isVillageShore=false,isHarbourShore=false,isDeepDarkShore=false;
    public static bool isHitArrow = false;
    public static bool isCrocodileAttack = false;
    public static bool isHippoAttack = false;
    public static bool isMosquitoAttack=false, isCollideWithMosquitos = false;
    public static bool ableToAttack=false;
    public static bool isPiranhaDetectPlayer = false, isPiranhaHitWithPlayer = false;
    public static bool isHitFruitItem = false,isHitBambooItem=false,isHitWoodItem=false;
    public static bool isHitWithCoin = false,isHitWithGem=false,isHitWithHeart=false;
    public static bool isSinglePlayer = true, isTreeFalling=false;
    public static bool GameOver = false;
    public static bool isKilledWaterHippo=false, isKilledWaterSnake=false, isKilledWaterCroco=false;
    
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
            isPlayerWithBoat = true;
            isGetBoatItem = true;
            isSinglePlayer = false;
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles") && isPlayerWithBoat)
        {
            isDestroyBoat = true;
            isSinglePlayer=true;
            isPlayerWithBoat = false;

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
          
            isHippoAttack = true;
            ableToAttack=true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Mosquito"))
        {
           
            isMosquitoAttack = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("AttackingMosquito"))
        {
            Debug.Log("Hit With Mosquito");
            isCollideWithMosquitos = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Piranha"))
        {

            isPiranhaDetectPlayer = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("AttackingPiranha"))
        {
            Debug.Log("Player is Hit with Piranhas");
            isPiranhaHitWithPlayer = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Fruit"))
        {
            Debug.Log("Player is Hit with Fruit");
            isHitFruitItem = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Bamboo"))
        {
            Debug.Log("Player is Hit with Bamboo");
            isHitBambooItem = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Gem"))
        {
            Debug.Log("Player is Hit with Gem");
            isHitWithGem = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Heart"))
        {
            Debug.Log("Player is Hit with Heart");
            isHitWithHeart = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Wood"))
        {
            Debug.Log("Player is Hit with Wood");
            isHitWoodItem = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("TreeObstacle") && isPlayerWithBoat)
        {
            Debug.Log("Collided with :");
            isDestroyBoat = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("TreeObstacle") && isSinglePlayer)
        {
            Debug.Log("GameOver");
            GameOver = true;
        }
        
        if (other.CompareTag("Player") && this.CompareTag("TreeFalling"))
        {
            isTreeFalling = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Coin"))
        {
            Debug.Log("Player is Hit with Coin");
            isHitWithCoin = true;
        }

        //player weapon enemy detection Start;
        if ((other.CompareTag("Hippo"))  &&  (this.CompareTag("PlayerMachete") || this.CompareTag("PlayerArrow")))
        {
            isKilledWaterHippo = true; 
            Destroy(gameObject);
        }
        if (other.CompareTag("Snake") && (this.CompareTag("PlayerMachete") || this.CompareTag("PlayerArrow")))
        {
            isKilledWaterSnake = true;
            Destroy(gameObject);
        }
        if ((other.CompareTag("Crocodile")) && (this.CompareTag("PlayerMachete") || this.CompareTag("PlayerArrow")))
        {
            isKilledWaterCroco = true;
            Destroy(gameObject);
        }

        //player weapon enemy detection end;
        if (!this.CompareTag("SnakeArea") && !this.CompareTag("Crocodile") && !this.CompareTag("Hippo") && !this.CompareTag("Mosquito") && !this.CompareTag("Piranha") && !this.CompareTag("AttackingPiranha") && !this.CompareTag("TreeObstacle") && !this.CompareTag("PlayerArrow") && !this.CompareTag("PlayerMachete") && !this.CompareTag("Snake"))
        {
            Destroy(gameObject);
        }
        if (this.CompareTag("Mosquito"))
        {
            StartCoroutine(DesMosquito());
        }
        if(this.CompareTag("Piranha") && PiranhaAttack.PiranhasHealth<=0)
        {
            isPiranhaHitWithPlayer = false;
            Destroy(gameObject);
        } 
        if((this.CompareTag("PlayerArrow") || this.CompareTag("PlayerMachete")))
        {
            StartCoroutine(DesArrayOrMachete());
        }
    }
    IEnumerator DesMosquito()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    IEnumerator DesArrayOrMachete()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
