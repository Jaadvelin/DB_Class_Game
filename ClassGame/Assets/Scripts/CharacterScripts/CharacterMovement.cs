using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxSpeed = 6.0f, moveDirection;
    public bool facingRight = true;
    new Rigidbody rigidbody;

    public float jumpSpeed = 600.0f;
    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask whatIsGround;

    public float swordSpeed = 600.0f;
    public Transform swordSpawn;
    public Rigidbody swordPrefab;
    private ParticleSystem particleSystem;

    private AudioSource audio;
    public AudioClip jumpAudio;
    public AudioClip attackAudio;

    private PlayerHealth playerHealth;

    Rigidbody clone;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent <Animator> ();
        audio = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.enableEmission = false;

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        if (grounded && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
            rigidbody.AddForce(new Vector2(0, jumpSpeed));
            audio.PlayOneShot(jumpAudio);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        //Jumpbutton();
        //Attackbutton();

    }

    void Awake()
    {
        groundCheck = GameObject.Find("GroundCheck").transform;
        swordSpawn = GameObject.Find("swordSpawn").transform;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        rigidbody.velocity = new Vector2(moveDirection * maxSpeed, rigidbody.velocity.y);

        if (moveDirection > 0.0f && !facingRight)
        {
            Flip();
        } else if(moveDirection < 0.0f && facingRight)
        {
            Flip();
        }
        anim.SetFloat("Speed", Mathf.Abs(moveDirection));
        


    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180.0f, Space.World);
    }

    void Attack()
    {
        anim.SetTrigger("attacking");
        audio.PlayOneShot(attackAudio);
    }

    public void CallFireProjectile()
    {
        clone = Instantiate(swordPrefab, swordSpawn.position, swordSpawn.rotation) as Rigidbody;
        clone.AddForce(swordSpawn.transform.right * swordSpeed);
    }

    public void PowerUpJump()
    {
        jumpSpeed = 1200.0f;
        new WaitForSeconds(3f);
        jumpSpeed = 600.0f;
    }

    public void Jumping()
    {
        
    }

    public void Attacking()
    {
       
    }

}
