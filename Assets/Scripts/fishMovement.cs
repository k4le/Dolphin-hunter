using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
	private int dir;
	private SpriteRenderer spriteRenderer;
	public char[] movementSpeed;
	private float movementSpeedFloat;
	private GameObject player;
	// Start is called before the first frame update
	void Start()
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		player = GameObject.FindWithTag("Player");
		dir = Random.Range(0, 2);
		if (dir == 0) {
			dir = -1;
			spriteRenderer.flipX = true;
		}
		movementSpeedFloat = Random.Range((int)movementSpeed[0] - 48, (int)movementSpeed[1] - 48);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) < 100) {
			transform.position = new Vector3(transform.position.x + Time.deltaTime * movementSpeedFloat * dir, transform.position.y, 0.0f);
		}
		if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) > 100 && Vector3.Distance(player.GetComponent<Transform>().position, transform.position) < 110) {
			dir *= -1;
			if (dir == -1) {
				spriteRenderer.flipX = true;
			} else {
				spriteRenderer.flipX = false;
			}
		}
	}


}
