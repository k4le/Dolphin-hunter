using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayer : MonoBehaviour
{
    GameObject player;
	GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		gameManager = GameObject.FindGameObjectWithTag("gameManager");
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			gameManager.GetComponent<Game_manager>().updateScore((int)Mathf.Abs(transform.position.y));
			int dir = Random.Range(0, 2);
			if (dir == 0) {
				dir = -1;
			}
			transform.position += new Vector3(Random.Range(100, 200) * dir, 0.0f, 0.0f);
		}
	}
}
