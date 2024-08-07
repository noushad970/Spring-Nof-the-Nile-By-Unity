using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
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

    [Header("In game Object Selection System")]
    public GameObject harpoon;
    public GameObject machete;
    public GameObject HandRudder;
    public GameObject BoatRudder;
    
    public CharacterController controller;
    void Awake()
    {
        OnlyChar.SetActive(true);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithShip.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        CharacterAppearenceChange();
        collectItems();
        enableAndDissableWeapon();

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
            StartCoroutine(EnableRaft());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat=false;
            StartCoroutine (DestroyRaft());
        }

        if (TriggerCollisionDetection.isGetCanoeItem)
        {
            TriggerCollisionDetection.isGetCanoeItem = false;
            StartCoroutine(EnableCanoe());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat = false;
            StartCoroutine(DestroyCanoe());
        }
        if (TriggerCollisionDetection.isGetNutshellBoatItem)
        {
            TriggerCollisionDetection.isGetNutshellBoatItem = false;
            StartCoroutine(EnableNutshell());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat = false;
            StartCoroutine(DestroyNutshell());
        }
        if (TriggerCollisionDetection.isGetFishingBoatItem)
        {
            TriggerCollisionDetection.isGetFishingBoatItem = false;
            StartCoroutine(EnableFishingBoat());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat = false;
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
        if (TriggerCollisionDetection.isHitFruitItem)
        {
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitFruitItem=false;
        }
        if (TriggerCollisionDetection.isHitWithCoin)
        {
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithCoin = false;
        }
        if (TriggerCollisionDetection.isHitBambooItem)
        {
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitBambooItem = false;
        }
        if (TriggerCollisionDetection.isHitWoodItem)
        {
            hitWithItemParticleSystem.Play();
            TriggerCollisionDetection.isHitWoodItem=false;
        }
        if (TriggerCollisionDetection.isHitWithGem)
        {
            hitWithGemParticleSystem.Play();
            TriggerCollisionDetection.isHitWithGem=false;
        }
        if (TriggerCollisionDetection.isHitWithHeart)
        {
            hitWithHeartParticle.Play();
            TriggerCollisionDetection.isHitWithHeart = false;

        }
        //other

    }
    IEnumerator EnableRaft()
    {
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithRaft.SetActive(true);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 0.52f, -0.86f);
        controller.height = 2.57f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyRaft()
    {
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(true);
        controller.center = new Vector3(0, 0, 0.34f);
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator EnableCanoe()
    {
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithCanoe.SetActive(true);
        CharWithRaft.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false); OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 0.52f, -0.86f);
        controller.height = 2.57f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyCanoe()
    {
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);
        CharWithCanoe.SetActive(false);
        CharWithRaft.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(true);
        controller.center = new Vector3(0, 0, 0.34f);
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator EnableNutshell()
    {
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithNutshell.SetActive(true);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 0.52f, -0.86f);
        controller.height = 2.57f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyNutshell()
    {
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);
        CharWithNutshell.SetActive(false);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(true);
        controller.center = new Vector3(0, 0, 0.34f);
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator EnableFishingBoat()
    {
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithFishing.SetActive(true);
        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 0.52f, -0.86f);
        controller.height = 2.57f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyFishingBoat()
    {
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);

        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(false);
        OnlyChar.SetActive(true);
        controller.center = new Vector3(0, 0, 0.34f);
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
    IEnumerator EnableShip()
    {
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        OnlyChar.SetActive(false);

        CharWithRaft.SetActive(false);
        CharWithCanoe.SetActive(false);
        CharWithFishing.SetActive(false);
        CharWithNutshell.SetActive(false);
        CharWithShip.SetActive(true);
        controller.center = new Vector3(0f, 0.52f, -0.86f);
        controller.height = 2.57f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyShip()
    {
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

}
