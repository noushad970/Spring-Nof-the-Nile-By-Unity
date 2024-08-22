using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VestManagement : MonoBehaviour
{
    public Button vestEnableButton;
    public GameObject vestButton;
    public static bool VestIsEnable=false,finallyGameOver=false;
    bool readyForAnotherVest=true;
    public GameObject tikMark;
    int totVest;
    public ParticleSystem lifeLostParticle,enableItemParticle;
    bool loop=false;
    // Start is called before the first frame update
    void Awake()
    {
        loop = false;
        VestIsEnable = false;
        tikMark.SetActive(false);
        readyForAnotherVest = true;
    }
    private void Start()
    {
        vestEnableButton.onClick.AddListener(manageVest);
    }

    // Update is called once per frame
    void Update()
    {
        if (!loop)
        {
            StartCoroutine(LoadData());
        }
        if (totVest > 0)
        {
            vestButton.SetActive(true);
        }
        else
        {
            vestButton.SetActive(false);
        }
        if(VestIsEnable && TriggerCollisionDetection.GameOver)
        {
            VestIsEnable = false;
            lifeLostParticle.Play();
            PlayerController.PlayerHealth = 100;
            if (PlayerController.isFighting)
            {
                PlayerController.isFighting = false;
            }
            TriggerCollisionDetection.GameOver= false;
            tikMark.SetActive(false);
            StartCoroutine(wait2Sec());
        }
        if(!VestIsEnable && TriggerCollisionDetection.GameOver)
        {
            finallyGameOver = true;

            PlayerController.PlayerHealth = 100;
            tikMark.SetActive(false);
            TriggerCollisionDetection.GameOver = false;
        }
        if (VestIsEnable)
        {
            tikMark.SetActive(true);
        }

    }
    void manageVest()
    {
        if (totVest > 0 && !VestIsEnable && readyForAnotherVest)
        {
            AudioManager.instance.enablePowerUp.Play();
            enableItemParticle.Play();
            tikMark.SetActive(true);
            readyForAnotherVest = false;
            totVest -= 1;
            ScoreCount.totalSavewestWhenEndRun -= 1;
            VestIsEnable = true;
        }
        
    }
    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(.1f);
        totVest = ScoreCount.savingWest;

        loop = true;
    }
    IEnumerator wait2Sec()
    {
        yield return new WaitForSeconds(3f);
        readyForAnotherVest = true;
    }
}
