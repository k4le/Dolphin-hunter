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
			Destroy(gameObject);
		}
	}
}
