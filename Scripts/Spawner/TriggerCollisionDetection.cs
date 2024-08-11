using System.Collections;
using UnityEngine;

public class TriggerCollisionDetection : MonoBehaviour
{
    public static bool createNewSection=false;
    public static bool destroyPreviousSection=false;
    public static bool isGetCanoeItem=false, isGetRaftItem = false, isGetNutshellBoatItem = false, isGetFishingBoatItem = false,isGetShipItem=false, isPlayerWithBoat = false,playerisWithShip=false,ShipIsCollideWithObstacle=false;
    public static bool isDestroyBoat = false;
    public static bool isSnakeAttack = false,ArcherStartAttacking=false;
    public static bool isVillageShore=false,isHarbourShore=false,isDeepDarkShore=false;
    
    public static bool isCrocodileAttack = false;
    public static bool isHippoAttack = false;
    public static bool isMosquitoAttack=false, isCollideWithMosquitos = false;
    public static bool ableToAttack=false;
    public static bool isPiranhaDetectPlayer = false, isPiranhaHitWithPlayer = false;
    public static bool isHitFruitItem = false,isHitBambooItem=false,isHitWoodItem=false;
    public static bool isHitWithCoin = false,isHitWithGem=false,isHitWithHeart=false;
    public static bool isSinglePlayer = false, isTreeFalling=false;
    public static bool GameOver = false;
    public static bool isKilledWaterHippo=false, isKilledWaterSnake=false, isKilledWaterCroco=false;
    public static bool isSaved=false;
    public static int shipSpawn = 0;
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
        if (other.CompareTag("Player") && this.CompareTag("NutshellBoat"))
        {

            Debug.Log("Collide with NutshellBoat");
            isPlayerWithBoat = true;
            isGetNutshellBoatItem = true;
            playerisWithShip = false;
            isSinglePlayer = false;
        }
        
        if (other.CompareTag("Player") && this.CompareTag("FishingBoat"))
        {
            Debug.Log("Collide with FishgingBoat");
            isPlayerWithBoat = true;
            isGetFishingBoatItem = true;
            playerisWithShip = false;
            isSinglePlayer = false;
        }
        if (other.CompareTag("Player") && this.CompareTag("Raft"))
        {
            Debug.Log("Collide with Raft");
            isPlayerWithBoat = true;
            isGetRaftItem = true;
            playerisWithShip = false;
            isSinglePlayer = false;
        }
        if (other.CompareTag("Player") && this.CompareTag("Ship"))
        {
            playerisWithShip = true;
            isPlayerWithBoat = false;
            isGetShipItem = true;
            isSinglePlayer = false;
            shipSpawn = 1;
        }
        if (other.CompareTag("Player") && this.CompareTag("Canoe"))
        {

            Debug.Log("Collide with Canoe");
            isPlayerWithBoat = true;
            playerisWithShip = false;
            isGetCanoeItem = true;
            isSinglePlayer = false;
        }
        if(other.CompareTag("Player") && this.CompareTag("ArcherStartAttack"))
        {
            ArcherStartAttacking=true;
        }
        if(other.CompareTag("Player") && this.CompareTag("Arrow") && !PlayerController.playerSliding)
        {
            isCollideWithMosquitos=true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles") && playerisWithShip)
        {
            ShipIsCollideWithObstacle=true;
            ScoreCount.shipHealth -= 25;
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles") && playerisWithShip && ScoreCount.shipHealth<=0)
        {
            isDestroyBoat = true;
            GameOver = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles") && isPlayerWithBoat)
        {
            isDestroyBoat = true;
            isSinglePlayer = true;
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
        if (other.CompareTag("Player") && this.CompareTag("SnakeArea") && isSinglePlayer)
        {
            isSnakeAttack = true;
        }
        
        if (other.CompareTag("Player") && this.CompareTag("Crocodile") && isPlayerWithBoat)
        {
            Destroy(gameObject);
            isDestroyBoat = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Hippo") && isPlayerWithBoat)
        {
            Destroy(gameObject);
           isDestroyBoat = true;
        }
        //
        
        if (other.CompareTag("Player") && this.CompareTag("Crocodile") && isSinglePlayer)
        {
            Debug.Log("Hit With Crocodile");
            isCrocodileAttack = true;
            ableToAttack = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Hippo") && isSinglePlayer)
        {

            isHippoAttack = true;
            ableToAttack = true;
        }
        //
        if (other.CompareTag("Player") && this.CompareTag("Mosquito"))
        {
           
            isMosquitoAttack = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("AttackingMosquito"))
        {
            Debug.Log("Hit With Mosquito");
            isCollideWithMosquitos = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Piranha") && isSinglePlayer)
        {

            isPiranhaDetectPlayer = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("AttackingPiranha") && isSinglePlayer)
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
            Destroy(gameObject);
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
        if (!this.CompareTag("ArcherStartAttack") && !this.CompareTag("SnakeArea") && !this.CompareTag("Crocodile") && !this.CompareTag("Hippo") && !this.CompareTag("Mosquito") && !this.CompareTag("Piranha") && !this.CompareTag("AttackingPiranha") && !this.CompareTag("TreeObstacle") && !this.CompareTag("PlayerArrow") && !this.CompareTag("PlayerMachete") && !this.CompareTag("Snake"))
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
