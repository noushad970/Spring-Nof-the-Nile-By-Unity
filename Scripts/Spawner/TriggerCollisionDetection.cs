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
    public static bool isPiranhaDetectPlayer = false, isPiranhaHitWithPlayer = false,AINinjeDetectEnemy=false;
    public static bool isHitFruitItem = false,isHitBambooItem=false,isHitWoodItem=false,isHitWithMeat=false,isHitWithFish=false;
    public static bool isHitWithCoin = false,isHitWithGem=false,isHitWithHeart=false;
    public static bool isSinglePlayer = false, isTreeFalling=false;
    public static bool GameOver = false;
    public static bool isKilledWaterHippo=false, isKilledWaterSnake=false, isKilledWaterCroco=false;
    public static bool isSaved=false;
    public static int shipSpawn = 0,shipHealth;

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
            AudioManager.instance.enablePowerUp.Play();
            isPlayerWithBoat = true;
            isGetNutshellBoatItem = true;
            playerisWithShip = false;
            isSinglePlayer = false;
        }
        
        if (other.CompareTag("Player") && this.CompareTag("FishingBoat"))
        {
            Debug.Log("Collide with FishgingBoat");
            AudioManager.instance.enablePowerUp.Play();
            isPlayerWithBoat = true;
            isGetFishingBoatItem = true;
            playerisWithShip = false;
            isSinglePlayer = false;
        }
        if (other.CompareTag("Player") && this.CompareTag("DetectEnemy"))
        {
            AINinjeDetectEnemy = true;
        }
        if(other.CompareTag("Arrow")&& (this.CompareTag("Hippo") || this.CompareTag("Crocodile") || this.CompareTag("SnakeEnemy")))
        {
            ScoreCount.totalMeatWhenEndRun += Random.Range(1, 5);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Player") && this.CompareTag("Raft"))
        {
            Debug.Log("Collide with Raft");
            isPlayerWithBoat = true;
            isGetRaftItem = true;
            AudioManager.instance.enablePowerUp.Play();
            playerisWithShip = false;
            isSinglePlayer = false;
        }
        if (other.CompareTag("Player") && this.CompareTag("Ship"))
        {
            playerisWithShip = true;
            isPlayerWithBoat = false;
            AudioManager.instance.enablePowerUp.Play();
            isGetShipItem = true;
            isSinglePlayer = false;
            shipSpawn = 1;
        }
        if (other.CompareTag("Player") && this.CompareTag("Canoe"))
        {

            Debug.Log("Collide with Canoe");
            AudioManager.instance.enablePowerUp.Play();
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
            AudioManager.instance.arrowHitSound.Play();
            AudioManager.instance.PlayerDamaged.Play();
            isCollideWithMosquitos=true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles") && playerisWithShip)
        {
            ShipIsCollideWithObstacle=true;
            AudioManager.instance.collideWithObstacle.Play();
            shipHealth -= 25;
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles") && playerisWithShip && shipHealth<=0)
        {
            Destroy(this.gameObject);
            AudioManager.instance.shipDestroy.Play();
            //isDestroyBoat = true;
            GameOver = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles") && isPlayerWithBoat)
        {
            Destroy(gameObject);
            AudioManager.instance.collideWithObstacle.Play();
            isDestroyBoat = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Obstacles") && isSinglePlayer)
        {
            Destroy(this.gameObject);
            GameOver = true;
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
            AudioManager.instance.PlaySnakeSound.Play();
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
        if (other.CompareTag("Player") && this.CompareTag("AttackingMosquito") && !WeaponReleaseSystem.isEnableSafariHat)
        {
            Debug.Log("Hit With Mosquito");
            AudioManager.instance.PlayerDamaged.Play();
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
            AudioManager.instance.hitItem.Play();
            isHitFruitItem = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Bamboo"))
        {
            InGameManager.instance.hitWithFruitParticle.Play();
            Debug.Log("Player is Hit with Bamboo");
            AudioManager.instance.hitItem.Play();
            isHitBambooItem = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Gem"))
        {
            Debug.Log("Player is Hit with Gem");
            AudioManager.instance.gemCollide.Play();
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
            InGameManager.instance.hitWithFruitParticle.Play();
            AudioManager.instance.hitItem.Play();
            isHitWoodItem = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Fish"))
        {
            Debug.Log("Player is Hit with Fish");
            isHitWithFish = true;/////////////
        }
        if (other.CompareTag("Player") && this.CompareTag("Meat"))
        {
            Debug.Log("Player is Hit with Meat");
            isHitWithMeat = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("TreeObstacle") && isPlayerWithBoat)
        {
            Debug.Log("Collided with :");
            AudioManager.instance.collideWithObstacle.Play();
            Destroy(gameObject);
            isDestroyBoat = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("TreeObstacle") && isSinglePlayer)
        {
            Debug.Log("GameOver");
            Destroy(this.gameObject);
            GameOver = true;
        }
        
        if (other.CompareTag("Player") && this.CompareTag("TreeFalling"))
        { AudioManager.instance.PlayTreeFallSound.Play();
            isTreeFalling = true;
        }
        if (other.CompareTag("Player") && this.CompareTag("Coin"))
        {
            Debug.Log("Player is Hit with Coin");
            AudioManager.instance.CoinCollide.Play();
            isHitWithCoin = true;
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
