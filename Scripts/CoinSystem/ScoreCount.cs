using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour, IDataPersistence
{
    public static ScoreCount instance;
    int totalCoinsWhenEndRun=0,totalcoins;
    int totalFruitWhenEndRun = 0, totalFruits;
    int totalGemWhenEndRun = 0, totalGem;
    int totalSavewestWhenEndRun = 0, totalSaveWest;
    int totalBambooWhenEndRun = 0, totalBamboo;
    int totalWoodWhenEndRun = 0, totalWood;
    int totalMeatWhenEndRun = 0, totalMeat;
    int totalFishWhenEndRun = 0, totalFish;
    int coinShowInScreen = 0;
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
        Debug.Log("Coin when Load:" + totalcoins);
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
