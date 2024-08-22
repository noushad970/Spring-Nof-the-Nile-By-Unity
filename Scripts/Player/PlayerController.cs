using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed,previousForwardSpeed;
    public float maxSpeed;
    [Header("All Animations")]
    public Animator JackAnim;
    public Animator JackWithNutshellBoatAnim, JackWithCanoeAnim,jackWithRaftAnim, jackWithFishingBoatAnim;
    public GameObject singleplayer;
    public static int PlayerHealth;
    public static bool playerSliding=false,playerLostLife = false,playerleft=false,playerRight=false,playerMiddle=false,controlerData=true,isPunching=false;
    private int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 6; //distance between two lanes
    float punchTimer = 0f;
    public GameObject swipeManager;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public GameObject particleEnvironment;
    Vector3 particleLocation;
    public float jumpForce;
    public float Gravity = -20;
    public Slider healthSlider;
   // public Animator animator;
    private bool isSliding = false;
    public static bool isFighting = false;
    public GameObject HealthSlider;
    public GameObject shakeCam;
    public GameObject jackBody;
    [Header("CameraSelection")]
    public GameObject SwimCam;
    public GameObject FightCam;
    public GameObject waterParticle;
    [Header("ParticleSystem")]
    public ParticleSystem boomParticleSystem;
    public ParticleSystem poisonedTextParticleSystem,poisonedEffectParticleSystem;
    public ParticleSystem bloodParticleSystem,boomblastParticle;
    bool loadPos;

    public GameObject bgMusic;
    bool loop,loop2;
    void Start()
    {
        // JackAnim.SetBool("IsFighting", true);
        previousForwardSpeed = 3;
        loop = false;
        loop2 = false;
        controller = GetComponent<CharacterController>();
        particleLocation = particleEnvironment.transform.position;
        TriggerCollisionDetection.shipHealth = 100;
        controller.center = new Vector3(0, 0.75f, 0.45f);
        controller.radius = .5f;
        controller.height = 1f;
        loadPos = true;
    }
    private void Awake()
    {
        instance = this;
        PlayerHealth = 100;
        TriggerCollisionDetection.isSinglePlayer = true;

        
    }
    void Update()
    {
        StartCoroutine(freezeFor3Sec());
        enemyFightModeManager();
        getDirection();///
        if (loadPos)
        {
            StartCoroutine(LoadPos());
        }
        if (TriggerCollisionDetection.isPlayerWithBoat && !InGameManager.isActivateRaft)
        {
            StartCoroutine(wait3Sec());
        }else if (TriggerCollisionDetection.playerisWithShip)
        {
            particleEnvironment.transform.position = new Vector3(particleEnvironment.transform.position.x, 0.4f, particleEnvironment.transform.position.z);
        }
        else
        {
            particleEnvironment.transform.position = new Vector3(particleEnvironment.transform.position.x, 0, particleEnvironment.transform.position.z);
        }
        jackBody.transform.eulerAngles = new Vector3(0, 0, 0);
        //Character controller setting for swimming character
        if (!isFighting && controlerData)
        {
            //controller.center = new Vector3(0f, 0.75f, -0.74f);
            //controller.height = 2.1f; 

            controller.center = new Vector3(0f, 0.75f, 0.45f);
            controller.radius = 0.5f;
            controller.height = 1;
            controlerData = false;
            
        }
        if (PlayerHealth <= 0)
        {
            VestManagement.finallyGameOver = true;
        }
        if (isFighting)
        {
            healthSlider.value = PlayerHealth;
            HealthSlider.SetActive(true);
        }
        else HealthSlider.SetActive(false);
        //Character Controller setting For playerWithBoat
        if (TriggerCollisionDetection.playerisWithShip || TriggerCollisionDetection.isHarbourShore)
        {
            laneDistance = 5;
            bgMusic.SetActive(false);
        }
        else
        {
            bgMusic.SetActive(true);
            laneDistance = 3;
        }
        
    }
    IEnumerator wait3Sec()
    {
        yield return new WaitForSeconds(2f);
        particleEnvironment.transform.position = new Vector3(particleEnvironment.transform.position.x, .8f, particleEnvironment.transform.position.z);

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
        if ((TriggerCollisionDetection.isSnakeAttack || TriggerCollisionDetection.isCrocodileAttack || TriggerCollisionDetection.isHippoAttack || TriggerCollisionDetection.isPiranhaDetectPlayer) && TriggerCollisionDetection.isSinglePlayer)
        {
            isFighting = true;
            controlerData = true;
            
        }
        else
        {
            isFighting = false;
           
        }
        if (!isFighting)
        {
            controlSystem();
            JackAnim.SetBool("IsFighting", false);
            loop= false;
            if (!loop2)
            {
                forwardSpeed = previousForwardSpeed;
                loop2 = true;
            }
            SwimCam.SetActive(true);
            FightCam.SetActive(false);
        }
        if (isFighting && (SnackAttack.snakeHealth > 0 || CrocodileAttack.CrocodileHealth > 0 ||HippoAttack.HippoHealth>0 || PiranhaAttack.PiranhasHealth>0))
        {
            loop2 = false;
            if (!loop)
            {

                previousForwardSpeed = forwardSpeed;
                loop=true;
            }
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
            
            }
            punchTimer += Time.deltaTime;
            fightingControlSystem();
            controller.center = new Vector3(0, +0.60f, 0.34f);
        }
        if (PlayerHealth <= 0)
        {
            playerLostLife = true;
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
        AudioManager.instance.punchFX.Play();
        shakeCam.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        shakeCam.SetActive(false);
        isPunching=false;
    }
    //particle play
    IEnumerator playGetHit()
    {
        AudioManager.instance.PlayerDamaged.Play();
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
        
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.05f * Time.deltaTime;
        }
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

    IEnumerator LoadPos()
    {
        controller.center = new Vector3(0, 0.75f, 0.45f);
        controller.radius = .5f;
        controller.height = 1f;
        yield return new WaitForSeconds(.3f);
        loadPos = false;
    }
    private IEnumerator Slide()
    {
        isSliding = true;
        playerSliding = true;
        //  animator.SetBool("isSliding", true);
        if (TriggerCollisionDetection.isPlayerWithBoat)
        { 
            jackWithFishingBoatAnim.Play("Ducking");
            jackWithRaftAnim.Play("Ducking"); 
            JackWithNutshellBoatAnim.Play("Ducking");
            JackWithCanoeAnim.Play("Ducking"); 
            controller.center = new Vector3(0f, 0.5f, -1.09f);
            controller.height = 0.81f;
            controller.radius = 0.1f;
            yield return new WaitForSeconds(2f);

            controller.center = new Vector3(0f, 0.75f, -0.74f);
            controller.height = 2.1f;
            controller.radius = 0.5f;
            isSliding = false;
        }
        //JackAnim.Play("Ducking");
        //function for simpleCharacter
        else if (TriggerCollisionDetection.isSinglePlayer)
        {
            AudioManager.instance.DiveIntoWater.Play();
            controller.center = new Vector3(0, 1.5f, 0.34f);
            controller.radius = 0.2f;
            controller.height = 0.1f;
            JackAnim.Play("Dive");
            yield return new WaitForSeconds(3f);

            controller.center = new Vector3(0f, 0.75f, 0.45f);
            controller.radius = 0.5f;
            controller.height = 1;
            yield return new WaitForSeconds(2);
            isSliding = false;
        }

        //  animator.SetBool("isSliding", false);
        
    }
    IEnumerator shakeCamera()
    {
        shakeCam.SetActive(true);
        yield return new WaitForSeconds(2f);
        shakeCam.SetActive(false);
    }

    public IEnumerator gameOver()
    {
        controller.enabled = false;
        waterParticle.SetActive(false);
        if (TriggerCollisionDetection.isSinglePlayer)
        {
            JackAnim.Play("Death");
        }else if (TriggerCollisionDetection.playerisWithShip)
        {
            boomblastParticle.Play();   
        }
        yield return new WaitForSeconds(5f);
        //coin show
        SceneManager.LoadScene("SplashScreenMenu");
    }
}