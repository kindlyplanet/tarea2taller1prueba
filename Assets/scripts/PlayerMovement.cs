using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad del personaje
    public float jumpForce = 10f; // Fuerza del salto
    public LayerMask groundLayer; // Capa que representa el suelo

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        FlipSprite();
    }

    void FixedUpdate()
    {
        MoveCharacter(horizontalMovement * Time.fixedDeltaTime);
    }

    void MoveCharacter(float movement)
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void FlipSprite()
    {
        if (horizontalMovement > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalMovement < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
