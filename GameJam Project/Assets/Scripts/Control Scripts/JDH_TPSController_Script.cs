using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_TPSController_Script : MonoBehaviour
{
    [System.Serializable]
    public class MoveSettings //Movement speeds adjustable in runtime
    {
        public float movementVel = 8; //basic speed
        public float rotateVel = 100; //turning speed
        public float jumpVel = 15; //power behind jumping
        public float distToGrounded = 0.1f; //raycast down to detect ground
        public LayerMask ground; //make sure to set this for collision detection

    }
    [System.Serializable]
    public class PhysicsSettings //physics adjustable in runtime
    {
        public float downAccel = 0.75f; //Gravity
    }
    [System.Serializable]
    public class InputSettings //Input mapping and delays adjustable at runtime
    {
        public float inputDelay = 0.1f; //wait before doing anything
        public string VERTICAL_AXIS = "Vertical"; //^v
        public string HORIZONTAL_AXIS = "Horizontal"; //<>
        public string JUMP_AXIS = "Jump"; //_

        public float verticalInput, horizontalInput, jumpInput;
    }
    [System.Serializable]
    public class AudioSettings //Sounds and Audio FX ~ 
    {
        public AudioSource playerSoundPlayer;

        public float playerSoundVolume = 0.25f;//multiplier for sound intensity 

        //Clips
        public AudioClip playerJumpSound;
        public AudioClip playerWalkSound;
        public AudioClip playerGroundedSound;
        public float playerWalkSoundTimer;
    }

    //Wedge allows classes to be called and values adjusted in runtime
    public MoveSettings moveSetting = new MoveSettings();
    public PhysicsSettings physicsSetting = new PhysicsSettings();
    public InputSettings inputSetting = new InputSettings();
    public AudioSettings audioSetting = new AudioSettings();

    //set variables
    public Vector3 velocity = Vector3.zero;
    public Quaternion targetRotation;
    public Rigidbody rBody;
    float angleRotation;
    

    //for animation
    public Animator playerAnimationController;


    //get the camera. if using my JDH_ThirdPersonCamera camera script 
    //should be automatic
    public Transform cam;


    //check if on floor, returns true if yes
    bool Grounded()
    {
        Debug.DrawLine(rBody.transform.position, Vector3.down * moveSetting.distToGrounded, Color.green);
        return Physics.Raycast
            (transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
    }

    //initial configuration of stuff
    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        inputSetting.verticalInput = inputSetting.horizontalInput = 0;

        //for animation
        playerAnimationController = GetComponent<Animator>();

        //Audio
        audioSetting.playerSoundPlayer = GetComponent<AudioSource>();

    }

    //trigger on any keypress, remaps class settings above for runtime
    void GetInput()
    {
        inputSetting.verticalInput = Input.GetAxis(inputSetting.VERTICAL_AXIS);
        inputSetting.horizontalInput = Input.GetAxis(inputSetting.HORIZONTAL_AXIS);
        inputSetting.jumpInput = Input.GetAxis(inputSetting.JUMP_AXIS);


    }

    //called every frame
    private void FixedUpdate()
    {
        //input maps
        GetInput();

        //input delay, allows character to keep facing last moved direction
        if (Mathf.Abs(inputSetting.verticalInput) < inputSetting.inputDelay
            && Mathf.Abs(inputSetting.horizontalInput) < inputSetting.inputDelay)
        {


            if(playerAnimationController != null)
            {
                //animation
                playerAnimationController.SetBool("isIdle", true);
                playerAnimationController.SetBool("isWalking", false);
                playerAnimationController.SetBool("isAiming", false);
                playerAnimationController.SetBool("isAimWalking", false);
            }
        }
        //return; //if ^v<> are less than inputDelay, do nothing
        else
        {
            //do the normal methods because there is an input
            CalculateDirection();
            Rotate();
            Move();

            //animation
            if (playerAnimationController != null)
            {
                playerAnimationController.SetBool("isIdle", false);
                playerAnimationController.SetBool("isWalking", true);
                playerAnimationController.SetBool("isAiming", false);
            }
            //timeraudio
            audioSetting.playerWalkSoundTimer += 1;


            if (audioSetting.playerWalkSoundTimer == 9 && Grounded() == true)
            {
                //audio
                if(audioSetting.playerSoundPlayer != null)
                {
                    audioSetting.playerSoundPlayer.PlayOneShot
    (audioSetting.playerWalkSound, audioSetting.playerSoundVolume);
                }

                audioSetting.playerWalkSoundTimer = 0;
            }

            else if (Grounded() == false)
            {
                audioSetting.playerWalkSoundTimer = 0;
            }

        }

        //jump method with if Input recieved delay statement
        Jump();

        //Apply force to player
        rBody.velocity = transform.TransformDirection(velocity);

    }

    //takes the angle of the camera into consideration when the player moves
    void CalculateDirection()
    {
        //gets V H movement, turns it into a radian, and then a degree float
        angleRotation = Mathf.Atan2(inputSetting.horizontalInput, inputSetting.verticalInput);
        angleRotation = Mathf.Rad2Deg * angleRotation;

        //rotates camera on a Y axis
        angleRotation += cam.eulerAngles.y;
    }

    void Rotate()
    {

        // rotates character based on direction
        targetRotation = Quaternion.Euler(0, angleRotation, 0);
        transform.rotation = Quaternion.Slerp
            (transform.rotation, targetRotation, moveSetting.rotateVel * Time.deltaTime);


    }
    private void Move()
    {


        //input delay check
        if (Mathf.Abs(inputSetting.verticalInput) > inputSetting.inputDelay ||
            Mathf.Abs(inputSetting.horizontalInput) > inputSetting.inputDelay)
        {

            // move
            transform.position +=
                transform.forward * moveSetting.movementVel * Time.deltaTime;



        }
        else
        {
            //zero vel, not using Y as that will stop gravity

            velocity.z = 0;
            velocity.x = 0;
            //velocity.y = 0;
        }

    }

    void Jump()
    {
        //checks if on floor with bool method's raycast
        if (inputSetting.jumpInput > 0 && Grounded()) //jumping while on floor
        {
            //jump
            velocity.y = moveSetting.jumpVel;

            //animation
            if (playerAnimationController != null)
            {
                playerAnimationController.SetBool("isIdle", false);
                playerAnimationController.SetBool("isWalking", false);
                playerAnimationController.SetBool("isJump", true);
            }
            if(audioSetting.playerSoundPlayer != null)
            {
                //audio
                audioSetting.playerSoundPlayer.PlayOneShot
                    (audioSetting.playerJumpSound, audioSetting.playerSoundVolume);
            }



        }
        else if (inputSetting.jumpInput == 0 && Grounded()) //if on floor no jump
        {
            velocity.y = 0;

            //animation
            playerAnimationController.SetBool("isJump", false);
        }
        else //falling
        {
            //gravity pull, add a clamp if needed
            velocity.y = Mathf.Clamp(velocity.y, -20, moveSetting.jumpVel);
            velocity.y -= physicsSetting.downAccel;

            //animation
            if (playerAnimationController != null)
            {
                playerAnimationController.SetBool("isIdle", false);
                playerAnimationController.SetBool("isWalking", false);
                playerAnimationController.SetBool("isJump", true);
            }
        }
    }
}
