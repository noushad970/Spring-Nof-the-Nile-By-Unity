using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [Header("All Player Modes")]
    public GameObject OnlyChar;
    public GameObject CharWithBoat;
    //public GameObject CharWithShip;

    [Header("Particle Systems")]
    public GameObject upgradeCharParticle;
    public GameObject destroyBoatParticle;
    public GameObject destroyShipParticle;
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
    IEnumerator EnableBoat()
    {
        upgradeCharParticle.SetActive(true);
        yield return new WaitForSeconds(1);
        CharWithBoat.SetActive(true);
        OnlyChar.SetActive(false);
        controller.center = new Vector3(0f, 0.52f, 0.34f);
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
