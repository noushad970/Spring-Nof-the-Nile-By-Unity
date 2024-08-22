using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FishingManagement : MonoBehaviour
{
    public GameObject fishingRodUpTarget, fishingRodDownTarget,fishingRodPosition, fishingRodThrowButtonObject, catchFishButtonButton;
    public Animator fishingAnim;
    public float speed = 5f;
    bool ReadyToThrow = true,readyToSnatchRod=false;
    public Button fishingRodThrowButton,catchFishButton;
    public Text notificationText;
    int catchCount = 0;
    bool isBoatFishing;
    private void Awake()
    {

        catchCount = 0;
        readyToSnatchRod = false;
        ReadyToThrow = true;
        isBoatFishing = true;
        fishingRodThrowButtonObject.SetActive(false);
        catchFishButtonButton.SetActive(false);
    }
    private void Start()
    {
        fishingRodThrowButton.onClick.AddListener(startFishing1);
        catchFishButton.onClick.AddListener(CatchFish1);
    }

    private void Update()
    {
        if(isBoatFishing && InGameManager.isActivateFishingBoat)
        {
            isBoatFishing=false;
            fishingRodThrowButtonObject.SetActive(true);
            catchFishButtonButton.SetActive(false);
        }
        if (!InGameManager.isActivateFishingBoat)
        {
            isBoatFishing = true;
            fishingRodThrowButtonObject.SetActive(false);
            catchFishButtonButton.SetActive(false);
        }

    }
    void startFishing1()
    {
        AudioManager.instance.enablePowerUp.Play();
        if (ReadyToThrow)
        {
            fishingAnim.Play("StartFishing");
            ReadyToThrow = false;
            StartCoroutine(timingForRodUp());
        }
    }

    void CatchFish1()
    {
        if (catchCount == 0)
        {
            catchCount = 1;
            fishingRodThrowButtonObject.SetActive(false);
            catchFishButtonButton.SetActive(false);
            fishingAnim.Play("Pull");
            if (readyToSnatchRod)
            {
                int fishCount = Random.Range(1, 4);
                ScoreCount.totalFishWhenEndRun += fishCount;
                notificationText.text="You have collected "+ fishCount + " Fish's";
                AudioManager.instance.getbonusFx.Play();
                fishCount = 0;
            }else if (!readyToSnatchRod)
            {
                notificationText.text = "Better Luck Next Time";
            }
            StartCoroutine(backToNormalPosition());
        }
    }
    IEnumerator backToNormalPosition()
    {
        
        yield return new WaitForSeconds(5f);
        ReadyToThrow = true;
        catchCount = 0;
        fishingRodThrowButtonObject.SetActive(true);
        catchFishButtonButton.SetActive(false);
       
    }
    IEnumerator timingForRodUp()
    {
        fishingRodThrowButtonObject.SetActive(false);
        catchFishButtonButton.SetActive(true);
        readyToSnatchRod = false;
        notificationText.text = "";
        yield return new WaitForSeconds(5f);
        int timer = Random.Range(1, 4);
        notificationText.text = "Click on fishing Button";
        readyToSnatchRod = true;
        yield return new WaitForSeconds(timer);
        notificationText.text = "";
        readyToSnatchRod=false;
    }
}
