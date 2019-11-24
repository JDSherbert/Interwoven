using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //JDH

public class MASB_Reset_Scene : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    private GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Cube");
        cube = GameObject.Find("CubeMap");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetScene()
    {
        //Slightly better way to do this

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // JDH - Reloads scene from build index ;)

        /*
        player.transform.position = new Vector3(0, 13, -10);
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        player.GetComponent<MASB_Player_Health_Controller>().playerHealth = 10;
        enemy.transform.position = new Vector3(0, 13, 0);
        cube.transform.position = new Vector3(0, 0, 0);
        cube.transform.eulerAngles = new Vector3(0, 0, 0);*/
    }
}
