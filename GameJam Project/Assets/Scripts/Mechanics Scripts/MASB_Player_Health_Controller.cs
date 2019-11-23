using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MASB_Player_Health_Controller : MonoBehaviour
{
    public int playerHealth = 10;
    private GameObject manager;
    public ParticleSystem UIBleed;
    public ParticleSystem PlayerBleed;
    public float bleedTimer = 0;
    public float bleedTimerMax = 3;
    public bool isBleeding = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
        UIBleed = GameObject.Find("/UI_Canvas/HealthBar/Heart/BloodSplatter").GetComponent<ParticleSystem>();
        PlayerBleed = GameObject.Find("Player").GetComponent<ParticleSystem>();
        UIBleed.Stop();
        PlayerBleed.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            killPlayer();
        }
        if(isBleeding == true)
        {
            bleedTimer += 0.1f;
            UIBleed.Play();
            PlayerBleed.Play();
            if (bleedTimer >= bleedTimerMax)
            {
                UIBleed.Stop();
                PlayerBleed.Stop();
                bleedTimer = 0;
                isBleeding = false;
            }
        }
    }

    public void damagePlayer(int damage)
    {
        playerHealth -= damage;
        isBleeding = true;

    }

    void killPlayer()
    {
        manager.GetComponent<MASB_Reset_Scene>().resetScene();
    }
}
