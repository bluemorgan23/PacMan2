using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{

    Rigidbody2D rb2d;
    Animator animator;

    public float speed = 0.4F;
    Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dest = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move closer to Destination

        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.W) && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }

            if (Input.GetKey(KeyCode.D) && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }

            if (Input.GetKey(KeyCode.S) && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
            }

            if (Input.GetKey(KeyCode.A) && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
            }
        }

        //rb2d.velocity = dest * speed;
        //transform.up = dest;

        //if (rb2d.velocity.x == 0)
        //{
        //    transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
        //}
        //if (rb2d.velocity.y == 0)
        //{
        //    transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
        //}





        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman1")
            Destroy(co.gameObject);
    }

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        if (hit.collider.name.Contains("level"))
        {
            return false;
        }
        else if (hit.collider.name.Contains("pacdot"))
        {
            return true;
        }
        else
        {
            return (hit.collider == GetComponent<Collider2D>());
        }

    }
}
