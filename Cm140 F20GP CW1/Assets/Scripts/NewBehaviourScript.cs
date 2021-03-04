using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public GameObject Fireball;
    public GameObject crosshairs;
    private Vector3 target;
    public GameObject player;

    public float speed = 15.0f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {

        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

       Vector3 Difference = target - player.transform.position;
       float rotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
       player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        //Firing 
        if (Input.GetMouseButtonDown(0))
        {
            float distance = Difference.magnitude;
            Vector2 direction = Difference / distance;
            direction.Normalize();
            fire(direction, rotationZ);
        }
       

    }
    //Creating Fired object and moving it
    void fire(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(Fireball) as GameObject;
        b.transform.position = player.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}

