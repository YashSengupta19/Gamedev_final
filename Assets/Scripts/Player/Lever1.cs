using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody2D rb;
    private Collider2D doorCollider; // Declare at the class level
    private Rigidbody2D doorRigidbody; // Declare at the class level
    private GameObject door;
    private GameObject lever;
    public PlayerMovement PM;
    public bool isCollision;
    public bool isTrigger; // Declare at the class level
    private Vector3 initposLever;
    private Vector3 initposDoor;

    public Lever2 L;

    //private float jumpForce = 11f;



    // Start is called before the first frame update
    void Start()
    {
        isCollision = false;
        isTrigger = false;
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing. Attach a Rigidbody to the GameObject.");
        }

        door = GameObject.Find("Door");
        lever = GameObject.Find("Lever");

        if (door == null)
        {
            Debug.LogError("Could not find the 'Door' GameObject.");
        }

        doorCollider = door.GetComponent<Collider2D>();
        doorRigidbody = door.GetComponent<Rigidbody2D>();

        initposLever = lever.transform.position;
        initposDoor = door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic goes here if needed
        if (isCollision || L.isCollision)
        {
            doorRigidbody.gravityScale = 0;
            isTrigger = true;
            //PM.isGrounded = true;
            door.transform.Translate(new Vector3(0f,1f,0f) * speed * Time.deltaTime);
        }
        else
        {
            isTrigger = false;

            doorRigidbody.gravityScale = 20;

            if (initposLever.y >= lever.transform.position.y) 
            {
                lever.transform.Translate(new Vector3(0f, 1f, 0f) * 1 * Time.deltaTime);
            }

            if (initposDoor.y <= door.transform.position.y - (float)0.3)
            {
                door.transform.Translate(new Vector3(0f, -1f, 0f) * (float)5 * Time.deltaTime);
            }
        }

        if (isTrigger || L.isTrigger)
        {
            doorCollider.isTrigger = true;
        }
        else
        {
            doorCollider.isTrigger = false;
        }

        //PM.PlayerJump();

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Lever")
        {
            isCollision = true;
            Debug.Log("Collided");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Lever")
        {
            isCollision = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "DoorClosingCollider")
        {
            isCollision = false;
        }
    }
}
