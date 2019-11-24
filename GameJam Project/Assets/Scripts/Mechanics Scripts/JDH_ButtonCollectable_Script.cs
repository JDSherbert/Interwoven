using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_ButtonCollectable_Script : MonoBehaviour
{
    [System.Serializable]
    public class ButtonData
    {
        public float buttonAdd = 1;
        public AudioSource audioSource;
        public AudioClip audioClip;
        public Collider collider;

        public float spinSpeed = 5;
    }

    public ButtonData buttonData = new ButtonData();

    public void Start()
    {
        buttonData.audioSource = GetComponent<AudioSource>();
        buttonData.collider = GetComponent<Collider>();
    }

    public void FixedUpdate()
    {
        transform.Rotate(0, buttonData.spinSpeed, 0 , Space.Self);
    }

    public void OnCollisionEnter(Collision collision)
    {
        buttonData.audioSource.PlayOneShot(buttonData.audioClip, 0.7f);
        //playerScore += 1
        Destroy(gameObject);
    }
}
