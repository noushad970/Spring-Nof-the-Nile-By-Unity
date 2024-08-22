using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;
    [Header("All Player Modes")]
    public GameObject OnlyChar;
    public GameObject CharWithRaft;
    public GameObject CharWithCanoe;
    public GameObject CharWithNutshell;
    public GameObject CharWithFishing;
    public GameObject CharWithShip;
    //public GameObject CharWithShip;

    [Header("Particle GameObject")]
    public GameObject upgradeCharParticle;
    public GameObject destroyBoatParticle;
    public GameObject destroyShipParticle;
    [Header("Particle System")]
    public ParticleSystem hitWithItemParticleSystem;
    public ParticleSystem hitWithGemParticleSystem;
    public ParticleSystem hitWithHeartParticle;
    public ParticleSystem hitWithFruitParticle;

    [Header("In game Object Selection System")]
    public GameObject harpoon;
    public GameObject machete;
    public GameObject HandRudder;
    public GameObject BoatRudder;
    [Header("All Vehicle Detection")]
    public static bool isActivateRaft=false;
    public static bool isActivateCanoe = false;
    public static bool isActivateNutshel = false;
    public static bool isActivateFishingBoat = false;
    public static bool isActivateShip = false;

    [Header("All Items Collection amount")]
    public TMP_Text coinText;
    public TMP_Text FruitText, MeatText, FishText, GemText;
    public CharacterController controller;
    [Header("Light Control")]
    public GameObject darkLight;
    public GameObject lightLight;
    void Awake()
    {
        instance = this;
        OnlyChar.SetActive(true);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithShip.SetActive(false);
        isActivateRaft = false;
        isActivateCanoe = false;
        isActivateNutshel = false;
        isActivateFishingBoat = false;
        isActivateShip = false;
       

    }

    // Update is called once per frame
    void Update()
    {
        CharacterAppearenceChange();
        collectItems();
        enableAndDissableWeapon();
        ItemAmmountShow();
        if (PlayerController.playerSliding)
        {
            StartCoroutine(SlidingOff());
        }
        if (TriggerCollisionDetection.isDeepDarkShore)
        {
            darkLight.SetActive(true);
            lightLight.SetActive(false);
        }
        else
        {
            darkLight.SetActive(false);
            lightLight.SetActive(true);

        }
        
    }
    void ItemAmmountShow()
    {
        coinText.text = ScoreCount.totalCoinsWhenEndRun.ToString();
        FruitText.text=ScoreCount.totalFruitWhenEndRun.ToString();
        FishText.text=ScoreCount.totalFishWhenEndRun.ToString();
        GemText.text=ScoreCount.totalGemWhenEndRun.ToString();
        MeatText.text=ScoreCount.totalMeatWhenEndRun.ToString();
    }
    void enableAndDissableWeapon()
    {
        if (WeaponReleaseSystem.playerAttackWithArrow)
        {
            harpoon.SetActive(true);
            BoatRudder.SetActive(true);
            machete.SetActive(false);
            HandRudder.SetActive(false);

        }
        if (WeaponReleaseSystem.playerAttackWithMachete)
        {

            harpoon.SetActive(false);
            BoatRudder.SetActive(true);
            machete.SetActive(true);
            HandRudder.SetActive(false);
        }
        if(!WeaponReleaseSystem.playerAttackWithMachete && !WeaponReleaseSystem.playerAttackWithArrow)
        {

            harpoon.SetActive(false);
            BoatRudder.SetActive(false);
            machete.SetActive(false);
            HandRudder.SetActive(true);
        }
    }
    void CharacterAppearenceChange()
    {
        if (TriggerCollisionDetection.isGetRaftItem)
        {
            TriggerCollisionDetection.isGetRaftItem=false;
            TriggerCollisionDetection.isSinglePlayer=false;
            TriggerCollisionDetection.isPlayerWithBoat = true;
            StartCoroutine(EnableRaft());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat=false;
            TriggerCollisionDetection.isSinglePlayer = true;
            TriggerCollisionDetection.isPlayerWithBoat = false;
            StartCoroutine (DestroyRaft());
        }

        if (TriggerCollisionDetection.isGetCanoeItem)
        {
            TriggerCollisionDetection.isGetCanoeItem = false;
            TriggerCollisionDetection.isSinglePlayer = false;
            TriggerCollisionDetection.isPlayerWithBoat = true;
            StartCoroutine(EnableCanoe());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat = false;
            TriggerCollisionDetection.isSinglePlayer = true;
            TriggerCollisionDetection.isPlayerWithBoat = false;
            StartCoroutine(DestroyCanoe());
        }
        if (TriggerCollisionDetection.isGetNutshellBoatItem)
        {
            TriggerCollisionDetection.isGetNutshellBoatItem = false;
            TriggerCollisionDetection.isSinglePlayer = false;
            TriggerCollisionDetection.isPlayerWithBoat = true;
            StartCoroutine(EnableNutshell());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat = false;
            TriggerCollisionDetection.isSinglePlayer = true;
            TriggerCollisionDetection.isPlayerWithBoat = false;
            StartCoroutine(DestroyNutshell());
        }
        if (TriggerCollisionDetection.isGetFishingBoatItem)
        {
            TriggerCollisionDetection.isGetFishingBoatItem = false;
            TriggerCollisionDetection.isSinglePlayer = false;
            TriggerCollisionDetection.isPlayerWithBoat = true;
            StartCoroutine(EnableFishingBoat());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat = false;
            TriggerCollisionDetection.isSinglePlayer = true;
            TriggerCollisionDetection.isPlayerWithBoat = false;
            StartCoroutine(DestroyFishingBoat());
        }
        if (TriggerCollisionDetection.isGetShipItem)
        {
            TriggerCollisionDetection.isGetShipItem = false;
            StartCoroutine(EnableShip());
        }
        if (TriggerCollisionDetection.ShipIsCollideWithObstacle)
        {
            TriggerCollisionDetection.ShipIsCollideWithObstacle = false;
            StartCoroutine(ShipCollideWithOstacle());
        }
    }

    void collectItems()
    {
        if (TriggerCollisionDetection.isHitFruitItem && ScoreCount.isUnlockedSeabag)
        {
            ScoreCount.totalFruitWhenEndRun += 1;
            hitWithFruitParticle.Play();
            TriggerCollisionDetection.isHitFruitItem=false;
        }
        else if(TriggerCollisionDetection.isHitFruitItem && !ScoreCount.isUnlockedSeabag && ScoreCount.totalItems<=100)
        {
            ScoreCount.totalFruitWhenEndRun += 1;
            hitWithFruitParticle.Play();
            TriggerCollisionDetection.isHitFruitItem = false;
        }
        if (TriggerCollisionDetection.isHitWithCoin && ScoreCount.isUnlockedSeabag)
        {
            ScoreCount.totalCoinsWhenEndRun += 1;
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithCoin = false;
        }else if(TriggerCollisionDetection.isHitWithCoin && !ScoreCount.isUnlockedSeabag && ScoreCount.totalItems <= 100)
        {
            ScoreCount.totalCoinsWhenEndRun += 1;
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithCoin = false;
        }
        else
        {
            Debug.Log("Storage Full");
        }
        if (TriggerCollisionDetection.isHitBambooItem && ScoreCount.isUnlockedSeabag)
        {
            hitWithItemParticleSystem.Play();
            ScoreCount.totalBambooWhenEndRun += 1;
            TriggerCollisionDetection.isHitBambooItem = false;
        }else if (TriggerCollisionDetection.isHitBambooItem && !ScoreCount.isUnlockedSeabag && ScoreCount.totalItems <= 100)
        {
            hitWithItemParticleSystem.Play();
            ScoreCount.totalBambooWhenEndRun += 1;
            TriggerCollisionDetection.isHitBambooItem = false;
        }
        if (TriggerCollisionDetection.isHitWoodItem && ScoreCount.isUnlockedSeabag)
        {
            ScoreCount.totalWoodWhenEndRun += 1;
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWoodItem=false;
        }else if (TriggerCollisionDetection.isHitWoodItem && !ScoreCount.isUnlockedSeabag && ScoreCount.totalItems <= 100)
        {
            ScoreCount.totalWoodWhenEndRun += 1;
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWoodItem = false;
        }
        if (TriggerCollisionDetection.isHitWithGem && ScoreCount.isUnlockedSeabag)
        {
            ScoreCount.totalGemWhenEndRun += 1;
            hitWithGemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithGem=false;
        }
        else if (TriggerCollisionDetection.isHitWithGem && !ScoreCount.isUnlockedSeabag && ScoreCount.totalItems <= 100)
        {
            ScoreCount.totalGemWhenEndRun += 1; 
            hitWithGemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithGem = false;
        }
        if (TriggerCollisionDetection.isHitWithHeart)
        {
            hitWithHeartParticle.Play();
            TriggerCollisionDetection.isHitWithHeart = false;

        }
        if (TriggerCollisionDetection.ArcherStartAttacking)
        {
            StartCoroutine(archerStopAttack());
        }
        if (TriggerCollisionDetection.isHitWithMeat && ScoreCount.isUnlockedSeabag)
        {
            ScoreCount.totalMeatWhenEndRun += 1;
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithMeat = false;
        }else if (TriggerCollisionDetection.isHitWithMeat && !ScoreCount.isUnlockedSeabag && ScoreCount.totalItems<=100)
        {
            ScoreCount.totalMeatWhenEndRun += 1;
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithMeat = false;
        }
        if (TriggerCollisionDetection.isHitWithFish && ScoreCount.isUnlockedSeabag)
        {
            ScoreCount.totalFishWhenEndRun += 1;
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithFish = false;
        }else if (TriggerCollisionDetection.isHitWithFish && !ScoreCount.isUnlockedSeabag && ScoreCount.totalItems<=100)
        {
            ScoreCount.totalFishWhenEndRun += 1;
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithFish = false;
        }

    }
    IEnumerator archerStopAttack()
    {
        yield return new WaitForSeconds(10);
        TriggerCollisionDetection.ArcherStartAttacking = false;
    }
    IEnumerator EnableRaft()
    {
        isActivateRaft=true;
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithRaft.SetActive(true);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 0.6f, 1.17f);
        controller.height = 2.1f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyRaft()
    {
        isActivateRaft=false;
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(true);
        controller.center = new Vector3(0, 0.75f, 0.45f);
        controller.radius = .5f;
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator EnableCanoe()
    {
        isActivateCanoe=true;
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithCanoe.SetActive(true);
        CharWithRaft.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false); OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 0.53f, -1.33f);
        controller.height = 1.57f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyCanoe()
    {
        isActivateCanoe = false;
        destroyShipParticle.SetActive(true);
        yield return new WaitForSeconds(.4f);
        CharWithCanoe.SetActive(false);
        CharWithRaft.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(true); 
        controller.center = new Vector3(0, 0.75f, 0.45f);
        controller.radius = .5f;
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator EnableNutshell()
    {
        isActivateNutshel = true;
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithNutshell.SetActive(true);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 1.57f, -0.74f);
        controller.height = 2.67f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyNutshell()
    {
        isActivateNutshel= false;
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);
        CharWithNutshell.SetActive(false);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(true);
        controller.center = new Vector3(0, 0.75f, 0.45f);
        controller.radius = .5f;
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator EnableFishingBoat()
    {
        isActivateFishingBoat = true;
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithFishing.SetActive(true);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 1.57f, -0.74f);
        controller.height = 2.67f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyFishingBoat()
    {
        isActivateFishingBoat= false;
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);

        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(true);
        controller.center = new Vector3(0, 0.75f, 0.45f);
        controller.radius = .5f;
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator EnableShip()
    {
        isActivateShip= true;
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        OnlyChar.SetActive(false);

        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(true);
        controller.center = new Vector3(0f, 0.52f, 4.55f);
        controller.height = 2.57f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyShip()
    {
        isActivateShip = false;
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);

        OnlyChar.SetActive(false);
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator ShipCollideWithOstacle()
    {
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator SlidingOff()
    {
        yield return new WaitForSeconds(2f);
        PlayerController.playerSliding = false;

    }


}
