using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponReleaseSystem : MonoBehaviour
{
    public GameObject MacheteToSpawn,ArrowToSpawn;
    public Transform spawnPoint; 
    public float speed = 5f;
    GameObject spawnedObject;
    public Animator animWithBoat, animWithRaft; //animWithNutshelBoat, animWithFishingBoat;
    public Button MacheteThrowButton, ArrowThrowButton;
    public static bool playerAttackWithMachete = false, playerAttackWithArrow=false;
    void Start()
    {
         MacheteThrowButton.onClick.AddListener(attackWithMachete);
         ArrowThrowButton.onClick.AddListener(attackWithArrow);
        
        
    }

    private void Update()
    {
        if(spawnedObject!=null)
        {

            MoveForward(spawnedObject);
        }
    }
    void MoveForward(GameObject gm)
    {
        

            gm.transform.rotation = Quaternion.identity;
            gm.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        
    }

    void attackWithMachete()
    {
        if (TriggerCollisionDetection.isPlayerWithBoat || TriggerCollisionDetection.isSinglePlayer)
        {
            if (spawnPoint != null)
            {
                animWithBoat.Play("Shoot");
                spawnedObject = Instantiate(MacheteToSpawn, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(wait25Sec());
                MoveForward(spawnedObject);


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
                MoveForward(spawnedObject);
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
