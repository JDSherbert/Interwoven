using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASB_Rotate_Map : MonoBehaviour
{
    public GameObject player;
    public int curX = 0;
    public int curZ = 180;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.eulerAngles = new Vector3(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, 0);
        if (player.transform.position.x >= 12.4 && player.transform.position.z < 12.4 && player.transform.position.z > ((12.4) * -1))
        {
            rotate("x+");
        }
        else if (player.transform.position.x < ((12.4) * -1) && player.transform.position.z < 12.4 && player.transform.position.z > ((12.4) * -1))
        {
            rotate("x-");
        }
        else if (player.transform.position.z > 12.4 && player.transform.position.x < 12.4 && player.transform.position.x > ((12.4) * -1))
        {
            player.transform.position = new Vector3(player.transform.position.x, 13, -10);
        }
        else if (player.transform.position.z < ((12.4) * -1) && player.transform.position.x < 12.4 && player.transform.position.x > ((12.4) * -1))
        {
            player.transform.position = new Vector3(player.transform.position.x, 13, 10);
        }
    }

    void rotate(string direction)
    {
        player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = false;
        player.transform.position = new Vector3(player.transform.position.x, 100, player.transform.position.z);
        if (direction == "x+")
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, 90 * Time.deltaTime);
            if (transform.eulerAngles.z >= 89 && transform.eulerAngles.z < 90)
            {
                curZ = 90;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(-10, 13, player.transform.position.z);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.z >= 179 && transform.eulerAngles.z < 180)
            {
                curZ = 180;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(-10, 13, player.transform.position.z);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.z >= 269 && transform.eulerAngles.z < 270)
            {
                curZ = 270;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(-10, 13, player.transform.position.z);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.z >= 359)
            {
                curZ = 0;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(-10, 13, player.transform.position.z);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
        }
        else if (direction == "x-")
        {
            transform.RotateAround(Vector3.zero, Vector3.back, 90 * Time.deltaTime);
            if (transform.eulerAngles.z <= 271 && transform.eulerAngles.z > 270)
            {
                curZ = 270;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(10, 13, player.transform.position.z);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.z <= 181 && transform.eulerAngles.z > 180)
            {
                curZ = 180;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(10, 13, player.transform.position.z);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.z <= 91 && transform.eulerAngles.z > 90)
            {
                curZ = 90;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(10, 13, player.transform.position.z);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.z <= 1)
            {
                curZ = 0;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(10, 13, player.transform.position.z);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
        }
    }
}
