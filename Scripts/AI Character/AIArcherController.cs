using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIArcherController : MonoBehaviour
{
    public GameObject archerArrow;
    public GameObject arrowClone;
    float timer = 4f;
    bool isShooting = false;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isShooting && TriggerCollisionDetection.AINinjeDetectEnemy)
        {

            StartCoroutine(attackArcher());
            TriggerCollisionDetection.AINinjeDetectEnemy = false;

        }
        
        timer += Time.deltaTime;
    }

    IEnumerator attackArcher()
    {
        isShooting = true;
        anim.Play("Shoot");
        archerArrow.SetActive(false);
        yield return new WaitForSeconds(0.9f);
        archerArrow.SetActive(true);
        yield return new WaitForSeconds(2.3f);
        archerArrow.SetActive(false);
        GameObject arClone = Instantiate(arrowClone, arrowClone.transform.position, arrowClone.transform.rotation);
        arClone.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        isShooting = false;

    }
}
