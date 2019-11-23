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
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInChildren<MeshRenderer>().isVisible)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
            transform.LookAt(player.transform, Vector3.up);
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
