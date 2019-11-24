using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MASB_Player_Health_Controller : MonoBehaviour
{
    [System.Serializable]
    public class HealthBar //JDH
    {/// <summary>
    /// HealthBar Objects stored in this data class for tidyness and easier access
    /// </summary>
        public GameObject hp100;
        public GameObject hp90;
        public GameObject hp80;
        public GameObject hp70;
        public GameObject hp60;
        public GameObject hp50;
        public GameObject hp40;
        public GameObject hp30;
        public GameObject hp20;
        public GameObject hp10;
        public GameObject hp00;

        public ParticleSystem UIBleed;
        public ParticleSystem PlayerBleed;
        public float bleedTimer = 0;
        public float bleedTimerMax = 3;
        public bool isBleeding = false;

        public float killTimer = 0;
        public float killTimerMax = 5;

    }

    public HealthBar healthbar = new HealthBar();

    public int playerHealth = 10;
    private GameObject manager;

    void Start()
    {
        GetHealthBars(); //JDH

        manager = GameObject.Find("GameManager");

    }

    void Update()
    {
        DisplayHealth(); //JDH

        if (playerHealth <= 0)
        {
            killPlayer();
        }
    }

    public void damagePlayer(int damage)
    {
        playerHealth -= damage;

        healthbar.isBleeding = true; //JDH

    }

    void killPlayer()
    {
        gameObject.GetComponentInChildren<Renderer>().enabled = false; //JDH
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; //JDH
        healthbar.killTimer += 0.1f; //JDH
        if(healthbar.killTimer >= healthbar.killTimerMax) //JDH
        {
            manager.GetComponent<MASB_Reset_Scene>().resetScene();
        }
    }

    public void GetHealthBars()
    {
        healthbar.hp100 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_100");
        healthbar.hp90 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_90");
        healthbar.hp80 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_80");
        healthbar.hp70 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_70");
        healthbar.hp60 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_60");
        healthbar.hp50 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_50");
        healthbar.hp40 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_40");
        healthbar.hp30 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_30");
        healthbar.hp20 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_20");
        healthbar.hp10 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_10");
        healthbar.hp00 = GameObject.Find("/UI_Canvas/HealthBar/HealthBar_00");

        healthbar.hp100.SetActive(true);
        healthbar.hp90.SetActive(false);
        healthbar.hp80.SetActive(false);
        healthbar.hp70.SetActive(false);
        healthbar.hp60.SetActive(false);
        healthbar.hp50.SetActive(false);
        healthbar.hp40.SetActive(false);
        healthbar.hp30.SetActive(false);
        healthbar.hp20.SetActive(false);
        healthbar.hp10.SetActive(false);
        healthbar.hp00.SetActive(false);

        healthbar.UIBleed = GameObject.Find("/UI_Canvas/HealthBar/Heart/BloodSplatter").GetComponent<ParticleSystem>(); //JDH
        healthbar.PlayerBleed = GameObject.Find("Player").GetComponent<ParticleSystem>(); //JDH
        healthbar.UIBleed.Stop(); //JDH
        healthbar.PlayerBleed.Stop(); //JDH

    } //JD's HealthBar graphics
    public void DisplayHealth() //JD UI stuff
    {
        if (healthbar.isBleeding == true) //JDH
        {
            healthbar.bleedTimer += 0.1f; //JDH
            healthbar.UIBleed.Play(); //JDH
            healthbar.PlayerBleed.Play(); //JDH
            if (healthbar.bleedTimer >= healthbar.bleedTimerMax) //JDH
            {
                healthbar.UIBleed.Stop(); //JDH
                healthbar.PlayerBleed.Stop(); //JDH
                healthbar.bleedTimer = 0; //JDH
                healthbar.isBleeding = false; //JDH
            }
        }
        if (playerHealth >= 10)
        {
            healthbar.hp100.SetActive(true);
        }
        else
        {
            healthbar.hp100.SetActive(false);
        }
        if (playerHealth == 9)
        {
            healthbar.hp90.SetActive(true);
        }
        else
        {
            healthbar.hp90.SetActive(false);
        }
        if (playerHealth == 8)
        {
            healthbar.hp80.SetActive(true);
        }
        else
        {
            healthbar.hp80.SetActive(false);
        }
        if (playerHealth == 7)
        {
            healthbar.hp70.SetActive(true);
        }
        else
        {
            healthbar.hp70.SetActive(false);
        }
        if (playerHealth == 6)
        {
            healthbar.hp60.SetActive(true);
        }
        else
        {
            healthbar.hp60.SetActive(false);
        }
        if (playerHealth == 5)
        {
            healthbar.hp50.SetActive(true);
        }
        else
        {
            healthbar.hp50.SetActive(false);
        }
        if (playerHealth == 4)
        {
            healthbar.hp40.SetActive(true);
        }
        else
        {
            healthbar.hp40.SetActive(false);
        }
        if (playerHealth == 3)
        {
            healthbar.hp30.SetActive(true);
        }
        else
        {
            healthbar.hp30.SetActive(false);
        }
        if (playerHealth == 2)
        {
            healthbar.hp20.SetActive(true);
        }
        else
        {
            healthbar.hp20.SetActive(false);
        }
        if (playerHealth == 1)
        {
            healthbar.hp10.SetActive(true);
        }
        else
        {
            healthbar.hp10.SetActive(false);
        }
        if (playerHealth <= 0)
        {
            healthbar.hp00.SetActive(true);
        }
        else
        {
            healthbar.hp00.SetActive(false);
        }
    } //Display JD's health bar graphics
}
