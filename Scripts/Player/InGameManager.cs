using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [Header("All Player Modes")]
    public GameObject OnlyChar;
    public GameObject CharWithBoat;
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
        CharWithBoat.SetActive(false);
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
        if (TriggerCollisionDetection.isGetBoatItem)
        {
            TriggerCollisionDetection.isGetBoatItem=false;
            StartCoroutine(EnableBoat());
        }
        if (TriggerCollisionDetection.isDestroyBoat)
        {
            TriggerCollisionDetection.isDestroyBoat=false;
            StartCoroutine (DestroyBoat());
        }
    }

    void collectItems()
    {
        if (TriggerCollisionDetection.isHitFruitItem)
        {
            hitWithItemParticleSystem.Play();
        }
        if (TriggerCollisionDetection.isHitWithCoin)
        {
            hitWithItemParticleSystem.Play();
        }
        if (TriggerCollisionDetection.isHitBambooItem)
        {
            hitWithItemParticleSystem.Play();
        }
        if (TriggerCollisionDetection.isHitWoodItem)
        {
            hitWithItemParticleSystem.Play();
        }
        if (TriggerCollisionDetection.isHitWithGem)
        {
            hitWithGemParticleSystem.Play();
        }
        if (TriggerCollisionDetection.isHitWithHeart)
        {
            hitWithHeartParticle.Play();
        }
        //other

    }
    IEnumerator EnableBoat()
    {
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithBoat.SetActive(true);
        OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 0.52f, -0.86f);
        controller.height = 2.57f;
        yield return new WaitForSeconds(0.2f);
        upgradeCharParticle.SetActive(false);
    }
    IEnumerator DestroyBoat()
    {
        destroyShipParticle.SetActive(true);

        yield return new WaitForSeconds(.4f);
        CharWithBoat.SetActive(false);
        OnlyChar.SetActive(true);
        controller.center = new Vector3(0, 0, 0.34f);
        controller.height = 1f;
        yield return new WaitForSeconds(1f);
        destroyShipParticle.SetActive(false);

    }
}
