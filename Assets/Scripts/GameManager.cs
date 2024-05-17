using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider playerHealthBar;
    public int playerMaxHealth = 100;
    private int playerCurrentHealth;

    public Text playerHealthText;
    public Text enemyHealthText;  // A�adimos esta referencia para mostrar la salud del enemigo

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        playerHealthBar.maxValue = playerMaxHealth;
        playerHealthBar.value = playerCurrentHealth;
        UpdatePlayerHealthUI();
    }

    public void PlayerTakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        playerHealthBar.value = playerCurrentHealth;
        UpdatePlayerHealthUI();

        if (playerCurrentHealth <= 0)
        {
            // L�gica de perder el juego
            Debug.Log("Player has been defeated!");
        }
    }

    public void EnemyDefeated()
    {
        // L�gica de ganar el juego
        Debug.Log("Enemy has been defeated!");
    }

    private void UpdatePlayerHealthUI()
    {
        playerHealthText.text = "Player Health: " + playerCurrentHealth;
    }

    public void UpdateEnemyHealthUI(int currentHealth)
    {
        enemyHealthText.text = "Enemy Health: " + currentHealth;
    }
}
