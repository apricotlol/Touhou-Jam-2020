using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Author: Chic-Chichago
public class BlackholeControls : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    Vector2 movementunit;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.MovePosition((Vector2)transform.position + movementunit * speed * 10 * Time.deltaTime);
        //Debug.Log(movementunit);
        if (Input.GetKeyDown(KeyCode.E))
        {
            movementunit = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            movementunit = movementunit.normalized;
        }
        else if (Input.GetKeyDown(KeyCode.R)) movementunit = Vector2.zero;
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            movementunit = transform.position - GameObject.Find("Player").GetComponent<Transform>().position;
            movementunit = -movementunit.normalized;
            //Its a bit nasty but it works
        }
    }


}
