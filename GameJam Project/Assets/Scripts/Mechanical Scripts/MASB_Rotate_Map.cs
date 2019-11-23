using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASB_Rotate_Map : MonoBehaviour
{
    public GameObject player;
    public float scale;
    public bool isPlayerFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        scale = GameObject.Find("Cube").transform.localScale.x;
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
        if (!isPlayerFrozen)
        {
            freezePlayer();
        }
        if (direction == "x+")
        {
            if (transform.eulerAngles.z < 90)
            {
                transform.Rotate(0, 0, 90 * Time.deltaTime);
            }
        }
        else if (direction == "x-")
        {
            if (transform.eulerAngles.z > 270 || transform.eulerAngles.z == 0)
            {
                transform.Rotate(0, 0, -90 * Time.deltaTime);
            }
        }
        else if (direction == "z+")
        {
            if (transform.eulerAngles.x < 90)
            {
                transform.Rotate(90 * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            if (transform.eulerAngles.x > 270 || transform.eulerAngles.x == 0)
            {
                transform.Rotate(-90 * Time.deltaTime, 0, 0);
            }
        }
    }

    void freezePlayer()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        isPlayerFrozen = true;
    }

    void unfreezePlayer()
    {

    }
}
