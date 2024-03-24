using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health;
    public float maxHealth=5;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    //public Slider hpCounter;
    public Image hpCounter;
    public GameObject diedMenu;
    public AudioSource DeathSound, Get_Hitted;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = maxHealth;
        //hpCounter.maxValue = maxHealth;
        //hpCounter.value = maxHealth;

    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);

        // Get input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);

        // Animation
        spriteRenderer.flipX = (difference.x < 0);
        if (isGrounded)
        {
            // Walking animation
            animator.SetBool("IsWalking", moveDirection.magnitude > 0);

            // Flip the sprite if moving left
            animator.SetBool("IsFlying", false);
        }
        else
        {
            // Flying animation
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsFlying", true);
        }

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }

        if (health <= 0)
        {
            diedMenu.SetActive(true);
            DeathSound.Play();
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Get_Hitted.Play();
        //hpCounter.value = health;
        hpCounter.fillAmount =(health / maxHealth);
    }
}
