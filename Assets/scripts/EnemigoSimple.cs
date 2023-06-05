using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSimple : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;
    private bool isDead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isDead)
        {
            Move();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí puedes implementar el comportamiento de daño al jugador
            // Por ejemplo, reducir vidas o reiniciar el nivel
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Si el enemigo choca con un obstáculo, cambia la dirección de movimiento
            moveSpeed *= -1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("DeathZone"))
        {
            // Aquí puedes implementar el comportamiento de muerte del enemigo
            // Por ejemplo, reproducir una animación de muerte y destruir el objeto
            isDead = true;
            Destroy(gameObject);
        }
    }
}
