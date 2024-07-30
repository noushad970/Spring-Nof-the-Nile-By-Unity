﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    public Animator anim;
    public static int PlayerHealth;
    public static bool playerLostLife = false,playerleft=false,playerRight=false,playerMiddle=false;
    private int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 6; //distance between two lanes
    float punchTimer = 0f;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float Gravity = -20;

   // public Animator animator;
    private bool isSliding = false;
    bool isFighting = false;

    [Header("CameraSelection")]
    public GameObject SwimCam;
    public GameObject FightCam;
    [Header("ParticleSystem")]
    public ParticleSystem boomParticleSystem;


    void Start()
    {
       // anim.SetBool("IsFighting", true);
        controller = GetComponent<CharacterController>();
    }
    private void Awake()
    {
        PlayerHealth = 100;
    }
    void Update()
    {

        enemyFightModeManager();
        getDirection();
    }
    void getDirection()
    {
        if (this.gameObject.transform.position.x == 0)
        {
            playerleft = false;
            playerMiddle = true;
            playerRight = false;
        }
        if (this.gameObject.transform.position.x == -3)
        {
            playerleft = true;
            playerMiddle = false;
            playerRight = false;
        }
        if (this.gameObject.transform.position.x == 3)
        {
            playerleft = false;
            playerMiddle = false;
            playerRight = true;
        }
    }
    void enemyFightModeManager()
    {
        if (TriggerCollisionDetection.isSnakeAttack || TriggerCollisionDetection.isCrocodileAttack || TriggerCollisionDetection.isHippoAttack)
        {
            isFighting = true;
            Debug.Log("True");
        }
        else
        {
            isFighting = false;
            Debug.Log("False");
        }
        if (!isFighting)
        {
            controlSystem();
            anim.SetBool("IsFighting", false);
            forwardSpeed = 3f;
            controller.center = new Vector3(0, 0, 0);
            SwimCam.SetActive(true);
            FightCam.SetActive(false);
        }
        if (isFighting && (SnackAttack.snakeHealth > 0 || CrocodileAttack.CrocodileHealth > 0 ||HippoAttack.HippoHealth>0))
        {
            forwardSpeed = 0f;
            SwimCam.SetActive(false);
            FightCam.SetActive(true);
            anim.SetBool("IsFighting", true);
            if (SwipeManager.tab && punchTimer >= 2f)
            {
                punchTimer = 0;
                SnackAttack.snakeHealth -= 25;
                CrocodileAttack.CrocodileHealth -= 20;
                HippoAttack.HippoHealth -= 20;
                anim.Play("Punch");
                StartCoroutine(playBoom());

            }
            if (SnackAttack.playPlayerDamageAnim || CrocodileAttack.playPlayerDamageAnim || HippoAttack.playPlayerDamageAnim)
            {
                SnackAttack.playPlayerDamageAnim = false;
                CrocodileAttack.playPlayerDamageAnim=false;
                HippoAttack.playPlayerDamageAnim = false;
                StartCoroutine(playGetHit());
            }
            punchTimer += Time.deltaTime;
            fightingControlSystem();
            controller.center = new Vector3(0, +0.70f, 0);
        }
        if (PlayerHealth <= 0)
        {
            playerLostLife = true;
            Debug.Log("PlayerDied");
            //Destroy(gameObject);
        }
    }
    IEnumerator playBoom()
    {
        yield return new WaitForSeconds(1f);
        boomParticleSystem.Play();
}
    IEnumerator playGetHit()
    {
        yield return new WaitForSeconds(1f);
        anim.Play("GetHit");
    }
    private void FixedUpdate()
    {
       
        controller.Move(direction * Time.fixedDeltaTime);
        

    }
    void fightingControlSystem()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        if (!isGrounded)
        {
            // animator.SetBool("isGrounded", false);
            direction.y += Gravity * Time.deltaTime;
        }

        direction.z = 0f;
        
        

    }
    void controlSystem()
    {
        // if (!PlayerManager.isGameStarted)
        //   return;

        //Increase speed
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }

        //animator.SetBool("isGameStarted", true);

        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

        if (controller.isGrounded)
        {
            if (SwipeManager.swipeUp)
            {
                direction.y = -1;
                Jump();
            }
            //  animator.SetBool("isGrounded", true);

        }

        else
        {
            // animator.SetBool("isGrounded", false);
            direction.y += Gravity * Time.deltaTime;
        }

        if (SwipeManager.swapDown && !isSliding)
        {
            StartCoroutine(Slide());
        }

        //Gather the inputs on which lane we should be

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }

            //   animator.SetBool("isGrounded", false);
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }

            //  animator.SetBool("isGrounded", false);
        }

        //Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }

        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    private IEnumerator Slide()
    {
        isSliding = true;

      //  animator.SetBool("isSliding", true);

        controller.center = new Vector3(0, +0.5f, 0);
        controller.radius = 0.1f;
        controller.height = 1;

        yield return new WaitForSeconds(1.3f);

        controller.center = new Vector3(0, 0, 0);
        controller.radius = 0.5f;
        controller.height = 1;

      //  animator.SetBool("isSliding", false);

        isSliding = false;
    }
}