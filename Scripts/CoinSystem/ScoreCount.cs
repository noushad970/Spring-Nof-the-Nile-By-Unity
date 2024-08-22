using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour, IDataPersistence
{
    public static int totalCoinsWhenEndRun =0;
    public static int totalFruitWhenEndRun = 0;
    public static int totalGemWhenEndRun = 0;
    public static int totalSavewestWhenEndRun = 0 , totalArrowWhenEndRun = 0, totalSafariWhenEndRun = 0, totalMacheteWhenEndRun = 0, totalFighterWhenEndRun = 0;
    public static int totalBambooWhenEndRun = 0, totalRopeWhenEndRun=0, totalHammerWhenEndRun=0, totalBibleWhenEndRun=0;
    public static int totalWoodWhenEndRun = 0;
    public static int totalMeatWhenEndRun = 0;
    public static int totalFishWhenEndRun = 0, totalRodWhenEndRun = 0, totalNetWhenEndRun = 0, totalFishManWhenEndRun=0;
    int coinShowInScreen = 0;
    public static bool isUnlockedSeabag = false, isUnlockedCrossBow = false, isUnlockedCanoe = false, isUnlockedNutshell = false, isUnlockedFishingBoat = false, isUnlockedShip=false;
    public static int totalcoins, totalFruits, totalGem, totalSaveWest, totalBamboo, totalWood, totalMeat, totalFish;
    public static float shipHealth = 100;
    public static int totalItems;
    [Header("Total Item Player Have")]
    
    public static int bamboo, savingWest, seaBag, rope, hammer, bible, safariHat, arrow, machete, fighter, fisherman, net, fishingRod;
    
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
        isUnlockedCanoe = data.unlockedCanoe;
        isUnlockedShip= data.unlockedShip;
        isUnlockedCrossBow = data.unlockedCrossBow;
        isUnlockedFishingBoat = data.unlockedFishingBoat;
        isUnlockedNutshell = data.unlockedNutshell;
        isUnlockedSeabag = data.unlockedSeabag;
        shipHealth = data.shipCondition;

    }
    //game data will save here
    public void saveData(ref GameData data)
    {
        
        data.coin += totalCoinsWhenEndRun;
        data.fruit += totalFruitWhenEndRun;
        data.bamboo += totalBambooWhenEndRun;
        data.gems += totalGemWhenEndRun;
        data.woodPlank += totalWoodWhenEndRun;
        data.fish += totalFishWhenEndRun;
        data.meat += totalMeatWhenEndRun;

        totalCoinsWhenEndRun = 0;
        totalBambooWhenEndRun = 0;
        totalGemWhenEndRun = 0;
        totalFishWhenEndRun = 0;
        totalMeatWhenEndRun = 0;
        totalWoodWhenEndRun = 0;
        totalFruitWhenEndRun = 0;
        data.savingWest += totalSavewestWhenEndRun;
        data.arrow += totalArrowWhenEndRun;
        data.fighter += totalFighterWhenEndRun;
        data.safariHat += totalSafariWhenEndRun;
        data.machete += totalMacheteWhenEndRun;
        totalArrowWhenEndRun = 0;
        totalFighterWhenEndRun = 0;
        totalMacheteWhenEndRun = 0;
        totalSafariWhenEndRun = 0;
        totalSavewestWhenEndRun = 0;
        data.fisherman += totalFishManWhenEndRun;
        data.net += totalNetWhenEndRun;
        data.fishingRod += totalRodWhenEndRun;
        data.rope+= totalRopeWhenEndRun;
        data.hammer += totalHammerWhenEndRun;
        data.bible+= totalBibleWhenEndRun;
        totalHammerWhenEndRun= 0;
        totalBibleWhenEndRun = 0;
        totalRopeWhenEndRun = 0;
        totalRodWhenEndRun = 0;
        totalNetWhenEndRun = 0;
        totalFishManWhenEndRun = 0;

         data.unlockedCanoe= isUnlockedCanoe;
          data.unlockedShip= isUnlockedShip;
        data.unlockedCrossBow= isUnlockedCrossBow ;
         data.unlockedFishingBoat=isUnlockedFishingBoat;
        data.unlockedNutshell= isUnlockedNutshell ;
        data.unlockedSeabag= isUnlockedSeabag ;
        data.shipCondition = shipHealth;
    }

    private void Awake()
    {
        totalItems=0;
    }
    // Update is called once per frame
    //this code will shown the coins and high scores on the main menu screen
    void Update()
    {

        totalItems = totalCoinsWhenEndRun + totalGemWhenEndRun + totalFishWhenEndRun + totalFruitWhenEndRun + totalMeatWhenEndRun + totalBambooWhenEndRun + totalWoodWhenEndRun; 
        
    }
}
