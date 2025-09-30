using UnityEngine;
using UnityEngine.Rendering;

public class SecondEnemyScript : MonoBehaviour
{
    float directionX;
    public LayerMask wallLayerMask;
    Animator anim;
    Rigidbody2D rb;
    float xvel;
    Vector3 localScale;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wallLayerMask = LayerMask.GetMask("wall");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        xvel = 5;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (xvel < 0)
        {
            print("I am moving left");
           // anim.SetBool("isWalking", true);

            if (ExtendedRayCollisionCheck(-1, 0) == true)
            {
                xvel = 5;
                
            }
        }

        if (xvel > 0)
        {
            print("I am moving right");
            //anim.SetBool("isWalking", true);

            if (ExtendedRayCollisionCheck(1, 0) == true)
            {
                xvel = -5;
                
            }
        }


        //gameObject.transform.localScale = new Vector3(-1, 1, 1);

        rb.linearVelocity = new Vector2(xvel, 0);
    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast 
        bool hitSomething = false;

        //convert x and y offset into a Vector 3
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downwards 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, wallLayerMask);

        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            print("player has collided with a wall");
            hitColor = Color.green;
            hitSomething = true;
        }

        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
}