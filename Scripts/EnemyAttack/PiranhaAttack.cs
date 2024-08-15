using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PiranhaAttack : MonoBehaviour
{
    public Transform FromAttackPoint,ToAttackPoint;
    public float speed = 2f;
    bool hitwithPlayer = false, BackToAttackingPosition = false,piranhacanAttack=true;
    int x;
    public static int PiranhasHealth;
    public static bool playPlayerDamageAnim=false;
    // Start is called before the first frame update

    private void Awake()
    {
        PiranhasHealth = 100;
        x = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (piranhacanAttack)
        {
            if (TriggerCollisionDetection.isPiranhaDetectPlayer && x == 0)
            {
                moveTowardPlayer();
            }
            if (hitwithPlayer)
            {
                moveTowardPlayer();
            }
            if (BackToAttackingPosition)
            {
                goForAttack();
            }
            if (PiranhasHealth <= 0)
                StartCoroutine(PiranhaDied());
        }
    }
    void moveTowardPlayer()
    {
        if (FromAttackPoint != null)
        {
            if (x != 0)
                speed = 0.3f;
            Vector3 direction = (FromAttackPoint.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, FromAttackPoint.position) < 0.1f)
            {
                transform.position = FromAttackPoint.position;
                x++;
                BackToAttackingPosition=true;
                hitwithPlayer = false;
            }
        }
    }
    void goForAttack()
    {
        if (ToAttackPoint != null)
        {
            speed = 3f;
            Vector3 direction = (ToAttackPoint.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, ToAttackPoint.position) < 0.1f)
            {
                transform.position = ToAttackPoint.position;

                BackToAttackingPosition = false;
                hitwithPlayer = true;
                playPlayerDamageAnim = true;

            }
        }
    }
    IEnumerator PiranhaDied()
    {
        
        piranhacanAttack = false;    
        yield return new WaitForSeconds(2f);
        PlayerController.PlayerHealth = 100;
        TriggerCollisionDetection.isPiranhaDetectPlayer = false;

        ScoreCount.totalFishWhenEndRun += Random.Range(1, 4);
        Destroy(gameObject);
    }
}
