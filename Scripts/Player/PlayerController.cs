using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    public Animator JackAnim;
    public Animator JackWithBoatAnim;
    public static int PlayerHealth;
    public static bool playerLostLife = false,playerleft=false,playerRight=false,playerMiddle=false,controlerData=true,isPunching=false;
    private int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 6; //distance between two lanes
    float punchTimer = 0f;
    public GameObject swipeManager;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    public float Gravity = -20;

   // public Animator animator;
    private bool isSliding = false;
    bool isFighting = false;
    public GameObject refreshControler;
    public GameObject shakeCam;
    public GameObject jackBody;
    [Header("CameraSelection")]
    public GameObject SwimCam;
    public GameObject FightCam;
    [Header("ParticleSystem")]
    public ParticleSystem boomParticleSystem;
    public ParticleSystem poisonedTextParticleSystem,poisonedEffectParticleSystem;
    public ParticleSystem bloodParticleSystem;
    



    void Start()
    {
       // JackAnim.SetBool("IsFighting", true);
        controller = GetComponent<CharacterController>();
    }
    private void Awake()
    {
        PlayerHealth = 100;
        TriggerCollisionDetection.isSinglePlayer = true;
    }
    void Update()
    {
        StartCoroutine(freezeFor3Sec());
        enemyFightModeManager();
        getDirection();
        jackBody.transform.eulerAngles = new Vector3(0, 0, 0);
        //Character controller setting for swimming character
        if (!isFighting && controlerData)
        {
            controller.center = new Vector3(0, 0, 0.34f);
            controller.height = 1f;
            controlerData = false;
            
        }
        //Character Controller setting For playerWithBoat
        
        
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
        if (TriggerCollisionDetection.isSnakeAttack || TriggerCollisionDetection.isCrocodileAttack || TriggerCollisionDetection.isHippoAttack || TriggerCollisionDetection.isPiranhaDetectPlayer)
        {
            isFighting = true;
            controlerData = true;
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
            JackAnim.SetBool("IsFighting", false);
            forwardSpeed = 3f;
            SwimCam.SetActive(true);
            FightCam.SetActive(false);
        }
        if (isFighting && (SnackAttack.snakeHealth > 0 || CrocodileAttack.CrocodileHealth > 0 ||HippoAttack.HippoHealth>0 || PiranhaAttack.PiranhasHealth>0))
        {
            forwardSpeed = 0f;
            SwimCam.SetActive(false);
            FightCam.SetActive(true);
            JackAnim.SetBool("IsFighting", true);
            if (SwipeManager.tab && punchTimer >= 2f)
            {
                punchTimer = 0;
                SnackAttack.snakeHealth -= 25;
                CrocodileAttack.CrocodileHealth -= 20;
                HippoAttack.HippoHealth -= 20;
                PiranhaAttack.PiranhasHealth -= 50;
                JackAnim.Play("Punch");
                StartCoroutine(playBoom());

            }
            if (SnackAttack.playPlayerDamageAnim || CrocodileAttack.playPlayerDamageAnim || HippoAttack.playPlayerDamageAnim || PiranhaAttack.playPlayerDamageAnim)
            {
                SnackAttack.playPlayerDamageAnim = false;
                CrocodileAttack.playPlayerDamageAnim=false;
                HippoAttack.playPlayerDamageAnim = false;
                PiranhaAttack.playPlayerDamageAnim = false;
                StartCoroutine(playGetHit());
                bloodParticleSystem.Play();
                PlayerHealth -= 10;
                Debug.Log("Player Health: " + PlayerHealth);
            }
            punchTimer += Time.deltaTime;
            fightingControlSystem();
            controller.center = new Vector3(0, +0.60f, 0.34f);
        }
        if (PlayerHealth <= 0)
        {
            playerLostLife = true;
            Debug.Log("PlayerDied");
            TriggerCollisionDetection.GameOver = true;
            
        }
    }
    //mosquitos attack damage
    IEnumerator freezeFor3Sec()
    {
        if (TriggerCollisionDetection.isCollideWithMosquitos)
        {
            swipeManager.SetActive(false);
            poisonedTextParticleSystem.Play();
            poisonedEffectParticleSystem.Play();
            StartCoroutine(shakeCamera());
            PlayerHealth -= 10;
            TriggerCollisionDetection.isCollideWithMosquitos = false;
            yield return new WaitForSeconds(3f);
            swipeManager.SetActive(true);

        }
    }
    //particle play
    IEnumerator playBoom()
    {
        isPunching = true;
        yield return new WaitForSeconds(1f);
        boomParticleSystem.Play();

        shakeCam.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        shakeCam.SetActive(false);
        isPunching=false;
    }
    //particle play
    IEnumerator playGetHit()
    {
        yield return new WaitForSeconds(1.5f);
        JackAnim.Play("GetHit");
        shakeCam.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        shakeCam.SetActive(false);
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
            if (SwipeManager.swipeUp && TriggerCollisionDetection.isSinglePlayer)
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
        JackAnim.Play("Jump");
        direction.y = jumpForce;
    }
    IEnumerator slideLeft()
    {
        jackBody.transform.eulerAngles= new Vector3 (0, -15, 0);
        yield return new WaitForSeconds(01f);
        jackBody.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    IEnumerator slideRight()
    {
        jackBody.transform.eulerAngles = new Vector3(0, 15, 0);
        yield return new WaitForSeconds(01f);
        jackBody.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        JackAnim.Play("Dive");
        //  animator.SetBool("isSliding", true);
        if (TriggerCollisionDetection.isPlayerWithBoat)
        { 
            JackWithBoatAnim.Play("Ducking");
            controller.center = new Vector3(0f, 0.23f, -1.09f);
            controller.height = 2.2f;
            controller.radius = 0.1f;

            yield return new WaitForSeconds(1.3f);

            controller.center = new Vector3(0f, 0.52f, -1.09f);
            controller.height = 2.57f;
            controller.radius = 0.5f;
          
        }
        //JackAnim.Play("Ducking");
        //function for simpleCharacter
        if (TriggerCollisionDetection.isSinglePlayer)
        {
            controller.center = new Vector3(0, +0.5f, 0.34f);
            controller.radius = 0.1f;
            controller.height = 0.1f;

            yield return new WaitForSeconds(5f);

            controller.center = new Vector3(0, 0, 0.34f);
            controller.radius = 0.5f;
            controller.height = 1;
        }

        //  animator.SetBool("isSliding", false);
        yield return new WaitForSeconds(2);
        isSliding = false;
    }
    IEnumerator shakeCamera()
    {
        shakeCam.SetActive(true);
        yield return new WaitForSeconds(2f);
        shakeCam.SetActive(false);
    }

    
}