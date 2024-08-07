using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
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

    public Text BambooText2;
    public Text WoodText2;
    public Text westText2;
    public Text BibleText;
    
    public Text RopeText;
    public Text HammerText;
    public Text[] fishManTexts, FighterTexts;

    [Header("Game Screen")]
    public GameObject homeScreen;
    public GameObject storeScreen;
    public GameObject WeaponStoreScreen;
    public GameObject FishStoreScreen;
    public GameObject ItemsStoreScreen;
    public GameObject VehicleStoreScreen;
    public GameObject StoreScreenBackButtonObject;
    public GameObject IndivitualShopScreenBackButtonObject,sellOrTradeScreen;
    public GameObject LoadingPanel,NotEnoughCoinPanel,confirmationPanel,noButtonObject;

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
    public Button SellOrTradeStoreButton;
    [Header("Weapon Shop management")]
    public Button NoButton;
    public Button OkButton,Arrow;
    public Button yesArrow, SavingWest, yesWest, Machete, yesMachete, SafariHat, yesSafari, Fighter,yesFighter;
    public GameObject arrowConfirmPanel, safariConfirmPanel, MacheteConfirmPanel, FigherConfirmPanel, westConfirmPanel;
    [Header("Fish Shop management")]
    public Button FisherMan;
    public Button yesFisherman, rod, yesRod, net, yesNet;
    public GameObject fishManConfirmPanel, rodConfirmPanel, netConfirmPanel;
    [Header("Items shop management")]
    public Button bambooButton;
    public Button yesBambooButton,woodButton, yesWoodButton, ropeButton,yesRopeButton, hammerButton, yesHammerButton , bibleButton, yesBibleButton;
    public GameObject bambooconfirmPanel, woodconfirmPanel, hammerconfirmPanel, bibleconfirmPanel, ropeconfirmPanel;
    [Header("Sell or Trade Item Managament")]
    public Button bambooSellButton;
    public Button yesBambooSellButton, woodSellButton, yesWoodSellButton, fighterTradeMeatButton, yesFighterTradeMeatButton, fighterTradeFishButton, yesFighterTradeFishButton, fighterTradeFruitButton, yesFighterTradeFruitButton;
    public Button fisherTradeMeatButton, yesfisherTradeMeatButton, fisherTradeFishButton, yesfisherTradeFishButton, fisherTradeFruitButton, yesfisherTradeFruitButton, fisherTradeGemButton, yesfisherTradeGemButton;
    public Button bamboo10SellButton, yesBamboo10SellButton, wood10SellButton, yesWood10SellButton;
    public Button gemCoinExchangeButton, yesGemCoinExchangeButton, westBambooExchangeButton, yeswestBambooExchangeButton;
    public GameObject SellBambooconfirmPanel, SellWoodconfirmPanel, SellBambooconfirmPanel10, SellWoodconfirmPanel10;
    public GameObject fisherTradeMeatconfirmPanel, fisherTradeFishconfirmPanel, fisherTradeFruitconfirmPanel, fisherTradeGemconfirmPanel;
    public GameObject fighterTradeMeatconfirmPanel, fighterTradeFishconfirmPanel, fighterTradeFruitconfirmPanel;
    public GameObject westTradeBambooConfirmPanel, gemCoinExchangeConfirmPanel;
    [Header("All Unlockable items Management")]
    public Button seaBagButton;
    public Button yesSeaBagButton, crossbowButton, yesCrossbowButton, canoeButton, yesCanoeButton, nutshellBoatButton, yesNutshellBoatButton, fishingBoatButton, yesFishingBoatButton,shipButton,yesShipButton;
    public GameObject seaBagConfirmPanel, CrossBowConfirmPanel, canoeConfirmPanel, NutshelConfirmPanel, fishingBoatConfirmPanel, shipConfirmPanel;
    public GameObject lockLogoSeabag, lockLogoCrossBow, lockLogoCanoe, lockLogoNutshell, lockLogoFishingBoat, lockLogoShip;
    public GameObject PriceSeabag, PriceCrossBow, PriceCanoe, PriceNutshell, PriceFishingBoat, PriceShip;

    [Header("Camera movementSystem")]
    public static bool isHomeScreen=false, isStoreScreen=false,isWeaponscreen = false, isItemScreen = false, isFishScreen = false, isVehicleScreen = false, itemIsBuyed=false;
    private void Start()
    {
        gotoHomeScreen();
        playButton.onClick.AddListener(playGame);
        storeButton.onClick.AddListener(gotoStore);
        weaponStoreButton.onClick.AddListener(gotoWeaponShop);
        fishStoreButton.onClick.AddListener (gotoFishShop);
        itemsStoreButton.onClick.AddListener(gotoItemShop);
        SellOrTradeStoreButton.onClick.AddListener(gotoTradeOrSell);
        vehicleStoreButton.onClick.AddListener(gotovehicleShop);
        indivitualShopButton.onClick.AddListener(gotoStore);
        storeScreenBackButton.onClick.AddListener(gotoHomeScreen);
        OkButton.onClick.AddListener(OkButtonPressed);
        //weapon shop
        Arrow.onClick.AddListener(BuyArrow);
        yesArrow.onClick.AddListener(yesBuyArrowPressed);

        Machete.onClick.AddListener(BuyMachete);
        yesMachete.onClick.AddListener(yesBuyMachetePressed);

        SafariHat.onClick.AddListener(BuySafari);
        yesSafari.onClick.AddListener(yesBuySafariPressed);

        Fighter.onClick.AddListener(BuyFighter);
        yesFighter.onClick.AddListener(yesBuyFighterPressed);

        SavingWest.onClick.AddListener(BuyWest);
        yesWest.onClick.AddListener(yesBuyWestPressed);

        // Fish Shop
        FisherMan.onClick.AddListener(BuyfishMan);
        yesFisherman.onClick.AddListener(yesBuyfishMan);

        net.onClick.AddListener(BuyNet);
        yesNet.onClick.AddListener(yesBuyNet);

        rod.onClick.AddListener(BuyRod);
        yesRod.onClick.AddListener(yesBuyRod);
        // Item Shop
        woodButton.onClick.AddListener(BuyWood);
        yesWoodButton.onClick.AddListener(yesBuyWood);
        
        bambooButton.onClick.AddListener(BuyBamboo);
        yesBambooButton.onClick.AddListener(yesBuyBamboo);

        hammerButton.onClick.AddListener(BuyHammer);
        yesHammerButton.onClick.AddListener (yesBuyHammer);

        ropeButton.onClick.AddListener(BuyRope);
        yesRopeButton.onClick.AddListener(yesBuyRope);

        bibleButton.onClick.AddListener(BuyBible);
        yesBibleButton.onClick.AddListener(yesBuyBible);

        //Trade or Exchange Items
        bambooSellButton.onClick.AddListener(SellBamboo);
        yesBambooSellButton.onClick.AddListener(yesSellBamboo);

        bamboo10SellButton.onClick.AddListener(SellBamboo10);
        yesBamboo10SellButton.onClick.AddListener(yesSellBamboo10);

        woodSellButton.onClick.AddListener(SellWood);
        yesWoodSellButton.onClick.AddListener(yesSellWood);

        wood10SellButton.onClick.AddListener(SellWood10);
        yesWood10SellButton.onClick.AddListener(yesSellWood10);

        fisherTradeFishButton.onClick.AddListener(BuyfishManWithFish);
        yesfisherTradeFishButton.onClick.AddListener(yesBuyfishManWithFish);

        fisherTradeMeatButton.onClick.AddListener(BuyfishManWithMeat);
        yesfisherTradeMeatButton.onClick.AddListener(yesBuyfishManWithMeat);
        
        fisherTradeFruitButton.onClick.AddListener(BuyfishManWithFruit);
        yesfisherTradeFruitButton.onClick.AddListener(yesBuyfishManWithFruit);
        
        fisherTradeGemButton.onClick.AddListener(BuyfishManWithGem);
        yesfisherTradeGemButton.onClick.AddListener(yesBuyfishManWithGem);

        fighterTradeFishButton.onClick.AddListener(BuyFighterWithFish);
        yesFighterTradeFishButton.onClick.AddListener (yesBuyFighterWithFish);

        fighterTradeMeatButton.onClick.AddListener(BuyFighterWithMeat);
        yesFighterTradeMeatButton.onClick.AddListener(yesBuyFighterWithMeat);

        fighterTradeFruitButton.onClick.AddListener(BuyFighterWithFruit);
        yesFighterTradeFruitButton.onClick.AddListener(yesBuyFighterWithFruit);

        gemCoinExchangeButton.onClick.AddListener(ExchangeGemWithCoin);
        yesGemCoinExchangeButton.onClick.AddListener(YesExchangeGemWithCoin);

        westBambooExchangeButton.onClick.AddListener(ExchangeWestWithBamboo);
        yeswestBambooExchangeButton.onClick.AddListener(YesExchangeWestWithBamboo);
        //unlockable Item
        seaBagButton.onClick.AddListener(unlockSeabag);
        yesSeaBagButton.onClick.AddListener(YesUnlockSeabag);

        crossbowButton.onClick.AddListener(unlockCrossBow);
        yesCrossbowButton.onClick.AddListener(YesUnlockCrossBow);

        canoeButton.onClick.AddListener(unlockCanoe);
        yesCanoeButton.onClick.AddListener(YesUnlockCanoe);

        nutshellBoatButton.onClick.AddListener(unlockNutshell);
        yesNutshellBoatButton.onClick.AddListener(YesUnlockNutshell);

        fishingBoatButton.onClick.AddListener(unlockFishingBoat);
        yesFishingBoatButton.onClick.AddListener(YesUnlockFishingBoat);

        shipButton.onClick.AddListener(unlockShip);
        yesShipButton.onClick.AddListener(YesUnlockShip);

        NoButton.onClick.AddListener(NoButtonPressed);
    }
    private void Awake()
    {
        StartCoroutine(loadingPanelOnOff());
    }
    private void Update()
    {
        PlayerItemsAmountShow();
        fishItemAmountShow();
        weaponItemAmountShow();
        ItemsAmountShow();
        tradeItemsAmountShow();
        showLockedLogo();
    }
    void showLockedLogo()
    {
        if (ScoreCount.isUnlockedSeabag)
        {
            lockLogoSeabag.SetActive(false);
            PriceSeabag.SetActive(false);
            seaBagButton.enabled=false;
            
        }
        if (ScoreCount.isUnlockedCrossBow)
        {
            lockLogoCrossBow.SetActive(false);
            PriceCrossBow.SetActive(false);
            crossbowButton.enabled=false;
        }
        if (ScoreCount.isUnlockedCanoe)
        {
            lockLogoCanoe.SetActive(false);
            PriceCanoe.SetActive(false);
            canoeButton.enabled=false;
        }
        if (ScoreCount.isUnlockedShip)
        {
            lockLogoShip.SetActive(false);
           PriceShip.SetActive(false);
            shipButton.enabled=false;
        }
        if (ScoreCount.isUnlockedFishingBoat)
        {
            lockLogoFishingBoat.SetActive(false);
            PriceFishingBoat.SetActive(false);
            fishingBoatButton.enabled=false;
        }
        if (ScoreCount.isUnlockedNutshell)
        {
            lockLogoNutshell.SetActive(false);
            PriceNutshell.SetActive(false);
            nutshellBoatButton.enabled=false;
        }

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
    void tradeItemsAmountShow()
    {
        for(int i=0;i< fishManTexts.Length; i++)
        {
            fishManTexts[i].text= ScoreCount.fisherman.ToString();
        }
        for (int i = 0; i < FighterTexts.Length; i++)
        {
            FighterTexts[i].text = ScoreCount.fighter.ToString();
        }
        westText2.text = ScoreCount.savingWest.ToString();

        BambooText2.text = ScoreCount.bamboo.ToString();
        WoodText2.text = ScoreCount.totalWood.ToString();
    }
    
    IEnumerator playGameWait()
    {
        LoadingPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        LoadingPanel.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }
    void playGame()
    {
        StartCoroutine(playGameWait());
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
        sellOrTradeScreen.SetActive(false);
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
        sellOrTradeScreen.SetActive(false);
        VehicleStoreScreen.SetActive(false);
        //bool value
        isWeaponscreen = false;
        isHomeScreen = false;
        isItemScreen = false;
        isStoreScreen = false;
        isVehicleScreen = false;
        isFishScreen = true;
    }
    void gotoTradeOrSell()
    {

        StoreScreenBackButtonObject.SetActive(false);
        IndivitualShopScreenBackButtonObject.SetActive(false);
        storeScreen.SetActive(false);
        homeScreen.SetActive(false);
        sellOrTradeScreen.SetActive(true);
        WeaponStoreScreen.SetActive(false);
        FishStoreScreen.SetActive(false);
        ItemsStoreScreen.SetActive(false);
        VehicleStoreScreen.SetActive(false);
        StoreScreenBackButtonObject.SetActive(true);
        //bool value
        isWeaponscreen = false;
        isHomeScreen = false;
        isItemScreen = false;
        isStoreScreen = true;
        isVehicleScreen = false;
        isFishScreen = false;
    }
    void gotoWeaponShop()
    {

        StoreScreenBackButtonObject.SetActive(false);
        IndivitualShopScreenBackButtonObject.SetActive(true);
        storeScreen.SetActive(false);
        homeScreen.SetActive(false);
        WeaponStoreScreen.SetActive(true);
        sellOrTradeScreen.SetActive(false);
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
        sellOrTradeScreen.SetActive(false);
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
        sellOrTradeScreen.SetActive(false);
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
        sellOrTradeScreen.SetActive(false);
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
    IEnumerator loadingPanelOnOff()
    {
        LoadingPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        LoadingPanel.SetActive(false);
    }
    void BuyArrow()
    {
        //arrow price 10 $
        if (ScoreCount.totalcoins >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            arrowConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyArrowPressed()
    {
        ScoreCount.totalArrowWhenEndRun+=1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        arrowConfirmPanel.SetActive(false);
    }
    void BuySafari()
    {
        //safari price 10 $
        if (ScoreCount.totalcoins >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            safariConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuySafariPressed()
    {
        ScoreCount.totalSafariWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        safariConfirmPanel.SetActive(false);
    }
    void BuyFighter()
    {
        //fighter price 100 $
        if (ScoreCount.totalcoins >= 100)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            FigherConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyFighterPressed()
    {
        ScoreCount.totalFighterWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 100;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        FigherConfirmPanel.SetActive(false);
    }
    void BuyMachete()
    {
        //machete price 10 $
        if (ScoreCount.totalcoins >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            MacheteConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyMachetePressed()
    {
        ScoreCount.totalMacheteWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        MacheteConfirmPanel.SetActive(false);
    }
    void BuyWest()
    {
        //Saving west price 30 $
        if (ScoreCount.totalcoins >= 30)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            westConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyWestPressed()
    {
        ScoreCount.totalSavewestWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 30;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        westConfirmPanel.SetActive(false);
    }
    void BuyfishMan()
    {
        //fishman price 100 $
        if (ScoreCount.totalcoins >= 100)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fishManConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyfishMan()
    {
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 100;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fishManConfirmPanel.SetActive(false);
    }
    void BuyRod()
    {
        //fish rod price  50$
        if (ScoreCount.totalcoins >= 50)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            rodConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyRod()
    {
        ScoreCount.totalRodWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 50;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        rodConfirmPanel.SetActive(false);
    }
    void BuyNet()
    {
        //net price 50 $
        if (ScoreCount.totalcoins >= 50)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            netConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyNet()
    {
        ScoreCount.totalNetWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 50;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        netConfirmPanel.SetActive(false);
    }
    void BuyBamboo()
    {
        //bamboo price 10 $
        if (ScoreCount.totalcoins >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            bambooconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyBamboo()
    {
        ScoreCount.totalBambooWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        netConfirmPanel.SetActive(false);
    }
    void BuyWood()
    {
        //wood price 10 $
        if (ScoreCount.totalcoins >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            woodconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyWood()
    {
        ScoreCount.totalWoodWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        woodconfirmPanel.SetActive(false);
    }
    void BuyRope()
    {
        //Rope price 10 $
        if (ScoreCount.totalcoins >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            ropeconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyRope()
    {
        ScoreCount.totalRopeWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        ropeconfirmPanel.SetActive(false);
    } 
    void BuyHammer()
    {
        //hammer price 20 $
        if (ScoreCount.totalcoins >= 20)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            hammerconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyHammer()
    {
        ScoreCount.totalHammerWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 20;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        hammerconfirmPanel.SetActive(false);
    }
    void BuyBible()
    {
        //bible price 500 $
        if (ScoreCount.totalcoins >= 500)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            bibleconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyBible()
    {
        ScoreCount.totalBibleWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 500;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        bibleconfirmPanel.SetActive(false);
    }
    void SellBamboo()
    {
        //bamboo price 10 $
        if (ScoreCount.totalBamboo >= 1)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            SellBambooconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesSellBamboo()
    {
        ScoreCount.totalBambooWhenEndRun -= 1;
        ScoreCount.totalCoinsWhenEndRun += 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        SellBambooconfirmPanel.SetActive(false);
    }
    void SellBamboo10()
    {
        //bamboo price 10 $
        if (ScoreCount.totalBamboo >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            SellBambooconfirmPanel10.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesSellBamboo10()
    {
        ScoreCount.totalBambooWhenEndRun -= 10;
        ScoreCount.totalCoinsWhenEndRun += 150;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        SellBambooconfirmPanel10.SetActive(false);
    }
    void SellWood()
    {
        //wood price 10 $
        if (ScoreCount.totalWood >= 1)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            SellWoodconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesSellWood()
    {
        ScoreCount.totalWoodWhenEndRun -= 1;
        ScoreCount.totalCoinsWhenEndRun += 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        SellWoodconfirmPanel.SetActive(false);
    }
    void SellWood10()
    {
        //wood price 10 $
        if (ScoreCount.totalWood >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            SellWoodconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesSellWood10()
    {
        ScoreCount.totalWoodWhenEndRun -= 10;
        ScoreCount.totalCoinsWhenEndRun += 150;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        SellWoodconfirmPanel.SetActive(false);
    }
    void BuyfishManWithFish()
    {
        //fishman price 100 $
        if (ScoreCount.totalFish >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fisherTradeFishconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyfishManWithFish()
    {
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalFishWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fisherTradeFishconfirmPanel.SetActive(false);
    }
    void BuyfishManWithMeat()
    {
        //fishman price 100 $
        if (ScoreCount.totalMeat >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fisherTradeMeatconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyfishManWithMeat()
    {
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalMeatWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fisherTradeMeatconfirmPanel.SetActive(false);
    }
    void BuyfishManWithFruit()
    {
        //fishman price 100 $
        if (ScoreCount.totalFruits >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fisherTradeFruitconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyfishManWithFruit()
    {
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalFruitWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fisherTradeFruitconfirmPanel.SetActive(true);

    }
    void BuyFighterWithFish()
    {
        //fishman price 100 $
        if (ScoreCount.totalFish >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fighterTradeFishconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyFighterWithFish()
    {
        ScoreCount.totalFighterWhenEndRun += 1;
        ScoreCount.totalFishWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fighterTradeFishconfirmPanel.SetActive(false);
    }
    void BuyFighterWithMeat()
    {
        //fishman price 100 $
        if (ScoreCount.totalMeat >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fighterTradeMeatconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyFighterWithMeat()
    {
        ScoreCount.totalFighterWhenEndRun += 1;
        ScoreCount.totalMeatWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fighterTradeMeatconfirmPanel.SetActive(false);
    }
    void BuyFighterWithFruit()
    {
        //fishman price 100 $
        if (ScoreCount.totalFruits >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fighterTradeFruitconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyFighterWithFruit()
    {
        ScoreCount.totalFighterWhenEndRun += 1;
        ScoreCount.totalFruitWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fighterTradeFruitconfirmPanel.SetActive(true);

    }
    void ExchangeGemWithCoin()
    {
        //fishman price 100 $
        if (ScoreCount.totalGem >= 1)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            gemCoinExchangeConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void YesExchangeGemWithCoin()
    {
        ScoreCount.totalCoinsWhenEndRun += 100;
        ScoreCount.totalGemWhenEndRun -= 1;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        gemCoinExchangeConfirmPanel.SetActive(true);

    }
    void BuyfishManWithGem()
    {
        //fishman price 100 $
        if (ScoreCount.totalGem >= 1)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fisherTradeGemconfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesBuyfishManWithGem()
    {
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalGemWhenEndRun -= 1;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fisherTradeGemconfirmPanel.SetActive(false);
    }
    void ExchangeWestWithBamboo()
    {
        //fishman price 100 $
        if (ScoreCount.totalBamboo >= 3)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            westTradeBambooConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void YesExchangeWestWithBamboo()
    {
        ScoreCount.totalSavewestWhenEndRun += 1;
        ScoreCount.totalBambooWhenEndRun -= 3;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        westTradeBambooConfirmPanel.SetActive(false);

    }
    void unlockSeabag()
    {
        //seabag price 1000 $
        if (ScoreCount.totalcoins >= 1000)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            seaBagConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void YesUnlockSeabag()
    {
        ScoreCount.isUnlockedSeabag = true;
        ScoreCount.totalCoinsWhenEndRun -= 1000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        seaBagConfirmPanel.SetActive(false);

    }

    void unlockCrossBow()
    {
        //crossbow price 1000 $
        if (ScoreCount.totalcoins >= 1000)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            CrossBowConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void YesUnlockCrossBow()
    {
        ScoreCount.isUnlockedCrossBow = true;
        ScoreCount.totalCoinsWhenEndRun -= 1000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        CrossBowConfirmPanel.SetActive(false);

    }
    void unlockCanoe()
    {
        //crossbow price 1000 $
        if (ScoreCount.totalcoins >= 1000)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            canoeConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void YesUnlockCanoe()
    {
        ScoreCount.isUnlockedCanoe = true;
        ScoreCount.totalCoinsWhenEndRun -= 1000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        canoeConfirmPanel.SetActive(false);

    }
    void unlockNutshell()
    {
        //crossbow price 1000 $
        if (ScoreCount.totalcoins >= 2000)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            NutshelConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void YesUnlockNutshell()
    {
        ScoreCount.isUnlockedNutshell = true;
        ScoreCount.totalCoinsWhenEndRun -= 2000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        NutshelConfirmPanel.SetActive(false);
    }
    void unlockFishingBoat()
    {
        //crossbow price 1000 $
        if (ScoreCount.totalcoins >= 5000)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            fishingBoatConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void YesUnlockFishingBoat()
    {
        ScoreCount.isUnlockedFishingBoat = true;
        ScoreCount.totalCoinsWhenEndRun -= 5000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fishingBoatConfirmPanel.SetActive(false);
    }
    void unlockShip()
    {
        //crossbow price 10000 $
        if (ScoreCount.totalcoins >= 10000)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            shipConfirmPanel.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void YesUnlockShip()
    {
        ScoreCount.isUnlockedShip = true;
        ScoreCount.totalCoinsWhenEndRun -= 10000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        shipConfirmPanel.SetActive(false);
    }




    void NoButtonPressed()
    {
        noButtonObject.SetActive(false);
        confirmationPanel.SetActive(false);
        arrowConfirmPanel.SetActive(false);
        westConfirmPanel.SetActive(false);
        safariConfirmPanel.SetActive(false);
        FigherConfirmPanel.SetActive(false);
        MacheteConfirmPanel.SetActive(false);
        fishManConfirmPanel.SetActive(false);
        netConfirmPanel.SetActive (false);
        rodConfirmPanel.SetActive (false);
        woodconfirmPanel.SetActive (false);
        bambooconfirmPanel.SetActive (false);
        hammerconfirmPanel.SetActive (false);
        bibleconfirmPanel.SetActive (false);
        ropeconfirmPanel.SetActive (false);
        SellWoodconfirmPanel.SetActive(false);
        SellWoodconfirmPanel10.SetActive(false);
        SellBambooconfirmPanel.SetActive(false);
        SellBambooconfirmPanel10.SetActive(false);
        fisherTradeMeatconfirmPanel.SetActive(false);
        fisherTradeFishconfirmPanel.SetActive(false);
        fisherTradeFruitconfirmPanel.SetActive(false);
        fisherTradeGemconfirmPanel.SetActive(false);
        fighterTradeFishconfirmPanel.SetActive(false);
        fighterTradeFruitconfirmPanel.SetActive(false);
        fighterTradeMeatconfirmPanel.SetActive(false);
        westTradeBambooConfirmPanel.SetActive(false);
        gemCoinExchangeConfirmPanel.SetActive(false);

    }
    
    void OkButtonPressed()
    {

        NotEnoughCoinPanel.SetActive(false);
        confirmationPanel.SetActive(false);
    }

}
