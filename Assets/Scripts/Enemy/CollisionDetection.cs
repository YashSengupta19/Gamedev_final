using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public float speed = 5f;
    private bool isMovingUp = true;
    private Rigidbody2D rb;
    public bool isTriggered = false;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Check if a Rigidbody2D component is attached
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing. Attach a Rigidbody2D to the GameObject.");
        }
    }

    void Update()
    {
        // Move the object based on the current direction
        if (isMovingUp && rb != null)
        {
            // Apply force in the up direction
            rb.velocity = new Vector2(0, speed);
        }
        else if (!isMovingUp && rb != null)
        {
            // Apply force in the down direction
            rb.velocity = new Vector2(0, -speed);
        }
    }

    // This method is called when a collision is detected
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision with "Box1"
        if (collision.gameObject.name == "Path1 (20)")
        {
            isMovingUp = false;
            Debug.Log("Collided with Box1. Moving down.");
        }
        // Check for collision with "Box2"
        else if (collision.gameObject.name == "Path1 (16)")
        {
            isMovingUp = true;
            Debug.Log("Collided with Box2. Moving up.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Wall") && !isTriggered)
    {
        isTriggered = true;

        // Determine the reflection direction based on the local orientation of the trigger
        Vector2 reflectionDirection = (other.transform.position.x > transform.position.x) ? -other.transform.right : other.transform.right;

        // Reflect the velocity using the determined reflection direction
        rb.velocity = Vector2.Reflect(rb.velocity, reflectionDirection);
    }
}

private void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Wall"))
    {
        isTriggered = false;
    }
}

}
