using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacManMove : MonoBehaviour
{

    //public int speed;//the speed pacman can travel
    public int score = 0;//the score
    public int livesLeft = 2;//how many extras lives pacman has left

    public float speed = 0.4F;
    Vector2 dest = Vector2.zero;

    public Text scoreText;//the Text UI Component that shows the score
    public Image life1;
    public Image life2;

    //private Vector2 direction;//the direction pacman is going
    private bool alive = true;

    Rigidbody2D rb2d;
    Animator animator;

    //public Portal otherPortal;
    //public bool receiving = false;

    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (!receiving)
    //    {
    //        otherPortal.receiving = true;
    //        coll.gameObject.transform.position = otherPortal.gameObject.transform.position;
    //    }
    //    receiving = false;
    //}


//Use this for initialization

//void Start()
// {

//    rb2d = GetComponent<Rigidbody2D>();

//    animator = GetComponent<Animator>();
// }

void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dest = transform.position;
    }


    //void FixedUpdate()
    //{
    //    // Move closer to Destination

    //    // Check for Input if not moving
    //    if ((Vector2)transform.position == dest)
    //    {
    //        if (Input.GetKey(KeyCode.UpArrow))
    //        {
    //            dest = (Vector2)transform.position + Vector2.up;
    //        }

    //        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
    //        {
    //            dest = (Vector2)transform.position + Vector2.right;
    //        }

    //        if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
    //        {
    //            dest = (Vector2)transform.position - Vector2.up;
    //        }

    //        if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
    //        {
    //            dest = (Vector2)transform.position - Vector2.right;
    //        }
    //    }

    //    // Animation Parameters
    //    Vector2 dir = dest - (Vector2)transform.position;
    //    GetComponent<Animator>().SetFloat("DirX", dir.x);
    //    GetComponent<Animator>().SetFloat("DirY", dir.y);
    //}

    void FixedUpdate()
    {
        // Move closer to Destination


        //Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
           
            }

            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
           
            }

            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
           
            }

            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
          
            }
       }



        //rb2d.velocity = dest * speed;
        

        //if (rb2d.velocity.x == 0)
        //{
        //    dest = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
        //}
        //if (rb2d.velocity.y == 0)
        //{
        //    dest = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
        //}


        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);


        //Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;

        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);


    }


    //void FixedUpdate()
    //{
    //    if (alive)
    //    {
    //        animator.SetFloat("DirX", rb2d.velocity.magnitude);
    //        if (Input.GetAxis("Horizontal") < 0 && valid(Vector2.left))
    //        {
    //            direction = Vector2.left;
    //        }
    //        if (Input.GetAxis("Horizontal") > 0 && valid(Vector2.right))
    //        {
    //            direction = Vector2.right;
    //        }
    //        if (Input.GetAxis("Vertical") < 0 && valid(Vector2.down))
    //        {
    //            direction = Vector2.down;
    //        }
    //        if (Input.GetAxis("Vertical") > 0 && valid(Vector2.up))
    //        {
    //            direction = Vector2.up;
    //        }
    //        rb2d.velocity = direction * speed;
    //        transform.up = direction;
    //        if (rb2d.velocity.x == 0)
    //        {
    //            transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
    //        }
    //        if (rb2d.velocity.y == 0)
    //        {
    //            transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
    //        }
    //    }
    //}

    //Update is called once per frame
    //void FixedUpdate()
    //{


    //    if (alive)
    //    {

    //        Collider2D co = new Collider2D();

    //        //animator.SetFloat("DirX", rb2d.velocity.magnitude);
    //        if (Input.GetAxis("Horizontal") < 0 && valid(-Vector2.right))
    //        {
    //            dest = Vector2.left;
    //        }
    //        if (Input.GetAxis("Horizontal") > 0 && valid(Vector2.right))
    //        {
    //            dest = Vector2.right;
    //        }
    //        if (Input.GetAxis("Vertical") < 0 && valid(-Vector2.up))
    //        {
    //            dest = Vector2.down;
    //        }
    //        if (Input.GetAxis("Vertical") > 0 && valid(Vector2.up))
    //        {
    //            dest = Vector2.up;
    //        }
    //        rb2d.velocity = dest * speed;
    //        transform.up = dest;
    //        if (rb2d.velocity.x == 0)
    //        {
    //            transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
    //        }
    //        if (rb2d.velocity.y == 0)
    //        {
    //            transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
    //        }

    //        //GetComponent<Animator>().SetFloat("DirX", direction.x);
    //        //GetComponent<Animator>().SetFloat("DirY", direction.y);
    //        //Vector2 p = Vector2.MoveTowards(transform.position, direction, speed);
    //        //rb2d.MovePosition(p);
    //    }
    //}

    public void addPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "" + score;
    }

    public void setAlive(bool isAlive)
    {
        alive = isAlive;
        animator.SetBool("alive", alive);
        rb2d.velocity = Vector2.zero;
    }

    public void setLivesLeft(int lives)
    {
        livesLeft = lives;
        life1.enabled = livesLeft >= 1;
        life2.enabled = livesLeft >= 2;
    }

    //public float speed = 0.4f;
    //Vector2 dest = Vector2.zero;

    //void Start()
    //{
    //    dest = transform.position;
    //}

    //void FixedUpdate()
    //{
    //    // Move closer to Destination

    //    // Check for Input if not moving
    //    if ((Vector2)transform.position == dest)
    //    {
    //        if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
    //        {
    //            dest = (Vector2)transform.position + Vector2.up;
    //        }

    //        if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
    //        {
    //            dest = (Vector2)transform.position + Vector2.right;
    //        }

    //        if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
    //        {
    //            dest = (Vector2)transform.position - Vector2.up;
    //        }

    //        if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
    //        {
    //            dest = (Vector2)transform.position - Vector2.right;
    //        }
    //    }

    //    // Animation Parameters
    //    Vector2 dir = dest - (Vector2)transform.position;
    //    GetComponent<Animator>().SetFloat("DirX", dir.x);
    //    GetComponent<Animator>().SetFloat("DirY", dir.y);
    //}

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);

        //Collider2D co = new Collider2D();

        //if (hit.collider.name == "blinky")
        //{
        //    Destroy(co.gameObject);
        //}


        if (hit.collider.name.Contains("level"))
        {
            return false;
        }
        else if (hit.collider.name.Contains("pacdot"))
        {
            return true;
        }
        else if (hit.collider.name.Contains("Portal"))
        {
            return true;
        }
        else
        {
            return (hit.collider == GetComponent<Collider2D>());
        }

    }

    //public Portal otherPortal;
    //public bool receiving = false;

    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (!receiving)
    //    {
    //        otherPortal.receiving = true;
    //        coll.gameObject.transform.position = otherPortal.gameObject.transform.position;
    //    }
    //    receiving = false;
    //}

    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "Portal2")
        {


            dest = new Vector2(9, 6);
            rb2d.transform.position = dest;
                     
        }
        else if (co.name == "Portal")
        {


            dest = new Vector2(-9, 6);
            rb2d.transform.position = dest;
        }

    }

    //bool valid(Vector2 dir)
    //{
    //    // Cast Line from 'next to Pac-Man' to 'Pac-Man'
    //    Vector2 pos = transform.position;
    //    RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
    //    return (hit.collider == GetComponent<Collider2D>());
    //}
}
