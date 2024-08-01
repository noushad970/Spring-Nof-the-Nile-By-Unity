using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponReleaseSystem : MonoBehaviour
{
    public GameObject MacheteToSpawn,ArrowToSpawn;
    public Transform spawnPoint; 
    public float speed = 5f;
    public Animator animWithBoat, animWithRaft; //animWithNutshelBoat, animWithFishingBoat;
   // public Button MacheteThrowButton, ArrowThrowButton;
    public static bool playerAttackWithMachete = false, playerAttackWithArrow=false;
    void Start()
    {
       // MacheteThrowButton.onClick.AddListener(attackWithMachete);
       // ArrowThrowButton.onClick.AddListener(attackWithArrow);
        attackWithArrow();
        
    }

  

    System.Collections.IEnumerator MoveForward(GameObject obj)
    {
        while (true)
        {
            obj.transform.rotation= Quaternion.identity;    
            obj.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            yield return null;
        }
    }
    void attackWithMachete()
    {
        if (TriggerCollisionDetection.isPlayerWithBoat )
        {
            if (spawnPoint != null)
            {
                animWithBoat.Play("Shoot");
                GameObject spawnedObject = Instantiate(MacheteToSpawn, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(wait25Sec());
                StartCoroutine(MoveForward(spawnedObject));
            }
            else
            {
                Debug.LogError("Spawn point is not set.");
            }
        }
    }
    void attackWithArrow()
    {
        if (TriggerCollisionDetection.isPlayerWithBoat || TriggerCollisionDetection.isSinglePlayer)
        {
            if (spawnPoint != null)
            {
                animWithBoat.Play("Arrow");
                GameObject spawnedObject = Instantiate(ArrowToSpawn, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(wait203Sec());
                StartCoroutine(MoveForward(spawnedObject));
            }
            else
            {
                Debug.LogError("Spawn point is not set.");
            }
        }
    }
    IEnumerator wait25Sec()
    {
        playerAttackWithMachete = true;
        yield return new WaitForSeconds(0.25f);
        playerAttackWithMachete = false;
    }
    IEnumerator wait203Sec()
    {
        playerAttackWithArrow = true;
        yield return new WaitForSeconds(2.3f);
        playerAttackWithArrow = false;
    }
}
