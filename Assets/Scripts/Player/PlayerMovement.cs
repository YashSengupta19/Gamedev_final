using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private string JUMP_ANIMATION = "jump";
    public bool isGrounded;  // Used in Lever code
    private string GROUND_TAG = "Path";
    private string LEVER_TAG =  "Lever";
    private string SUFFER_ANIMATION = "suffer";
    private string ENEMY_TAG = "Enemy";
    private string TURTLE_TAG = "Turtle";
    private string ARROW_TAG = "Arrow";
    [SerializeField] private AudioSource jumpEffect,damage;

    // __Player Health__
    public int maxHealth = 100;
    public int currentHealth;
    private bool isInvincible = false;
    public float invincibilityDuration = 1f;
    public PlayerHealth healthBar;

    // __Clue__
    public GameObject hintBoard;
    public GameObject AnswerBox;
    public Button Button2;
    public InputField input;
    public Button Button1;


    // private void OnEnable()
    // {
    //     GameManager.OnPlayerDeath += EnableGameOverMenu;
    // }

    // private void OnDisable()
    // {
    //     GameManager.OnPlayerDeath -= EnableGameOverMenu;
    // }

    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        // Enabling the Gamemovement everytime we start the game
        //EnablePlayerMovement();
        // __Player Health__
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        // __Clue__
        hintBoard.SetActive(false);
        Button2.gameObject.SetActive(false);  
        Button2.gameObject.SetActive(false);
        input.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<=0)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);
        }
        if (!isInvincible)
        {
            PlayerMoveKeyboard();
            AnimatePlayer();
            PlayerJump();
        }
        if(movementX != 0) 
        {
            jumpEffect.enabled  =true;
            jumpEffect.Play();
        }
        else
        {
            jumpEffect.enabled = false;
        }
        
        //jumpEffect.enabled = true;
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void AnimatePlayer()
    {
        //we are going to right side.
        if (movementX > 0 && isGrounded)
        {
            anim.SetBool(WALK_ANIMATION, true);
            //anim.SetBool(JUMP_ANIMATION, false);
            sr.flipX = false;
            jumpEffect.enabled = true;
        }else if (movementX < 0 && isGrounded)
        {
            //we are going to left side.
            anim.SetBool(WALK_ANIMATION, true);
            anim.SetBool(JUMP_ANIMATION, false);
            sr.flipX = true;
            jumpEffect.enabled = true;
        }else if(movementX >0 && !isGrounded)
        {
            //we are going to jump right side
            anim.SetBool(WALK_ANIMATION, false);
            anim.SetBool(JUMP_ANIMATION, true);
            sr.flipX = false;

        }else if(movementX<0 && !isGrounded)
        {
            //we are going to jump left side
            anim.SetBool(WALK_ANIMATION,false);
            anim.SetBool(JUMP_ANIMATION,true);
        }
        else
        {
            //we are not moving.
            if(isGrounded)
            {
                anim.SetBool(WALK_ANIMATION, false);
                anim.SetBool(JUMP_ANIMATION, false);

            }
            else
            {
                anim.SetBool(WALK_ANIMATION, false);
                anim.SetBool(JUMP_ANIMATION, true);
            }

        }
    }
    public void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2 (0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)|| collision.gameObject.CompareTag(LEVER_TAG)){
            isGrounded = true;
        }

        // __ Player Health __
        // Check for trigger with "Square"
        if ((collision.gameObject.name == "Turtle1" || collision.gameObject.name == "Turtle1 (1)"|| collision.gameObject.name == "Turtle1 (2)" )&& !isInvincible)
        {
            // Do something when the trigger is entered, e.g., reduce health
            damage.Play();
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);

            // Make the player invincible for a short duration
            StartCoroutine(MakeInvincible());
            
            Debug.Log("Triggered with Square. Current health: " + currentHealth);


            // Move the player back
            transform.Translate(new Vector3(-0.002f, 0f, 0f) * moveForce * Time.deltaTime);
        }

        if ((collision.gameObject.CompareTag(ENEMY_TAG)&& !isInvincible))
        {
            // Do something when the trigger is entered, e.g., reduce health
            damage.Play();
            currentHealth -= 30;
            healthBar.SetHealth(currentHealth);

            // Make the player invincible for a short duration
            StartCoroutine(MakeInvincible());
            
            Debug.Log("Triggered with Square. Current health: " + currentHealth);

            // Move the player back
            transform.Translate(new Vector3(-0.002f, 0f, 0f) * moveForce * Time.deltaTime);
        }
        // if (other.gameObject.name == "ClueChest"){
        //     hintBoard.SetActive(true);
        // }

        // __SUFFER__
        if (collision.gameObject.CompareTag(GROUND_TAG)){
           isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            //isGrounded = true;
            //Destroy(collision.gameObject);
            anim.SetBool(SUFFER_ANIMATION, true);

        }
        if (collision.gameObject.CompareTag(TURTLE_TAG))
        {
            //isGrounded = true;
            //Destroy(collision.gameObject);
            anim.SetBool(SUFFER_ANIMATION, true);

        }

        // __Clue__
        if (collision.gameObject.name == "ClueChest"){
            hintBoard.SetActive(true);
        }
 
        if(collision.gameObject.name=="AnswerBox"){
            Button2.gameObject.SetActive(true);
            Button2.onClick.AddListener(() => {
            input.gameObject.SetActive(true);
            Button1.gameObject.SetActive(true);
            Debug.Log("Done");
        });
        }
    }

    IEnumerator MakeInvincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG )){
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            //isGrounded = true;
            Destroy(collision.gameObject);
            anim.SetBool(SUFFER_ANIMATION, false);
        }
        if(collision.gameObject.CompareTag(TURTLE_TAG))
        {
            anim.SetBool(SUFFER_ANIMATION, false);
        }

        if (collision.gameObject.name == "ClueChest"){
            hintBoard.SetActive(false);
        }

        if(collision.gameObject.name == "AnswerBox")
        {
            Button2.gameObject.SetActive(false);
            input.gameObject.SetActive(false);
            Button1.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Boundary"))
        {
            currentHealth -= 100;
            healthBar.SetHealth(currentHealth);
        }

        if(other.gameObject.CompareTag(ARROW_TAG))
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
            anim.SetBool(SUFFER_ANIMATION, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(ARROW_TAG))
        {
            Destroy(other.gameObject);
            anim.SetBool(SUFFER_ANIMATION, false);
        }
    }

//     private void DisablePlayerMovement()
// {
//     anim.enabled = false;
//     myBody.isStatic = true;
// }

// private void EnablePlayerMovement()
// {
//     anim.enabled = true;
//     myBody.isDynamic = false;
// }
}
