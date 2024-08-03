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
        if (TriggerCollisionDetection.isPlayerWithBoat && !playerAttackWithArrow)
        {
            if (spawnPoint != null)
            {
                animWithBoat.Play("MeleeThrow");
                spawnedObject = Instantiate(MacheteToSpawn, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(wait25Sec());
                StartCoroutine(wait7Sec());
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
        if (TriggerCollisionDetection.isPlayerWithBoat && !playerAttackWithMachete)
        {
            if (spawnPoint != null)
            {
                animWithBoat.Play("Shoot");
                spawnedObject = Instantiate(ArrowToSpawn, spawnPoint.position, spawnPoint.rotation);
                StartCoroutine(wait203Sec());
                StartCoroutine(wait7Sec());
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
        yield return new WaitForSeconds(1f);
        playerAttackWithMachete = false;
    }
    IEnumerator wait203Sec()
    {
        playerAttackWithArrow = true;
        yield return new WaitForSeconds(2.16f);
        playerAttackWithArrow = false;
    }
    IEnumerator wait7Sec()
    {
        MacheteThrowButton.enabled = false;
        ArrowThrowButton.enabled = false;
        yield return new WaitForSeconds(7f);

        MacheteThrowButton.enabled = true;
        ArrowThrowButton.enabled = true;
    }
}
