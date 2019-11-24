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

        public float killTimer = 0;
        public float killTimerMax = 10;

        public float spinSpeed = 5;
        public bool collected = false;
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
        if(buttonData.collected)
        {
            CollectButton();
        }
    }

    /*public void OnCollisionEnter(Collision collision)
    {
        buttonData.audioSource.PlayOneShot(buttonData.audioClip, 0.7f);
        //playerScore += 1
        Destroy(gameObject);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonData.collected = true;
            buttonData.audioSource.PlayOneShot(buttonData.audioClip, 0.7f);
        }
    }
    void CollectButton()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);

        if (buttonData.killTimer <= buttonData.killTimerMax)
        {
            buttonData.killTimer += 0.1f;
        }
        if (buttonData.killTimer > buttonData.killTimerMax)
        {
            Destroy(gameObject);
        }
    }
}
