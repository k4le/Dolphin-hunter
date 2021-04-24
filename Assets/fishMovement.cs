using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    private int dir;

    public int movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        dir = Random.Range(0, 2);
        if (dir == 0) {
            dir = -1;
		}

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * movementSpeed * dir, transform.position.y, 0.0f);
    }
}
