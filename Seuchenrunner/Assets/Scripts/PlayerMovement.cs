using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls player movement
public class PlayerMovement : MonoBehaviour
{
    //variables
    public float ClimbingSpeed;
    public PlayerController controller;             //using player controller script
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool jumping = false;
    private Rigidbody2D rb;
    private bool Climbing;
    private float inputHorizontal;
    private float inputVertical;
    private float Gravity;
    public LayerMask whatIsLadder;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Gravity = rb.gravityScale;
    }



    // Update is called once per frame
    //update movement
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("velocityX", Mathf.Abs(horizontalMove));


        //controls jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (!jumping)
            {
                SoundManager.PlaySound("jump");
                animator.SetBool("grounded", false);
                animator.SetBool("Jump", true);
            }
            jump = true;
            jumping = true;
            

        }

    }

    //set jumping variable to false when landing
    public void OnLanding()
    {
        Debug.Log("Landed");
        jumping = false;
        animator.SetBool("Jump", false);
        animator.SetBool("grounded", true);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

}
