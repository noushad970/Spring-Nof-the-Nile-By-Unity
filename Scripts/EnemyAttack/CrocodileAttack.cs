using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileAttack : MonoBehaviour
{

    Animator Anim;
    public static int CrocodileHealth;
    float timer = 4f;
    public static bool playPlayerDamageAnim = false;
    Collider col;
    private void Start()
    {
        Anim = GetComponent<Animator>();
        col = GetComponent<Collider>();

    }
    private void Awake()
    {
        CrocodileHealth = 100;
    }
    private void Update()
    {
        if (TriggerCollisionDetection.isCrocodileAttack)
        {
            
        }
        if (timer >= 4.5f)
        {
            
            StartCoroutine(Attack());
            //Anim.Play("Attack");
            timer = 0f;

        }
        timer += Time.deltaTime;
        if (CrocodileHealth <= 0)
        {
           TriggerCollisionDetection.ableToAttack = false;
            col.enabled= false;
            StartCoroutine(crocoDied());
        }
       if (TriggerCollisionDetection.isKilledWaterCroco)
        {
            CrocodileHealth = 0;
            Debug.Log("X");
            TriggerCollisionDetection.isKilledWaterCroco = false;
        }
       

    }
    IEnumerator Attack()
    {
        if (TriggerCollisionDetection.ableToAttack)
        {
            
            int rand = Random.Range(0, 2);
            if (rand == 0)
                Anim.Play("Attack1");
            if (rand == 1)
                Anim.Play("Attack2");
            playPlayerDamageAnim = true;
            yield return new WaitForSeconds(1f);
            PlayerController.PlayerHealth -= 15;
            yield return new WaitForSeconds(3.5f);
           

        }
    }
    IEnumerator crocoDied()
    {
        yield return new WaitForSeconds(.4f);
        Anim.Play("Dead");
        yield return new WaitForSeconds(2f);
        TriggerCollisionDetection.isCrocodileAttack = false;
        CrocodileHealth = 100;
        Destroy(gameObject);
    }
    
}
