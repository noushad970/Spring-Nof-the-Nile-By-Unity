using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour, IDataPersistence
{
    public static ScoreCount instance;
    int totalCoinsWhenEndRun=0;
    int totalFruitWhenEndRun = 0;
    int totalGemWhenEndRun = 0;
    int totalSavewestWhenEndRun = 0 ;
    int totalBambooWhenEndRun = 0;
    int totalWoodWhenEndRun = 0;
    int totalMeatWhenEndRun = 0;
    int totalFishWhenEndRun = 0;
    int coinShowInScreen = 0;
    public static int totalcoins, totalFruits, totalGem, totalSaveWest, totalBamboo, totalWood, totalMeat, totalFish;
    [Header("Total Item Player Have")]
    public static int bamboo, savingWest, seaBag, rope, hammer, bible, safariHat, arrow, machete, fighter, fisherman, net, fishingRod;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
    }
    //game data will load here
    public void loadData(GameData data)
    {
        totalcoins = data.coin;
        totalFruits = data.fruit;
        totalBamboo = data.bamboo;
        totalGem = data.gems;
        totalWood = data.woodPlank;
        totalSaveWest = data.life;
        totalMeat = data.meat;
        totalFish = data.fish;
        bamboo = data.bamboo;
        savingWest = data.savingWest;
        seaBag = data.seaBag;
        rope = data.rope;
        hammer = data.hammer;
        bible = data.bible;
        safariHat = data.safariHat;
        arrow = data.arrow;
        machete = data.machete;
        fighter = data.fighter;
        fisherman = data.fisherman;
        fishingRod =data.fishingRod;
        net = data.net; 
        Debug.Log("Coin when Load:X" + totalcoins);
        Debug.Log("Coin when Load:" + data.coin);

    }
    //game data will save here
    public void saveData(ref GameData data)
    {
        if (TriggerCollisionDetection.GameOver)
        {
            data.coin += totalCoinsWhenEndRun;
            data.fruit += totalFruitWhenEndRun;
            data.bamboo += totalBambooWhenEndRun;
            data.gems += totalGemWhenEndRun;
            data.woodPlank += totalWoodWhenEndRun;
            data.fish += totalFishWhenEndRun;
            data.meat += totalMeatWhenEndRun;
            data.life += totalSavewestWhenEndRun;
            Debug.Log("Coin when Game End and Save:" + totalCoinsWhenEndRun);
            Debug.Log("Coin when Game End and Save:" + data.coin);
            totalCoinsWhenEndRun = 0;
        }
    }
   

    // Update is called once per frame
    //this code will shown the coins and high scores on the main menu screen
    void Update()
    {
        if (TriggerCollisionDetection.isHitWithCoin)
        {
            totalCoinsWhenEndRun++;
            TriggerCollisionDetection.isHitWithCoin = false;
        }
        if (TriggerCollisionDetection.isHitFruitItem)
        {
            totalFruitWhenEndRun++;
            TriggerCollisionDetection.isHitFruitItem = false;
        }
        if (TriggerCollisionDetection.isHitWithGem)
        {
            totalGemWhenEndRun++;
            TriggerCollisionDetection.isHitWithGem = false;
        }
        if (TriggerCollisionDetection.isHitBambooItem)
        {
            totalBambooWhenEndRun++;
            TriggerCollisionDetection.isHitBambooItem = false;
        }
        if (TriggerCollisionDetection.isHitWoodItem)
        {
            totalWoodWhenEndRun++;
            TriggerCollisionDetection.isHitWoodItem = false;
        }
        
    }
}
