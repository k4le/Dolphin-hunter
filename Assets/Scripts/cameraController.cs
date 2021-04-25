using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float distance = 22;
    GameObject player;
    public GameObject[] walls;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool tooCloseWall = false;
        foreach (GameObject wall in walls)
        {
            Vector3 p1 = new Vector3(player.transform.position.x, 0, 0);
            Vector3 p2 = new Vector3(wall.transform.position.x, 0, 0);
            float dist = Vector3.Distance(p1, p2);
            if (dist < distance)
            {
                tooCloseWall = true;
            }
        }
        Vector3 pos;
        if (tooCloseWall == true)
        {
            pos = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {

            pos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
        transform.position = pos;
    }
    
        
    
}
