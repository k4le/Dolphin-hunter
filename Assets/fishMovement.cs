using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    private int dir;

    public char[] movementSpeed;
    private float movementSpeedFloat;
    // Start is called before the first frame update
    void Start()
    {
        dir = Random.Range(0, 2);
        if (dir == 0) {
            dir = -1;
		}
     
        movementSpeedFloat = Random.Range((int)movementSpeed[0] - 48, (int)movementSpeed[1] - 48);
        Debug.Log(movementSpeedFloat);
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * movementSpeedFloat * dir, transform.position.y, 0.0f);
    }
}
