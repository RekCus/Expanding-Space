using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool isGoingRight = true;

    public Transform isGrounded;
    public Transform isWall;


    void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(isGrounded.position, Vector2.down, distance);
        //  RaycastHit2D wallInfo = Physics2D.Raycast(isWall.position, Vector2.right, 0.3f);
        if (groundInfo.collider == false)
        {
            turnAround();
        }

    }

    void turnAround()
        {
            if (isGoingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                isGoingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isGoingRight = true;
            }
        }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            turnAround();
                
        }
    }
}
