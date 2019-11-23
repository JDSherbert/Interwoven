using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASB_Player_Health_Controller : MonoBehaviour
{
    public int playerHealth = 10;
    private GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            killPlayer();
        }
    }

    public void damagePlayer(int damage)
    {
        playerHealth -= damage;
        Debug.Log(playerHealth);
    }

    void killPlayer()
    {
        manager.GetComponent<MASB_Reset_Scene>().resetScene();
    }
}
