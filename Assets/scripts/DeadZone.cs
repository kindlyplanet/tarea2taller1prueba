using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if(playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }

            player.transform.position = respawnpoint.transform.position;
        }
    }
}
