using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script created by Joshua "JDSherbert" Herbert for GameJam 22/11/2019
/// Third person control script
/// </summary>
public class JDH_ThirdPersonController_Script : MonoBehaviour
{
    [System.Serializable]
    public class MovementSettings //Movement speeds adjustable in runtime
    {
        public float movementVel = 8; //basic speed
        public float rotateVel = 100; //turning speed
        public float jumpVel = 15; //power behind jumping
        public float distToGrounded = 0.1f; //raycast down to detect ground
        public LayerMask playableArea; //make sure to set this for collision detection

        public Vector3 velocity = Vector3.zero;
        public Quaternion targetRotation;
        public float angleRotation;


        public Transform mainCameraTransform;
 

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
    public class PlayerData
    {
        public Rigidbody playerRBody;
        public Animator playerAnimationController;
    }
    

    //Wedge allows classes to be called and values adjusted in runtime
    public MovementSettings moveSetting = new MovementSettings();
    public PhysicsSettings physicsSetting = new PhysicsSettings();
    public InputSettings inputSetting = new InputSettings();
    public AudioSettings audioSetting = new AudioSettings();
    public PlayerData playerData = new PlayerData();

    public bool CanJump()
    {
        Debug.DrawLine(playerData.playerRBody.transform.position, Vector3.down * moveSetting.distToGrounded, Color.green);
        return Physics.Raycast
            (transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.playableArea);
    }
    public void Start()
    {
        moveSetting.mainCameraTransform = Camera.main.transform;
        inputSetting.verticalInput = inputSetting.horizontalInput = 0;

        if (gameObject.GetComponent<Rigidbody>())
        {
            playerData.playerRBody = GetComponent<Rigidbody>();
        }
        if (gameObject.GetComponent<Animator>())
        {
            //for animation
            playerData.playerAnimationController = GetComponent<Animator>();
        }
        if (gameObject.GetComponent<AudioSource>())
        {
            //Audio
            audioSetting.playerSoundPlayer = GetComponent<AudioSource>();
        }
    }
    //trigger on any keypress, remaps class settings above for runtime
    public void GetInput()
    {
        inputSetting.verticalInput = Input.GetAxis(inputSetting.VERTICAL_AXIS);
        inputSetting.horizontalInput = Input.GetAxis(inputSetting.HORIZONTAL_AXIS);
        inputSetting.jumpInput = Input.GetAxis(inputSetting.JUMP_AXIS);
    }

    //called every frame
    public void FixedUpdate()
    {
        //input maps
        GetInput();

        //input delay, allows character to keep facing last moved direction
        if (Mathf.Abs(inputSetting.verticalInput) < inputSetting.inputDelay
            && Mathf.Abs(inputSetting.horizontalInput) < inputSetting.inputDelay)
        {
            //animation
            if(gameObject.GetComponent<Animator>())
            {
                playerData.playerAnimationController.SetBool("isIdle", true);
                playerData.playerAnimationController.SetBool("isWalking", false);
                playerData.playerAnimationController.SetBool("isAiming", false);
                playerData.playerAnimationController.SetBool("isAimWalking", false);
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
            if (gameObject.GetComponent<Animator>())
            {
                playerData.playerAnimationController.SetBool("isIdle", false);
                playerData.playerAnimationController.SetBool("isWalking", true);
                playerData.playerAnimationController.SetBool("isAiming", false);
            }
            if(gameObject.GetComponent<AudioSource>())
            {
                //timeraudio
                audioSetting.playerWalkSoundTimer += 1;
                if (audioSetting.playerWalkSoundTimer == 9 && CanJump() == true)
                {
                    //audio
                    audioSetting.playerSoundPlayer.PlayOneShot
                        (audioSetting.playerWalkSound, audioSetting.playerSoundVolume);

                    audioSetting.playerWalkSoundTimer = 0;
                }
                else if (CanJump() == false)
                {
                    audioSetting.playerWalkSoundTimer = 0;
                }
            }
        }
        //Apply force to player
        playerData.playerRBody.velocity = transform.TransformDirection(moveSetting.velocity);
    }

    //takes the angle of the camera into consideration when the player moves
    void CalculateDirection()
    {
        //gets V H movement, turns it into a radian, and then a degree float
        moveSetting.angleRotation = Mathf.Atan2(inputSetting.horizontalInput, inputSetting.verticalInput);
        moveSetting.angleRotation = Mathf.Rad2Deg * moveSetting.angleRotation;

        //rotates camera on a Y axis
        moveSetting.angleRotation += moveSetting.mainCameraTransform.eulerAngles.y;
    }

    void Rotate()
    {
        // rotates character based on direction
        moveSetting.targetRotation = Quaternion.Euler(0, moveSetting.angleRotation, 0);
        transform.rotation = Quaternion.Slerp
            (transform.rotation, moveSetting.targetRotation, moveSetting.rotateVel * Time.deltaTime);
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
            moveSetting.velocity.z = 0;
            moveSetting.velocity.x = 0;
            //velocity.y = 0;
        }
    }
}
