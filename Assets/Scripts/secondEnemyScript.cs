using UnityEngine;

public class secondEnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { }
    public LayerMask groundLayerMask;
    Animator anim;
    Rigidbody2D rb;
    float xvel;
    Vector3 localScale;

    // Update is called once per frame
    void Update()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        xvel = 10;
    }
}
