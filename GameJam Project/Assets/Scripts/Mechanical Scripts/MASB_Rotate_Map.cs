using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASB_Rotate_Map : MonoBehaviour
{
    public GameObject player;
    public GameObject manager;
    public float scale;
    public bool isPlayerFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        scale = GameObject.Find("Cube").transform.localScale.x;
        player = GameObject.Find("Player");
        manager = GameObject.Find("CubeManager");
        transform.eulerAngles = new Vector3(manager.GetComponent<MASB_Cube_Manager>().curRotX, 0, manager.GetComponent<MASB_Cube_Manager>().curRotZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > scale / 2 && player.transform.position.z < scale / 2 && player.transform.position.z > ((scale / 2) * -1))
        {
            rotateMap("x+");
        } 
        else if (player.transform.position.x < ((scale / 2) * -1) && player.transform.position.z < scale / 2 && player.transform.position.z > ((scale / 2) * -1))
        {
            rotateMap("x-");
        }
        else if (player.transform.position.z > scale / 2 && player.transform.position.x < scale / 2 && player.transform.position.x > ((scale / 2) * -1))
        {
            rotateMap("z-");
        }
        else if (player.transform.position.z < ((scale / 2) * -1) && player.transform.position.x < scale / 2 && player.transform.position.x > ((scale / 2) * -1))
        {
            rotateMap("z+");
        }
    }

    void rotateMap(string direction)
    {
        if (player.GetComponent<JDH_ThirdPersonController_Script>().playerData.IsPlayerMovable)
        {
            freezePlayer();
            isPlayerFrozen = true;
        }
        if (direction == "x+")
        {
            transform.RotateAround(Vector3.zero, Vector3.forward, 90 * Time.deltaTime);
            if (transform.eulerAngles.z >= 89 && transform.eulerAngles.z < 90)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotZ = 90;
                player.transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);
                Destroy(gameObject);
            } 
            else if (transform.eulerAngles.z >= 179 && transform.eulerAngles.z < 180)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotZ = 180;
                player.transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.z >= 269 && transform.eulerAngles.z < 270)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotZ = 270;
                player.transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.z >= 359)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotZ = 0;
                player.transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);
                Destroy(gameObject);
            }
        }
        else if (direction == "x-")
        {
            transform.RotateAround(Vector3.zero, Vector3.back, 90 * Time.deltaTime);
            if (transform.eulerAngles.z <= 271 && transform.eulerAngles.z > 270)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotZ = 270;
                player.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.z <= 181 && transform.eulerAngles.z > 180)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotZ = 180;
                player.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.z <= 91 && transform.eulerAngles.z > 90)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotZ = 90;
                player.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.z <= 1)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotZ = 0;
                player.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);
                Destroy(gameObject);
            }
        }
        else if (direction == "z+")
        {
            transform.RotateAround(Vector3.zero, Vector3.right, 90 * Time.deltaTime);
            if (transform.eulerAngles.x >= 89 && transform.eulerAngles.x < 90)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotX = 90;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.x >= 179 && transform.eulerAngles.x < 180)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotX = 180;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.x >= 269 && transform.eulerAngles.x < 270)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotX = 270;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.x >= 359)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotX = 0;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 1);
                Destroy(gameObject);
            }
        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.left, 90 * Time.deltaTime);
            if (transform.eulerAngles.x <= 271 && transform.eulerAngles.x > 270)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotX = 270;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.x <= 181 && transform.eulerAngles.x > 180)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotX = 180;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.x <= 91 && transform.eulerAngles.x > 90)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotX = 90;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
                Destroy(gameObject);
            }
            else if (transform.eulerAngles.x <= 1)
            {
                unfreezePlayer(false, direction);
                manager.GetComponent<MASB_Cube_Manager>().curRotX = 0;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
                Destroy(gameObject);
            }
        }
    }

    void freezePlayer()
    {
        player.GetComponent<JDH_ThirdPersonController_Script>().playerData.IsPlayerMovable = false;
    }

    void unfreezePlayer(bool playerIsFrozen, string direction)
    {
        if (!playerIsFrozen)
        {
            player.GetComponent<JDH_ThirdPersonController_Script>().playerData.IsPlayerMovable = true;
        }
    }
}
