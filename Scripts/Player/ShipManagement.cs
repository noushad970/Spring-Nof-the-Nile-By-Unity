using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipManagement : MonoBehaviour
{
    public GameObject repairShipWithRope, repairShipWithHammer;
    public Button repairShipWithRopeButton, repairShipWithHammerButton;
    float totRope,totHammer;
    bool loop=false;
    public Text totalRope, totalHammer;
    public ParticleSystem repairParticle;
    public Text shipHealth;
    // Start is called before the first frame update
    private void Awake()
    {
        loop = false;
    }
    void Start()
    {
        
        repairShipWithHammerButton.onClick.AddListener(repairWithHammer);
        repairShipWithRopeButton.onClick.AddListener(repairWithRope);

    }
    private void Update()
    {
        if (!loop)
        {
            StartCoroutine(LoadData());
        }
        Debug.Log("total Hammer: " + totHammer + " : " + ScoreCount.hammer+ " Ship Active: " + InGameManager.isActivateShip + " Ship Health: " + TriggerCollisionDetection.shipHealth);
        Debug.Log("total Rope: " + totRope+" : "+ScoreCount.rope + " Ship Active: " + InGameManager.isActivateShip + " Ship Health: " + TriggerCollisionDetection.shipHealth);

        if (totHammer > 0 && InGameManager.isActivateShip && TriggerCollisionDetection.shipHealth<100)
        {
            repairShipWithHammer.SetActive(true);
        }
        else
        {
            repairShipWithHammer.SetActive(false);
        }
        if (totRope > 0 && InGameManager.isActivateShip && TriggerCollisionDetection.shipHealth<100)
        {

            repairShipWithRope.SetActive(true);
        }
        else
        {

            repairShipWithRope.SetActive(false);
        }
        totalHammer.text = totHammer.ToString();
        totalRope.text=totRope.ToString();
        if (TriggerCollisionDetection.playerisWithShip )
        {
            shipHealth.text = "Ship Health: "+TriggerCollisionDetection.shipHealth.ToString();
        }
        else
        {
            shipHealth.text = "";
        }
    }

    void repairWithHammer()
    {
        AudioManager.instance.repairSound.Play();
        totRope -= 1;
        repairParticle.Play();
        ScoreCount.totalHammerWhenEndRun -= 1;
        TriggerCollisionDetection.shipHealth += 25;

    }
    void repairWithRope()
    {
        AudioManager.instance.repairSound.Play();
        totHammer -= 1;
        repairParticle.Play();
        ScoreCount.totalHammerWhenEndRun -=1;
        TriggerCollisionDetection.shipHealth += 25;
    }
    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(0.2f);
        totHammer = ScoreCount.hammer;
        totRope = ScoreCount.rope;

        loop = true;
    }
}
