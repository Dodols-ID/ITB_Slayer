using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health
    public int currentHealth;  // Current health
    public Slider healthBar;   // Reference to the health bar UI
    private bool isDead = false; // Prevent multiple triggers

    private void Start()
    {
        currentHealth = maxHealth; // Initialize health
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isDead)
        {
            TakeDamage(10); // Example damage value
        }
    }

    void TriggerRestart()
    {
        // Show the restart screen
         SceneManager.LoadScene("scn_defeatstory1");
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage, current health: " + currentHealth);

        // Update health bar UI
        healthBar.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            TriggerRestart();
        }
    }

}
