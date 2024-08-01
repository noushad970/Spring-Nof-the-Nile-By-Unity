using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippoAttack : MonoBehaviour
{
    Animator Anim;
    public static int HippoHealth;
    float timer = 4f;
    public static bool playPlayerDamageAnim = false;
    private void Start()
    {
        Anim = GetComponent<Animator>();

    }
    private void Awake()
    {
        HippoHealth = 100;
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
        if (HippoHealth <= 0)
        {
            TriggerCollisionDetection.ableToAttack = false;
            StartCoroutine(HippoDied());
        }
        if (TriggerCollisionDetection.isKilledWaterEnemy)
        {
            Debug.Log("Hippo Collide");
            HippoHealth = 0;
            TriggerCollisionDetection.isKilledWaterEnemy = false;
        }

    }
    IEnumerator Attack()
    {
        if (TriggerCollisionDetection.ableToAttack)
        {

            
                Anim.Play("Attack");
            
            playPlayerDamageAnim = true;
            yield return new WaitForSeconds(1f);
            PlayerController.PlayerHealth -= 15;
            yield return new WaitForSeconds(3.5f);


        }
    }
    IEnumerator HippoDied()
    {
        yield return new WaitForSeconds(.4f);
        Anim.Play("Die");
        yield return new WaitForSeconds(5f);
        TriggerCollisionDetection.isHippoAttack = false;
        HippoHealth = 100;
        Destroy(gameObject);
    }

}
