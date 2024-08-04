using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMeneManager : MonoBehaviour
{
    [Header("Show all player Item amount")]
    public TMP_Text coinText;
    public TMP_Text gemText;
    public TMP_Text fruitText;
    public TMP_Text meatText;
    public TMP_Text fishText;
    [Header("Store Items:\nFish Shop")]
    public Text fisherManText;
    public Text netText;
    public Text FishingRodText;
    [Header("Weapon Shop")]
    public Text MacheteText;
    public Text SafarihatText;
    public Text FighterText;
    public Text ArrowText;
    public Text savingWestText;
    [Header("Items Shop")]
    public Text BambooText;
    public Text WoodText;
    public Text BibleText;
    
    public Text RopeText;
    public Text HammerText;

    [Header("Game Screen")]
    public GameObject homeScreen;
    public GameObject storeScreen;
    public GameObject WeaponStoreScreen;
    public GameObject FishStoreScreen;
    public GameObject ItemsStoreScreen;
    public GameObject VehicleStoreScreen;
    public GameObject StoreScreenBackButtonObject;
    public GameObject IndivitualShopScreenBackButtonObject;

    [Header("Game Screen Buttons")]
    public Button playButton;
    public Button storeButton;
    public Button howToPlayButton;
    public Button quitButton;
    public Button weaponStoreButton;
    public Button fishStoreButton;
    public Button itemsStoreButton;
    public Button vehicleStoreButton;
    public Button indivitualShopButton;
    public Button storeScreenBackButton;

    [Header("Camera movementSystem")]
    public static bool isHomeScreen=false, isStoreScreen=false,isWeaponscreen = false, isItemScreen = false, isFishScreen = false, isVehicleScreen = false;
    private void Start()
    {
        gotoHomeScreen();
        playButton.onClick.AddListener(playGame);
        storeButton.onClick.AddListener(gotoStore);
        weaponStoreButton.onClick.AddListener(gotoWeaponShop);
        fishStoreButton.onClick.AddListener (gotoFishShop);
        itemsStoreButton.onClick.AddListener(gotoItemShop);
        vehicleStoreButton.onClick.AddListener(gotovehicleShop);
        indivitualShopButton.onClick.AddListener(gotoStore);
        storeScreenBackButton.onClick.AddListener(gotoHomeScreen);
    }

    private void Update()
    {
        PlayerItemsAmountShow();
        fishItemAmountShow();
        weaponItemAmountShow();
        ItemsAmountShow();
    }
    void PlayerItemsAmountShow()
    {
        coinText.text = ": "+ScoreCount.totalcoins.ToString();
        gemText.text= ": " + ScoreCount.totalGem.ToString();
        fruitText.text=": " + ScoreCount.totalFruits.ToString();
        meatText.text= ": " + ScoreCount.totalMeat.ToString();
        fishText.text= ": " + ScoreCount.totalFish.ToString();
    }
    void fishItemAmountShow()
    {
        fisherManText.text=ScoreCount.fisherman.ToString();
        FishingRodText.text=ScoreCount.fishingRod.ToString();
        netText.text=ScoreCount.net.ToString();
    }
    void weaponItemAmountShow()
    {
        SafarihatText.text=ScoreCount.safariHat.ToString();
        savingWestText.text=ScoreCount.savingWest.ToString();
        FighterText.text=ScoreCount.fighter.ToString();
        ArrowText.text=ScoreCount.arrow.ToString();
        MacheteText.text=ScoreCount.machete.ToString();
    }
    void ItemsAmountShow()
    {
        BambooText.text=ScoreCount.bamboo.ToString();
        WoodText.text=ScoreCount.totalWood.ToString();
        HammerText.text=ScoreCount.hammer.ToString();
        RopeText.text=ScoreCount.rope.ToString();
        BibleText.text=ScoreCount.bible.ToString();
    }
    void playGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    void gotoStore()
    {
        StoreScreenBackButtonObject.SetActive(true);
        IndivitualShopScreenBackButtonObject.SetActive(false);
        storeScreen.SetActive(true);
        homeScreen.SetActive(false);
        WeaponStoreScreen.SetActive(false);
        FishStoreScreen.SetActive(false);
        ItemsStoreScreen.SetActive(false);
        VehicleStoreScreen.SetActive(false);

        //bool value
        isWeaponscreen = false;
        isHomeScreen= false;
        isItemScreen = false;
        isStoreScreen = true;
        isVehicleScreen= false;
        isFishScreen= false;
    }
    void gotoFishShop()
    {

        StoreScreenBackButtonObject.SetActive(false);
        IndivitualShopScreenBackButtonObject.SetActive(true);
        storeScreen.SetActive(false);
        homeScreen.SetActive(false);
        WeaponStoreScreen.SetActive(false);
        FishStoreScreen.SetActive(true);
        ItemsStoreScreen.SetActive(false);
        VehicleStoreScreen.SetActive(false);
        //bool value
        isWeaponscreen = false;
        isHomeScreen = false;
        isItemScreen = false;
        isStoreScreen = false;
        isVehicleScreen = false;
        isFishScreen = true;
    }
    void gotoWeaponShop()
    {

        StoreScreenBackButtonObject.SetActive(false);
        IndivitualShopScreenBackButtonObject.SetActive(true);
        storeScreen.SetActive(false);
        homeScreen.SetActive(false);
        WeaponStoreScreen.SetActive(true);
        FishStoreScreen.SetActive(false);
        ItemsStoreScreen.SetActive(false);
        VehicleStoreScreen.SetActive(false);
        //bool value
        isWeaponscreen = true;
        isHomeScreen = false;
        isItemScreen = false;
        isStoreScreen = false;
        isVehicleScreen = false;
        isFishScreen = false;
    }
    void gotovehicleShop()
    {
        StoreScreenBackButtonObject.SetActive(false);
        IndivitualShopScreenBackButtonObject.SetActive(true);
        storeScreen.SetActive(false);
        homeScreen.SetActive(false);
        WeaponStoreScreen.SetActive(false);
        FishStoreScreen.SetActive(false);
        ItemsStoreScreen.SetActive(false);
        VehicleStoreScreen.SetActive(true);
        //bool value
        isWeaponscreen = false;
        isHomeScreen = false;
        isItemScreen = false;
        isStoreScreen = false;
        isVehicleScreen = true;
        isFishScreen = false;
    }
    void gotoItemShop()
    {
        StoreScreenBackButtonObject.SetActive(false);
        IndivitualShopScreenBackButtonObject.SetActive(true);
        storeScreen.SetActive(false);
        homeScreen.SetActive(false);
        WeaponStoreScreen.SetActive(false);
        FishStoreScreen.SetActive(false);
        ItemsStoreScreen.SetActive(true);
        VehicleStoreScreen.SetActive(false);
        //bool value
        isWeaponscreen = false;
        isHomeScreen = false;
        isItemScreen = true;
        isStoreScreen = false;
        isVehicleScreen = false;
        isFishScreen = false;
    }
    void gotoHomeScreen()
    {
        StoreScreenBackButtonObject.SetActive(false);
        IndivitualShopScreenBackButtonObject.SetActive(false);
        homeScreen.SetActive(true);
        storeScreen.SetActive(false);
        WeaponStoreScreen.SetActive(false);
        FishStoreScreen.SetActive(false);
        ItemsStoreScreen.SetActive(false);
        VehicleStoreScreen.SetActive(false);
        //bool value
        isWeaponscreen = false;
        isHomeScreen = true;
        isItemScreen = false;
        isStoreScreen = false;
        isVehicleScreen = false;
        isFishScreen = false;
    }
   

}
