using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [Header("Set in Inspector")]
    public float speed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 500f;
    public GameObject idleSprite;
    
    
    bool facingRight = true;
    bool grounded = false;
    bool isHolding = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Animator animator;

    
    private static readonly int isGrounded = Animator.StringToHash("isGrounded");
    private static readonly int isJumping = Animator.StringToHash("isJumping");

    private void Start()
    {
        idleSprite.SetActive(true);
    }
    void FixedUpdate()
    {
        
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

    }

    private void Update()
    {
        float yAxis = Input.GetAxis("Vertical");

        float xAxis = Input.GetAxis("Horizontal"); // �������� a d;

        if (!PlantClimb.isClimbing)
        {
            if (!isHolding)
            {
                if (grounded && (Input.GetKeyDown(KeyCode.Space)))
                {

                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(xAxis * runSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(xAxis * speed, GetComponent<Rigidbody2D>().velocity.y);
                }
            }
            else
            {
                if (grounded && (Input.GetKeyDown(KeyCode.Space)))
                {

                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce - 100));
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(xAxis * runSpeed - 4, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(xAxis * speed - 2, GetComponent<Rigidbody2D>().velocity.y);
                }
            }
        }

       

        if (xAxis > 0 && !facingRight)
            Flip();
        else if (xAxis < 0 && facingRight)
            Flip();

        if (grounded || PlantClimb.isClimbing)
        {
            Debug.LogWarning("is grounded");
            animator.SetBool(isGrounded, true);
        }

        else
        {
            Debug.LogWarning("is jumping");
            animator.SetBool(isGrounded, false);
        }


    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void pickUp()
    {
        isHolding = true;
    }
}
