using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public Transform healthBar;
    public GameObject gameOverScreen;


    void Start()
    {
        health = maxHealth;
        UpdateHealthBar();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        
        Debug.Log("Player Health: " + health);

        UpdateHealthBar();

        if (health <= 0)
        {
            GameOver();
            Debug.Log("Player Dead");
        }
    }

    void UpdateHealthBar()
    {
        float healthPercent = health / maxHealth;

        healthBar.localScale = new Vector3(healthPercent, 1f ,1f);
    }

    void GameOver()
    {
        Debug.Log("Player Dead");

        gameOverScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f; // freezes the game
    }
}