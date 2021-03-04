using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private Rigidbody2D rb;
    public GameObject target;
    float moveSpeed;
    private Vector3 directionToTarget;

    void Start()
    {
        //sets player as target
        target = GameObject.Find("Char");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 3f);

    }

    void Update()
    {

        MoveEnemy();

    }
  
    void MoveEnemy()
    {
        if (target != null)
        {
            //moves towards player if target is selected
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed,
                                        directionToTarget.y * moveSpeed);
        }
        else
            rb.velocity = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {

            //check for player collision
            case "Player":
                DeployEnemies.spawnAllowed = false;

                Destroy(other.gameObject);
                target = null;

                break;

                //check for fireball collision
            case "Fire":
                ScoreScript.scoreVal += 10; 
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
        }
    }
}
