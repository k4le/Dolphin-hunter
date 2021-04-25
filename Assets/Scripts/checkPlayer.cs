using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayer : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			int dir = Random.Range(0, 2);
			if (dir == 0) {
				dir = -1;
			}
			transform.position += new Vector3(Random.Range(100, 200) * dir, 0.0f, 0.0f);
		}
	}
}
