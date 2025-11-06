using UnityEngine;
using UnityEngine.UI; // alleen nodig als je ook UI-tekst gebruikt

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3; // aantal levens
    public Text livesText; // sleep hier een UI Text in (optioneel)

    private void Start()
    {
        UpdateLivesUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int amount)
    {
        lives -= amount;
        Debug.Log("Player lives: " + lives);

        UpdateLivesUI();

        if (lives <= 0)
        {
            Debug.Log("Game Over!");
            // eventueel: Destroy(gameObject); of respawn
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
