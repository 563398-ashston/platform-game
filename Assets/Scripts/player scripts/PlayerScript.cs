using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Rigidbody2D rb;
    Animator anim;
    HelperScript helper;
    public LayerMask groundLayerMask;
    bool isGrounded;
    public float lives;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundLayerMask = LayerMask.GetMask("Ground");
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float xvel, yvel;

        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;



        if (Input.GetKey("d"))
        {
            xvel = 7;
        }
        else
        {
            xvel = 0;
        }

        if (Input.GetKey("a"))
        {
            xvel = -7;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yvel = 20;
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);


        if (xvel < 0)
        {
            helper.DoFlipObject(true);
        }

        if (xvel > 0)
        {
            helper.DoFlipObject(false);
        }


        if (yvel >= 0.1f)
        {
            anim.SetBool("isJumping", true);
            print("player jumped");
        }
        else
        {
            anim.SetBool("isJumping", false);
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



        if (ExtendedRayCollisionCheck(0, 0) == true)
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

