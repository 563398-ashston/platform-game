using UnityEngine;

public class pickUpScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(gameObject.name + " has collided with: " + other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy( gameObject );
        }
    }
}
