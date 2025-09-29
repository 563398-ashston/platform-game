using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;

public class Movement : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    Animator anim;
    public LayerMask groundLayerMask;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        float xvel, yvel;

        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;



        if (Input.GetKey("a"))
        {
            xvel = -7;
        }
        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (Input.GetKey("d"))
        {
            xvel = +7;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            yvel = 20;
            print("do jump");
        }

        if (xvel >= 0.1f || xvel <= -0.1f)
        {
            anim.SetBool("isWalking", true);
            print("walking");
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        
        if (xvel > 0)
        {
            gameObject.transform.localScale = new Vector3 (1, 1, 1);
        }

            rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if (xvel < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);


        if( ExtendedRayCollisionCheck (0,0) == true)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;

        }
        print("isgrounded=" + isGrounded);

    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast 
        bool hitSomething = false;

        //convert x and y offset into a Vector 3
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downwards 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            print("player has collided with ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }

        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
}

