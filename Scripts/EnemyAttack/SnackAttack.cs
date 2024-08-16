using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//water enemy must be spawn before the next environment section spawn area;
//this script will attach with Idle Enemy
public class SnackAttack : MonoBehaviour
{
    Animator Anim;
    Transform target;
    public Transform midTarget, leftTarget, RightTarget;// The empty object to move towards
    public float speed = 5f;  // Speed of the object
    bool ableToAttack=false;
    public static int snakeHealth;
    float timer = 2f;
    public static bool playPlayerDamageAnim=false;
    Collider col1;
    Collider col2;
    private void Start()
    {
        Anim = GetComponent<Animator>();  
        col1= GetComponent<Collider>();
        col2=GetComponentInChildren<Collider>();
    }
    private void Awake()
    {
        snakeHealth = 100;
    }
    private void Update()
    {
        if (TriggerCollisionDetection.isSnakeAttack)
        {
            if (PlayerController.playerleft)
            {
                target = leftTarget;
            }
            if (PlayerController.playerMiddle)
            {
                target = midTarget;
            }
            if (PlayerController.playerRight)
            {
                target = RightTarget;
            }    
            moveTowardPlayer();
        }
        if ( timer>=4.5f && !PlayerController.isPunching)
        {
            
            StartCoroutine(Attack());
            //Anim.Play("Attack");
            timer = 0f;

        }
        timer += Time.deltaTime;
        if (snakeHealth <= 0)
        {
            ableToAttack = false;
            StartCoroutine(snakeDied());
        } 
        
        if (TriggerCollisionDetection.isKilledWaterSnake)
        {
            snakeHealth = 0;
            if (gameObject != null)
            {

                col1.enabled = false;
                col2.enabled = false;
            }
            TriggerCollisionDetection.isKilledWaterSnake = false;
        }
        

    }
    IEnumerator Attack()
    {
        if (ableToAttack)
        {
           
            Anim.Play("Attack");
            playPlayerDamageAnim = true;
            yield return new WaitForSeconds(.5f);
            PlayerController.PlayerHealth -= 10;
            yield return new WaitForSeconds(4f);
          
        }
    }
    IEnumerator snakeDied()
    {
        yield return new WaitForSeconds(1f);
        Anim.Play("SnakeDied");

        AudioManager.instance.PlaySnakeSound.Stop();
        yield return new WaitForSeconds(2f);
        PlayerController.PlayerHealth = 100;
        TriggerCollisionDetection.isSnakeAttack = false;
        snakeHealth = 100;
        Destroy(gameObject);
    }
    void moveTowardPlayer()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;

            transform.position += direction * speed * Time.deltaTime;
          
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                transform.position = target.position;
                ableToAttack = true;
            }
        }
    }
}