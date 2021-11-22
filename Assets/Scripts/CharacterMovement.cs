using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : Interactor
{

    [Header("Set in Inspector")]
    public float speed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 700f;
    
    
    bool grounded = false;
    bool isHolding = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Animator animator;
    public Animator elementAnimator;


    [HideInInspector]
    public short elementId;
    
    private static readonly int isGrounded = Animator.StringToHash("isGrounded");
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private static readonly int isHoldingObj = Animator.StringToHash("isHolding");
    private static readonly int element = Animator.StringToHash("elementId");


    void FixedUpdate()
    {
        
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

    }

    protected override void Update()
    {
        base.Update();
        Movement();

        Animate();
    }

    /*
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    */

    void pickUp()
    {
        isHolding = true;
    }

    void Movement()
    {
        float xAxis = Input.GetAxis("Horizontal");

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
        /*
        if (xAxis > 0 && !facingRight)
            Flip();
        else if (xAxis < 0 && facingRight)
            Flip(); */ 
    }

    void Animate()
    {
        float xAxis = Input.GetAxis("Horizontal");

        if (grounded || PlantClimb.isClimbing)
        {
            animator.SetBool(isGrounded, true);
        }

        else
        {
            animator.SetBool(isGrounded, false);
        }

        if (Mathf.Abs(xAxis) > 0)
        {
            animator.SetBool(isWalking, true);
        }
        else
        {
            animator.SetBool(isWalking, false);
        }

        elementAnimator.SetInteger(element, elementId);
    }


    protected override void CheckInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("Input.GetKeyDown(KeyCode.E");
            InteractableObject selectedObject = null;
            foreach(InteractableObject obj in interactableObjects)
            {
                if(selectedObject == null)
                {
                    selectedObject = obj;
                    continue;
                }
                if (Vector3.Distance(this.transform.position, obj.position) < Vector3.Distance(this.transform.position, selectedObject.position))
                    selectedObject = obj;
            }
            if (selectedObject != null)
            {
                selectedObject.Interaction();
            }
        }
    }
}

public abstract class Interactor : MonoBehaviour
{
    protected List<InteractableObject> interactableObjects = new List<InteractableObject>();

    public virtual void AddInteractableObject(InteractableObject interactable)
    {
        interactableObjects.Add(interactable);
    }

    public void TryToRemoveInteractableObject(InteractableObject interactable) // sponsored by good method naming
    {
        interactableObjects.Remove(interactable);
    }

    protected abstract void CheckInteraction();

    protected virtual void Update()
    {
        CheckInteraction();
    }
}