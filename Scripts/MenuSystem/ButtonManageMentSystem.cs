using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class ButtonManageMentSystem : MonoBehaviour
{
    public int totArrow, totMachete, totSafari;
    public bool loop;
    private void Awake()
    {
        loop = false;
        TriggerCollisionDetection.shipSpawn = 0;
    }
    private void Update()
    {
        if (!loop)
        {
            StartCoroutine(LoadData());
        }
        


    }
    IEnumerator LoadData()
    {
        yield return new WaitForSeconds(.3f);
        totArrow = ScoreCount.arrow;
        totMachete = ScoreCount.machete;
        totSafari = ScoreCount.safariHat;

        loop = true;
    }
}
