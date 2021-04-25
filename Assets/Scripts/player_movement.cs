using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour

{
	[SerializeField] float gravity = 3.0f;
	[SerializeField] float water_gravity = 1.0f;
	[SerializeField] float movement_Speed = 2000;

	private SpriteRenderer spriteRenderer;
	public GameObject gameManager;

	private Rigidbody2D rb;
	Vector3 velocity;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		gameManager = GameObject.FindWithTag("GameController");
	}
	void Update()
	{
		if (rb.velocity.x < 0) {
			spriteRenderer.flipY = true;
		} else {
			spriteRenderer.flipY = false;
		}



		if (transform.position.y < 0) {
			rb.gravityScale = water_gravity;
		} else {
			rb.gravityScale = gravity;
		}

		transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
		var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var mouseDir = mousePos - gameObject.transform.position;
		mouseDir.z = 0.0f;
		mouseDir = mouseDir.normalized;

		if (Input.GetMouseButton(0) && transform.position.y < 0) {
			rb.AddForce(mouseDir * movement_Speed * Time.deltaTime, ForceMode2D.Force);

		}

		if (rb.velocity.y > 0) {
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 90.0f - Mathf.Atan(rb.velocity.x / rb.velocity.y) * Mathf.Rad2Deg), Time.deltaTime * 10f);
		} else if (rb.velocity.x > 0 || rb.velocity.y > 0) {
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 270.0f - Mathf.Atan(rb.velocity.x / rb.velocity.y) * Mathf.Rad2Deg), Time.deltaTime * 10f);

		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameManager.GetComponent<Game_manager>().OnEndOfGame();
        }
    }
}
