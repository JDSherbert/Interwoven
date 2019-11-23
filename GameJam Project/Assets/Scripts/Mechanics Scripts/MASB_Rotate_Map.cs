using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASB_Rotate_Map : MonoBehaviour
{
    public GameObject player;
    public int curX = 0;
    public int curZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.eulerAngles = new Vector3(curX, 0, curZ);
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
            rotate("z-");
        }
        else if (player.transform.position.z < ((12.4) * -1) && player.transform.position.x < 12.4 && player.transform.position.x > ((12.4) * -1))
        {
            rotate("z+");
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
        else if (direction == "z+")
        {
            transform.RotateAround(Vector3.zero, Vector3.right, 90 * Time.deltaTime);
            transform.eulerAngles = new Vector3(Mathf.RoundToInt(transform.eulerAngles.x), transform.eulerAngles.y, transform.eulerAngles.z);
            if (transform.eulerAngles.x >= 89 && transform.eulerAngles.x < 90)
            {
                curX = 90;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(player.transform.position.x, 13, -10);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.x >= 179 && transform.eulerAngles.x < 180)
            {
                curX = 180;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(player.transform.position.x, 13, -10);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.x >= 269 && transform.eulerAngles.x < 270)
            {
                curX = 270;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(player.transform.position.x, 13, -10);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
            else if (transform.eulerAngles.x >= 359)
            {
                curX = 0;
                player.GetComponent<JDH_PlayerControl_Script>().canPlayerMove = true;
                player.transform.position = new Vector3(player.transform.position.x, 13, -10);
                transform.eulerAngles = new Vector3(curX, 0, curZ);
            }
        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.left, 90 * Time.deltaTime);
            //player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }
}
