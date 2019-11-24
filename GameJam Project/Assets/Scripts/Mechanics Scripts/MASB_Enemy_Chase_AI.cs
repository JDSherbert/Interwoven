using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASB_Enemy_Chase_AI : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = new Vector3(-9, 13, 10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (GetComponentInChildren<MeshRenderer>().isVisible)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1 * Time.deltaTime);
            transform.LookAt(player.transform, transform.up);
            transform.position = new Vector3(transform.position.x, 14.6f, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<MASB_Player_Health_Controller>().damagePlayer(2);
        }
    }
}
