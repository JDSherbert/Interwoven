using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script created by Joshua "JDSherbert" Herbert for GameJam 22/11/2019
/// Third person camera Script
/// </summary>
public class JDH_ThirdPersonCamera_Script : MonoBehaviour
{
    [System.Serializable]
    public class CameraSettings //Movement speeds adjustable in runtime
    {
        public float distance = 12.0f; //normal distance
        public float aimDistance = 2.5f; 
        public float minimumClampY = 0.0f; //stops going out of bounds
        public float maximumClampY = 75.0f;

        //not needed at runtime, used for math and debugging
        public float currentX = 0f;
        public float currentY = 0f;

        //movement speed
        public float sensitivityX = 8.0f;
        public float sensitivityY = 8.0f;

        //set variables
        public Transform lookAt;
        public Transform camTransform;
        public Camera mainCamera;
        public Transform aimPoint;

    }

    public CameraSettings cameraSetting = new CameraSettings();

    private void Start()
    {
        //make camera
        cameraSetting.camTransform = transform;
        cameraSetting.mainCamera = Camera.main;
    }
    private void Update()
    {
        //Get mouse movements. camera inversion inevitable so -= used
        cameraSetting.currentX += Input.GetAxis("Mouse X") * cameraSetting.sensitivityX;
        cameraSetting.currentY -= Input.GetAxis("Mouse Y") * cameraSetting.sensitivityY;

        //remove cursor 
        Cursor.lockState = CursorLockMode.Locked;
        //clamp
        cameraSetting.currentY = Mathf.Clamp(cameraSetting.currentY, cameraSetting.minimumClampY, cameraSetting.maximumClampY);
    }

    public void LateUpdate()
    {
        //put the camera behind player's look point
        Vector3 dir = new Vector3(0, 0, -cameraSetting.distance);
        Quaternion rotation = Quaternion.Euler(cameraSetting.currentY, cameraSetting.currentX, 0);
        cameraSetting.camTransform.position = cameraSetting.lookAt.position + rotation * dir;


        //keep camera looking at player
        cameraSetting.camTransform.LookAt(cameraSetting.lookAt.position);
    }
}
