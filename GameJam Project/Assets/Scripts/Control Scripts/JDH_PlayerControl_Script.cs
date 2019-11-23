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

    public void FixedUpdate()
    {
        GetInput();
        Move();
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
            transform.position += new Vector3(1 * playerSettings.playerMoveSpeed * Time.deltaTime, 0, 0);
            transform.rotation = new Quaternion(0, 90, 0, 0);
        }
        if (inputSetting.horizontalInput < 0 && inputSetting.verticalInput == 0)
        {
            transform.position += new Vector3(-1 * playerSettings.playerMoveSpeed * Time.deltaTime, 0, 0);
            transform.rotation = new Quaternion(0, -90, 0, 0);
        }
        if (inputSetting.verticalInput > 0 && inputSetting.horizontalInput == 0)
        {
            transform.position += new Vector3(0, 0, 1 * playerSettings.playerMoveSpeed * Time.deltaTime);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (inputSetting.verticalInput < 0 && inputSetting.horizontalInput == 0)
        {
            transform.position += new Vector3(0, 0, -1 * playerSettings.playerMoveSpeed * Time.deltaTime);
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
}
