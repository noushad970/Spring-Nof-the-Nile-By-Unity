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
    public TMP_Text notificationtext;
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

    public GameObject notificationBG;
    
    [Header("Camera movementSystem")]
    public static bool isHomeScreen=false, isStoreScreen=false,isWeaponscreen = false, isItemScreen = false, isFishScreen = false, isVehicleScreen = false, itemIsBuyed=false,isSaveandLoadData=false;
    private void Start()
    {
        notificationBG.SetActive(false);
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
        quitButton.onClick.AddListener(quitGame);
    }
    private void Awake()
    {

        StartCoroutine(loadingPanelOnOff());
        isSaveandLoadData=true;
    }
    void quitGame()
    {
        Application.Quit();
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
        AudioManager.instance.buttonPressSound.Play();
        StartCoroutine(playGameWait());
    }
    void gotoStore()
    {
        AudioManager.instance.buttonPressSound.Play();
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

        AudioManager.instance.buttonPressSound.Play();
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

        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.buttonPressSound.Play();

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
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalArrowWhenEndRun+=1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        arrowConfirmPanel.SetActive(false);
    }
    void BuySafari()
    {
        AudioManager.instance.buttonPressSound.Play();
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

        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalSafariWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        safariConfirmPanel.SetActive(false);
    }
    void BuyFighter()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFighterWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 100;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        FigherConfirmPanel.SetActive(false);
    }
    void BuyMachete()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalMacheteWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        MacheteConfirmPanel.SetActive(false);
    }
    void BuyWest()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalSavewestWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 30;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        westConfirmPanel.SetActive(false);
    }
    void BuyfishMan()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 100;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fishManConfirmPanel.SetActive(false);
    }
    void BuyRod()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalRodWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 50;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        rodConfirmPanel.SetActive(false);
    }
    void BuyNet()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalNetWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 50;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        netConfirmPanel.SetActive(false);
    }
    void BuyBamboo()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalBambooWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        netConfirmPanel.SetActive(false);
    }
    void BuyWood()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalWoodWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        woodconfirmPanel.SetActive(false);
    }
    void BuyRope()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalRopeWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        ropeconfirmPanel.SetActive(false);
    } 
    void BuyHammer()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalHammerWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 20;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        hammerconfirmPanel.SetActive(false);
    }
    void BuyBible()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalBibleWhenEndRun += 1;
        ScoreCount.totalCoinsWhenEndRun -= 500;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        bibleconfirmPanel.SetActive(false);
    }
    void SellBamboo()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalBambooWhenEndRun -= 1;
        ScoreCount.totalCoinsWhenEndRun += 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        SellBambooconfirmPanel.SetActive(false);
    }
    void SellBamboo10()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalBambooWhenEndRun -= 10;
        ScoreCount.totalCoinsWhenEndRun += 150;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        SellBambooconfirmPanel10.SetActive(false);
    }
    void SellWood()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalWoodWhenEndRun -= 1;
        ScoreCount.totalCoinsWhenEndRun += 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        SellWoodconfirmPanel.SetActive(false);
    }
    void SellWood10()
    {
        AudioManager.instance.buttonPressSound.Play();
        //wood price 10 $
        if (ScoreCount.totalWood >= 10)
        {
            confirmationPanel.SetActive(true);
            noButtonObject.SetActive(true);
            SellWoodconfirmPanel10.SetActive(true);
        }
        else
        {
            confirmationPanel.SetActive(true);
            NotEnoughCoinPanel.SetActive(true);
        }
    }
    void yesSellWood10()
    {
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalWoodWhenEndRun -= 10;
        ScoreCount.totalCoinsWhenEndRun += 150;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        SellWoodconfirmPanel.SetActive(false);
    }
    void BuyfishManWithFish()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalFishWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fisherTradeFishconfirmPanel.SetActive(false);
    }
    void BuyfishManWithMeat()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalMeatWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fisherTradeMeatconfirmPanel.SetActive(false);
    }
    void BuyfishManWithFruit()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalFruitWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fisherTradeFruitconfirmPanel.SetActive(true);

    }
    void BuyFighterWithFish()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFighterWhenEndRun += 1;
        ScoreCount.totalFishWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fighterTradeFishconfirmPanel.SetActive(false);
    }
    void BuyFighterWithMeat()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFighterWhenEndRun += 1;
        ScoreCount.totalMeatWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fighterTradeMeatconfirmPanel.SetActive(false);
    }
    void BuyFighterWithFruit()
    {
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFighterWhenEndRun += 1;
        ScoreCount.totalFruitWhenEndRun -= 10;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fighterTradeFruitconfirmPanel.SetActive(true);

    }
    void ExchangeGemWithCoin()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalCoinsWhenEndRun += 100;
        ScoreCount.totalGemWhenEndRun -= 1;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        gemCoinExchangeConfirmPanel.SetActive(true);

    }
    void BuyfishManWithGem()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalFishManWhenEndRun += 1;
        ScoreCount.totalGemWhenEndRun -= 1;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fisherTradeGemconfirmPanel.SetActive(false);
    }
    void ExchangeWestWithBamboo()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.BuysomethingFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.totalSavewestWhenEndRun += 1;
        ScoreCount.totalBambooWhenEndRun -= 3;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        westTradeBambooConfirmPanel.SetActive(false);

    }
    void unlockSeabag()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.unlockItemFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        ScoreCount.isUnlockedSeabag = true;
        ScoreCount.totalCoinsWhenEndRun -= 1000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        seaBagConfirmPanel.SetActive(false);
        StartCoroutine(notification("Congratulation! You have unlocked SeaBag. Now you can collect Unlimited Items!!"));

    }

    void unlockCrossBow()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.unlockItemFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        StartCoroutine(notification("Congratulations! You Have unlocked Crossbow. Now buy arrow to use it"));
       ScoreCount.isUnlockedCrossBow = true;
        ScoreCount.totalCoinsWhenEndRun -= 1000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        CrossBowConfirmPanel.SetActive(false);

    }
    void unlockCanoe()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.unlockItemFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        StartCoroutine(notification("Congratulations! You Have unlocked Canoe. Now you can find Canoe on the water"));
        ScoreCount.isUnlockedCanoe = true;
        ScoreCount.totalCoinsWhenEndRun -= 1000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        canoeConfirmPanel.SetActive(false);

    }
    void unlockNutshell()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.unlockItemFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        StartCoroutine(notification("Congratulations! You Have unlocked Nutshell Boat. Now you can find Nutshell Boat on the water"));
        ScoreCount.isUnlockedNutshell = true;
        ScoreCount.totalCoinsWhenEndRun -= 2000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        NutshelConfirmPanel.SetActive(false);
    }
    void unlockFishingBoat()
    {
        AudioManager.instance.buttonPressSound.Play();
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
        AudioManager.instance.unlockItemFX.Play();
        AudioManager.instance.buttonPressSound.Play();
        StartCoroutine(notification("Congratulations! You Have unlocked Fishing Boat. Now you can find Fishing Boat on the water"));
        ScoreCount.isUnlockedFishingBoat = true;
        ScoreCount.totalCoinsWhenEndRun -= 5000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        fishingBoatConfirmPanel.SetActive(false);
    }
    void unlockShip()
    {
        AudioManager.instance.buttonPressSound.Play();
        //ship price 10000 $
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
        AudioManager.instance.buttonPressSound.Play();
        AudioManager.instance.buttonPressSound.Play();
        StartCoroutine(notification("Congratulations! You Have unlocked Ship & Ocean Environment. Now you can use Ship on the Ocean Environment"));
        ScoreCount.isUnlockedShip = true;
        ScoreCount.totalCoinsWhenEndRun -= 10000;
        itemIsBuyed = true;
        confirmationPanel.SetActive(false);
        noButtonObject.SetActive(false);
        shipConfirmPanel.SetActive(false);
    }




    void NoButtonPressed()
    {
        AudioManager.instance.buttonPressSound.Play();
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

        AudioManager.instance.buttonPressSound.Play();
        NotEnoughCoinPanel.SetActive(false);
        confirmationPanel.SetActive(false);
    }
    IEnumerator notification(string s)
    {
        notificationBG.SetActive(true);
        notificationtext.text = s;
        yield return new WaitForSeconds(2f);
        notificationtext.text = "";
        notificationBG.SetActive(false);
    }

}
