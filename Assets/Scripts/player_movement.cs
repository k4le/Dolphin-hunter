using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    [SerializeField] float oxygen = 100.0f;
    [SerializeField] float gravity = 3.0f;
    [SerializeField] float water_gravity = 1.0f;

    private Rigidbody2D rb;
    Vector3 velocity;

    private void Start()
    {
        oxygen = 100.0f;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.y < 0)
        {
            oxygen -= 20.0f * Time.deltaTime;

            rb.gravityScale = water_gravity;
        }
        else
        {
            oxygen = 100;
            rb.gravityScale = gravity;
        }

        transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        if (Input.GetMouseButton(0) && transform.position.y < 0)
        {
            rb.AddForce(mouseDir * 1000f * Time.deltaTime, ForceMode2D.Force);
        }

        if (rb.velocity.y > 0) 
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, -Mathf.Atan(rb.velocity.x / rb.velocity.y) * Mathf.Rad2Deg), Time.deltaTime * 9f);
        } else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 180.0f - Mathf.Atan(rb.velocity.x / rb.velocity.y) * Mathf.Rad2Deg), Time.deltaTime * 9f);
        }
    }

}
