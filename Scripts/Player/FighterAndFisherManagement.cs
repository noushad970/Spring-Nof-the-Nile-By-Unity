using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterAndFisherManagement : MonoBehaviour
{
    [Header("Raft AI")]
    public GameObject RaftAINinja1;
    public GameObject RaftAINinja2, RaftAIFishMan1, RaftAIFishMan2;
    [Header("Canoe AI")]
    public GameObject CanoeAINinja1;
    public GameObject CanoeAINinja2, CanoeAIFishMan1, CanoeAIFishMan2;
    [Header("Nutshell AI")]
    public GameObject NutshellAINinja1;
    public GameObject NutshellAINinja2, NutshellAIFishMan1, NutshellAIFishMan2;
    [Header("FishBoat AI")]
    public GameObject FishBoatAINinja1;
    public GameObject FishBoatAINinja2, FishBoatAIFishMan1, FishBoatAIFishMan2;
    [Header("Buttons")]
    public Button ninjaButton,fishManButton;
    public GameObject ninjaButtonObject, fishManButtonObject;
    bool fish1Active, fish2Active,ninja1Active,ninja2Active,loop;
    int tabAmountfish, tabAmountninja;
    int totFishMan, totninja;
    private void Awake()
    {
        loop=true;
        fish1Active = fish2Active = false;
        tabAmountfish = 0;
        tabAmountninja = 0;
        ninja1Active = ninja2Active = false;
        //

        RaftAIFishMan1.SetActive(false);
        CanoeAIFishMan1.SetActive(false);
        NutshellAIFishMan1.SetActive(false);
        FishBoatAIFishMan1.SetActive(false);
        RaftAIFishMan2.SetActive(false);
        CanoeAIFishMan2.SetActive(false);
        NutshellAIFishMan2.SetActive(false);
        FishBoatAIFishMan2.SetActive(false);
        RaftAINinja1.SetActive(false);
        CanoeAINinja1.SetActive(false);
        NutshellAINinja1.SetActive(false);
        FishBoatAINinja1.SetActive(false);
        RaftAINinja2.SetActive(false);
        CanoeAINinja2.SetActive(false);
        NutshellAINinja2.SetActive(false);
        FishBoatAINinja2.SetActive(false);
    }
    private void Start()
    {
        ninjaButton.onClick.AddListener(choseNinja);
        fishManButton.onClick.AddListener(chooseFishMan);
    }
    private void Update()
    {
        if (loop)
        {
            StartCoroutine(LoadData());
            
        }
        if (totFishMan <= 0 || tabAmountfish>=2 || TriggerCollisionDetection.isSinglePlayer || TriggerCollisionDetection.playerisWithShip)
        {
            fishManButtonObject.SetActive(false);
        }
        else if(TriggerCollisionDetection.isPlayerWithBoat)
        {
            fishManButtonObject.SetActive(true);
        }
        if (totninja <= 0 || tabAmountninja>=2|| TriggerCollisionDetection.isSinglePlayer || TriggerCollisionDetection.playerisWithShip)
        {
            ninjaButtonObject.SetActive(false);
        }
        else if (TriggerCollisionDetection.isPlayerWithBoat)
        {
            ninjaButtonObject.SetActive(true);
        }
    }
    void AddAIFishMan1()
    {
        tabAmountfish += 1;
        ScoreCount.totalFishManWhenEndRun -= 1;
        totFishMan -= 1;
        Debug.Log("AddAIFishMan1");
        RaftAIFishMan1.SetActive(true);
        CanoeAIFishMan1.SetActive(true);
        NutshellAIFishMan1.SetActive(true);
        FishBoatAIFishMan1.SetActive(true);

        AudioManager.instance.enablePowerUp.Play();

    }
    void AddAIFishMan2()
    {
        Debug.Log("AddAIFishMan2");
        tabAmountfish += 1;
        ScoreCount.totalFishManWhenEndRun -= 1;
        totFishMan -= 1;
        AudioManager.instance.enablePowerUp.Play();

        RaftAIFishMan2.SetActive(true);
        CanoeAIFishMan2.SetActive(true);
        NutshellAIFishMan2.SetActive(true);
        FishBoatAIFishMan2.SetActive(true);

    }
    void AddAINinja1()
    {

        Debug.Log("AddAINinja1");
        tabAmountninja += 1;
        ScoreCount.totalFighterWhenEndRun -= 1;
        totninja -= 1;
        AudioManager.instance.enablePowerUp.Play();
        RaftAINinja1.SetActive(true);
        CanoeAINinja1.SetActive(true);
        NutshellAINinja1.SetActive(true);
        FishBoatAINinja1 .SetActive(true);
    }
    void AddAINinja2()
    {
        Debug.Log("AddAINinja2");
        tabAmountninja += 1;
        ScoreCount.totalFighterWhenEndRun -= 1;
        totninja -= 1;
        AudioManager.instance.enablePowerUp.Play();
        RaftAINinja2.SetActive(true);
        CanoeAINinja2.SetActive(true);
        NutshellAINinja2.SetActive(true);
        FishBoatAINinja2.SetActive(true);
    }
    void choseNinja()
    {
        if (tabAmountninja <= 2)
        {
            
            if (RaftAIFishMan1.activeSelf || CanoeAIFishMan1.activeSelf || NutshellAIFishMan1.activeSelf || FishBoatAIFishMan1.activeSelf)
            {
                AddAINinja2();
            }else if (RaftAINinja1.activeSelf || CanoeAINinja1.activeSelf || NutshellAINinja1.activeSelf || FishBoatAINinja1.activeSelf)
            {
                AddAINinja2();
            }
            else
            {
                AddAINinja1();
            }
        }
    }
    void chooseFishMan()
    {
        if (tabAmountfish <= 2)
        {
             if (RaftAINinja1.activeSelf || CanoeAINinja1.activeSelf || NutshellAINinja1.activeSelf || FishBoatAINinja1.activeSelf)
            {
                AddAIFishMan2();
            }
            else if (RaftAIFishMan1.activeSelf || CanoeAIFishMan1.activeSelf || NutshellAIFishMan1.activeSelf || FishBoatAIFishMan1.activeSelf)
            {
                AddAIFishMan2();
            }
            else
            {
                AddAIFishMan1();
            }
        }
    }
    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(.2f);
        totFishMan = ScoreCount.fisherman;
        totninja = ScoreCount.fighter;

        loop = false;
    }
}
