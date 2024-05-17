using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider healthBar;
    public int maxHealth = 100;
    private int currentHealth;
    public GameManager gameManager;
    public float attackInterval = 3f;
    public int attackDamage = 15;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        gameManager.UpdateEnemyHealthUI(currentHealth); // Actualizar la UI del enemigo al iniciar
        InvokeRepeating("AttackPlayer", attackInterval, attackInterval);
    }

    void Update()
    {
        // Aqu� puedes a�adir l�gica adicional si es necesario.
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        gameManager.UpdateEnemyHealthUI(currentHealth); // Actualizar la UI del enemigo al recibir da�o

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            gameManager.EnemyDefeated();
        }
    }

    void AttackPlayer()
    {
        gameManager.PlayerTakeDamage(attackDamage);
    }

    void OnMouseDown()
    {
        TakeDamage(10); // Puedes ajustar el valor de da�o aqu�.
    }
}
