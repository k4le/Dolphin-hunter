using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int dir;
    [SerializeField] float sightRange;

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
        player = GameObject.FindGameObjectWithTag("Player");
        
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
            Wander();
        }
    }

    void Wander ()
    {
        status = EnemyStatus.wander;
        dir = Random.Range(0, 2);
        if (dir == 0)
        {
            dir = -1;
        }
    }
    private void FixedUpdate()
    {
        if (status == EnemyStatus.wander)
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * movementSpeedFloat * dir, transform.position.y, 0.0f);
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


}
