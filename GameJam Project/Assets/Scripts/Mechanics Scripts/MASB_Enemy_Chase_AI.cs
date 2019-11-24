using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASB_Enemy_Chase_AI : MonoBehaviour
{ 

    [System.Serializable]
    public class AudioData //Sound class
    {
        public AudioSource audioSource;
        public AudioClip demonSound1;
        public AudioClip demonSound2;
        public AudioClip demonSound3;
        public AudioClip walkSound;
        public float volume = 0.75f;

        public float walkTimer = 0;
        public float walkTimerMax = 3f;
    }

    public AudioData audioData = new AudioData();

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        audioData.audioSource = GetComponent<AudioSource>();
        audioData.audioSource.PlayOneShot(audioData.demonSound1, audioData.volume);
        player = GameObject.Find("Player");
        transform.position = new Vector3(-9, 13, 10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (GetComponentInChildren<MeshRenderer>().isVisible)
        {
            audioData.walkTimer += 0.1f;
            if(audioData.walkTimer >= audioData.walkTimerMax)
            {
                audioData.audioSource.PlayOneShot(audioData.walkSound, audioData.volume);
                audioData.walkTimer = 0;
            }

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
            transform.LookAt(player.transform, transform.up);
            transform.position = new Vector3(transform.position.x, 14.6f, transform.position.z);
        }
        else
        {
            audioData.walkTimer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioData.audioSource.PlayOneShot(audioData.demonSound3, audioData.volume);
            player.GetComponent<MASB_Player_Health_Controller>().damagePlayer(2);
        }
    }
}
