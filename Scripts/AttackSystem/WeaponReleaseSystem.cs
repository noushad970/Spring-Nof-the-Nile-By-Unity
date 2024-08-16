using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponReleaseSystem : MonoBehaviour
{
    public GameObject MacheteToSpawn,ArrowToSpawn, safariTikMark;
    public Text arrowAmount, macheteAmount, safariHatAmount;
    public ParticleSystem enablePowerUpParticleSystem;
    public Transform spawnPoint; 
    public float speed = 5f;
    GameObject spawnedObject;
     //animWithNutshelBoat, animWithFishingBoat;
    public Button MacheteThrowButton, ArrowThrowButton,safariHatButton;
    public GameObject MacheteThrowButtonObject, ArrowThrowButtonObject,safariHatButtonObject;
    public static bool playerAttackWithMachete = false, playerAttackWithArrow=false,isEnableSafariHat=false;
    bool loop,safariClicked;
    int totalArrow,totalMachete,totalSafari;
    void Start()
    {
        loop = false;
         MacheteThrowButton.onClick.AddListener(attackWithMachete);
         ArrowThrowButton.onClick.AddListener(attackWithArrow);
        safariClicked=false;
        safariHatButton.onClick.AddListener(ClickOnSafariHat);
        safariTikMark.SetActive(false);
        isEnableSafariHat = false;


    }

    private void Update()
    {
        if (!loop)
        {
            StartCoroutine(LoadData());
            loop = true;
        }
        if(spawnedObject!=null)
        {
            MoveForward(spawnedObject);
        }
        if (totalMachete > 0 && TriggerCollisionDetection.isPlayerWithBoat )
        {
            MacheteThrowButtonObject.SetActive(true);
        }
        else if (totalMachete <= 0 || TriggerCollisionDetection.isSinglePlayer|| TriggerCollisionDetection.playerisWithShip)
        {
            MacheteThrowButtonObject.SetActive(false);
        }
        if(totalArrow > 0 && TriggerCollisionDetection.isPlayerWithBoat && ScoreCount.isUnlockedCrossBow)
        {
            ArrowThrowButtonObject.SetActive(true);
        }
        else if(totalMachete <= 0 || TriggerCollisionDetection.isSinglePlayer ||TriggerCollisionDetection.playerisWithShip)
        {
            ArrowThrowButtonObject.SetActive(false);
        }
        if (totalSafari > 0)
        {
            safariHatButtonObject.SetActive(true);
        }
        else
        {
            safariHatButtonObject.SetActive(false);
        }
        arrowAmount.text = totalArrow.ToString();
        macheteAmount.text = totalMachete.ToString();
        safariHatAmount.text = totalSafari.ToString();
        if (VestManagement.finallyGameOver)
        {
            safariClicked = false;
            safariTikMark.SetActive(false);
        }

    }
    void MoveForward(GameObject gm)
    {
        

            gm.transform.rotation = Quaternion.identity;
            gm.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        
    }
    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(0.1f);
        totalArrow = ScoreCount.arrow;
        totalMachete=ScoreCount.machete;
        totalSafari = ScoreCount.safariHat;
    }
    void attackWithMachete()
    {
        
        if (TriggerCollisionDetection.isPlayerWithBoat && !playerAttackWithArrow)
        {
            totalMachete -= 1;
            ScoreCount.totalMacheteWhenEndRun -= 1;
            if (spawnPoint != null)
            {
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
            totalArrow -= 1;
            ScoreCount.totalArrowWhenEndRun -= 1;
            if (spawnPoint != null)
            {
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
        yield return new WaitForSeconds(5f);

        MacheteThrowButton.enabled = true;
        ArrowThrowButton.enabled = true;
    }
    void ClickOnSafariHat()
    {
        if (!safariClicked)
        {
            AudioManager.instance.enablePowerUp.Play();
            totalSafari -= 1;
            ScoreCount.totalSafariWhenEndRun -= 1;
            enablePowerUpParticleSystem.Play();
            safariClicked = true;
            safariTikMark.SetActive(true);
            isEnableSafariHat = true;
        }
    }
}
