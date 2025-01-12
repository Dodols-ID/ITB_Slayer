using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // max HP player (placeholder)
    public int currentHealth;  // Variable HP in game
    public Slider healthBar;   // referens health bar
    private bool isDead = false; // Kondisi player hidup/mati
    // Inisiasi game
    private void Start()
    {
        currentHealth = maxHealth; // Inisiasi HP awal game pakai max HP
        healthBar.maxValue = maxHealth; // Panjang si healthbarnya sepanjang max HP
        healthBar.value = currentHealth; // Panjang in game yang ikut berubah sesuai current health
    }
    // Kalau kena musuh, HP berkurang
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isDead)
        {
            TakeDamage(10); // Besar damage dari enemy
        }
    }
    // Kalau kalah, layar last story diinisiasi. kalau nggak sempet, langsung ke gameovernya "scn_defeatstory1", scene yang "scn_defeatstory" ada bug
    void TriggerRestart()
    {
         SceneManager.LoadScene("scn_defeatstory1");
    }
    // Damage buat player
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
