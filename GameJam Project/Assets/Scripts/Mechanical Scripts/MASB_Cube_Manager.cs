using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASB_Cube_Manager : MonoBehaviour
{
    public GameObject cube;
    public int curRotZ = 0;
    public int curRotX = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("CubeMap") && !GameObject.Find("CubeMap(Clone)"))
        {
            Instantiate(cube, new Vector3(0, 0, 0), new Quaternion(curRotX, 0, curRotZ, 0));
        }
    }
}
