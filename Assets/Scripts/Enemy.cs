using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int dir;
    [SerializeField] float sightRange;
    private SpriteRenderer spriteRenderer;
    private float movementSpeedFloat;
    public char[] movementSpeed;

    GameObject player;

    enum EnemyStatus
    {
        wander,
        follow_player,
        attack
    };
    [SerializeField] EnemyStatus status;
    // Start is called before the first frame update
    void Start()
    {

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        while (Vector3.Distance(player.transform.position,transform.position) < 30)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y - 1,transform.position.z);
        }

        movementSpeedFloat = Random.Range((int)movementSpeed[0] - 48, (int)movementSpeed[1] - 48);
        Wander();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 7)
        {
            status = EnemyStatus.attack;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < sightRange)
        {
            status = EnemyStatus.follow_player;
        }else if (status == EnemyStatus.follow_player)
        {
            int dir;
            if (player.transform.position.x > transform.position.x)
            {
                dir = 1;
            }else
            {
                dir = -1;
            }
            Wander(dir);
        }
    }

    void Wander(int direction = 0)
    {
        status = EnemyStatus.wander;
        if (direction == 0)
        {
            dir = Random.Range(0, 2);
        } else {
            dir = direction;
        }

        if (dir == 0)
        {
            dir = -1;
        }
    }
    private void FixedUpdate()
    {
        if (status == EnemyStatus.wander)
        {
           transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0);
            if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) < 200)
            {
                transform.position = new Vector3(transform.position.x + Time.deltaTime * movementSpeedFloat * dir, transform.position.y, 0.0f);
            }
            if (Vector3.Distance(player.GetComponent<Transform>().position, transform.position) > 200 && Vector3.Distance(player.GetComponent<Transform>().position, transform.position) < 110)
            {
                dir *= -1;
                if (dir == -1)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
        if (status == EnemyStatus.follow_player)
        {
            FollowPlayer(movementSpeedFloat);
        }
        if (status == EnemyStatus.attack)
        {
            FollowPlayer(movementSpeedFloat*5);
        }
    }

    private void FollowPlayer (float speed)
    {
        Vector3 vectorToTarget = player.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "wall") {
            dir *= -1;
            if (dir == -1) {
                spriteRenderer.flipX = true;
            } else {
                spriteRenderer.flipX = false;
            }
        }

        if (angle < 90 && angle < 270)
        {
            //sDebug.Log("asdasd");
            spriteRenderer.flipY = false;
        }else
        {
            spriteRenderer.flipY = true;
        }
    }
}
