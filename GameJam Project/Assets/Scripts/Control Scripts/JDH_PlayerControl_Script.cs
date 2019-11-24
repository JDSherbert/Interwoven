using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_PlayerControl_Script : MonoBehaviour
{
    [System.Serializable]
    public class PlayerSettings
    {
        public float playerMoveSpeed = 8.0f;
        public float playerRotationSpeed = 100.0f;
        public float playerRotationAngle = 90f;


    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f; //wait before doing anything
        public string VERTICAL_AXIS = "Vertical"; //^v
        public string HORIZONTAL_AXIS = "Horizontal"; //<>
        public string JUMP_AXIS = "Jump"; //_

        public float verticalInput, horizontalInput, jumpInput;
    }

    public PlayerSettings playerSettings = new PlayerSettings();
    public InputSettings inputSetting = new InputSettings();

    public bool canPlayerMove = true;

    private void Start()
    {
        transform.position = new Vector3(10, 13, 0);
    }

    public void FixedUpdate()
    {
        GetInput();
        if (canPlayerMove)
        {
            Move();
        }
    }

    void GetInput()
    {
        inputSetting.verticalInput = Input.GetAxis(inputSetting.VERTICAL_AXIS);
        inputSetting.horizontalInput = Input.GetAxis(inputSetting.HORIZONTAL_AXIS);
        inputSetting.jumpInput = Input.GetAxis(inputSetting.JUMP_AXIS);
    }

    public void Move()
    {
        if (inputSetting.horizontalInput > 0 && inputSetting.verticalInput == 0)
        {
            //Right
            //transform.position += new Vector3(1 * playerSettings.playerMoveSpeed * Time.deltaTime, 0, 0);
            transform.position = new Vector3(transform.position.x + (playerSettings.playerMoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            transform.LookAt(new Vector3(100, transform.position.y, transform.position.z), transform.up);
        }
        if (inputSetting.horizontalInput < 0 && inputSetting.verticalInput == 0)
        {
            //Left
            //transform.position += new Vector3(-1 * playerSettings.playerMoveSpeed * Time.deltaTime, 0, 0);
            transform.position = new Vector3(transform.position.x - (playerSettings.playerMoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            transform.LookAt(new Vector3(-100, transform.position.y, transform.position.z), transform.up);
        }
        if (inputSetting.verticalInput > 0 && inputSetting.horizontalInput == 0)
        {
            //Up
            //transform.position += new Vector3(0, 0, 1 * playerSettings.playerMoveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (playerSettings.playerMoveSpeed * Time.deltaTime));
            transform.LookAt(new Vector3(transform.position.x, transform.position.y, 100), transform.up);
        }
        if (inputSetting.verticalInput < 0 && inputSetting.horizontalInput == 0)
        {
            //Down
            //transform.position += new Vector3(0, 0, -1 * playerSettings.playerMoveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (playerSettings.playerMoveSpeed * Time.deltaTime));
            transform.LookAt(new Vector3(transform.position.x, transform.position.y, -100), transform.up);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12.5f, 12.5f), transform.position.y, Mathf.Clamp(transform.position.z, -12.5f, 12.5f));
    }
}
