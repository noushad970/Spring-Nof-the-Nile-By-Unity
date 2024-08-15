using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AIVillagerControl : MonoBehaviour
{
    public Animator anim;
    bool rodThrow = false, catchFish = false;
    void Awake()
    {
        rodThrow = true;
    }

    void Update()
    {
        if (rodThrow)
        {
            rodThrow = false;
            StartCoroutine(AIFishermanFishingSequence());
        }
    }
    IEnumerator AIFishermanFishingSequence()
    {
        int timer1 = Random.Range(3, 8);
        yield return new WaitForSeconds(timer1);
        anim.Play("throw");
        yield return new WaitForSeconds(timer1);
        anim.Play("Pull");

        AudioManager.instance.getbonusFx.Play();
        int fishCount = Random.Range(1, 4);
        ScoreCount.totalFishWhenEndRun += fishCount;
        fishCount = 0;
        yield return new WaitForSeconds(3);
        rodThrow=true;
    }
}
