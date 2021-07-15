using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float ClimbingSpeed;
    public PlayerController controller;             //using our CharakterScript
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
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("velocityX", Mathf.Abs(horizontalMove));


        // L�sst unserern Charakter springen
        if (Input.GetButtonDown("Jump"))
        {
            if (!jumping)
            {
                SoundManager.PlaySound("jump");
            }
            jump = true;
            jumping = true;
            animator.SetBool("Jump", true);

        }

    }

    // Funktion die der Variablen "jump" ein false gibt, wenn der Charakter landet
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
