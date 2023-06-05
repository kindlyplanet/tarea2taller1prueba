using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float invincibilityDuration = 2f;
    public float blinkInterval = 0.2f;
    public HealthBar healthBar;
    public GameObject gameOverMenu;

    private int currentHealth;
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthBar.SetMaxHealth(maxHealth);
        gameOverMenu.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                StartInvincibility();
            }
        }
    }

    private void Die()
    {
        // Aquí puedes implementar el comportamiento de muerte del personaje
        // Por ejemplo, reproducir una animación de muerte y reiniciar el nivel
        spriteRenderer.enabled = false;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f; // Pausar el juego
    }

    private void StartInvincibility()
    {
        isInvincible = true;
        StartCoroutine(BlinkRoutine());

        // Restablecer la invencibilidad después de un tiempo
        Invoke(nameof(EndInvincibility), invincibilityDuration);
    }

    private void EndInvincibility()
    {
        isInvincible = false;
        spriteRenderer.enabled = true;
    }

    private IEnumerator BlinkRoutine()
    {
        while (isInvincible)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }

        spriteRenderer.enabled = true;
    }
}

