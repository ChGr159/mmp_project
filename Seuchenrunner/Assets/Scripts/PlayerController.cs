using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//controls player behaviour
public class PlayerController : MonoBehaviour
{
    //variables shown in Inspector
    [SerializeField] private float m_JumpForce = 400f;                          //amount of force added when the player jumps
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  //how much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         //whether or not a player can steer while jumping
    [SerializeField] private LayerMask m_WhatIsGround;                          //a mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           //a position marking where to check if the player is grounded
    public GameObject impactEffect;

    const float k_GroundedRadius = .2f;                                        //radius of the overlap circle to determine if grounded
    private bool m_Grounded;                                                   //whether or not the player is grounded
    const float k_CeilingRadius = .2f;                                         //radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;                                         //for determining which way the player is currently facing
    private Vector3 m_Velocity = Vector3.zero;
    private static int collCounter = 0;                                        //counter for score, initialized with 0
    public Text scoreText;                                                     //score text

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

    }

    //ground check of player
    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        //player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded && m_Rigidbody2D.velocity.y < 0)
                    OnLandEvent.Invoke();
            }
        }


    }

    //movement of player
    public void Move(float move, bool jump)
    {

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {


            //move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            //smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            //if input is moving the player right while the player is facing left => flip
            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            //other way round
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        //jumping command
        if (m_Grounded && jump)
        {

            //add vertical force to player
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }

    }


    private void Flip()
    {
        //switch the way the player is labelled as facing
        m_FacingRight = !m_FacingRight;

        //multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //collision with enemy - behaviour
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SoundManager.PlaySound("hit");               
            GameObject player = GameObject.FindWithTag("Player");   //searches for player
            GameMaster.KillPlayer(player);                          //calls KillPlayer method in GameMaster which kills and respawns player
        }
    }

    //collision with other objects
    private void OnTriggerEnter2D(Collider2D other)         
    {
        //increment score when the player collides with a collectible
        if (other.tag == "Collectible")
        {
            collCounter++;
            SoundManager.PlaySound("coins");                
            Destroy(other.gameObject);

            //gives additional life point for 5 collectibles
            if (collCounter == 5)
            {
                GameMaster.GiveLife();
                collCounter = 0;
            }

            //updates score text
            scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            scoreText.text = "Score: " + collCounter.ToString();
            Debug.Log("Score: " + collCounter);



        }

        //calls KillPlayer method when player collides with bullet; destroys bullet (impactEffect)
        else if (other.tag == "Bullet")
        {
            GameMaster.KillPlayer(other.gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        else
        {
            return;
        }
    }

}