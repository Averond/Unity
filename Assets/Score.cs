using UnityEngine;
using TMPro;  // Zorg dat TMP namespace erbij staat

public class ScoreManager : MonoBehaviour
{
    public int score = 0;          // Je huidige score
  //  public TMP_Text scoreText;     // Sleep hier je TMP Text in de Inspector

    void Start()
    {
        //UpdateScoreText();         // Zorg dat score bij start correct wordt weergegeven
    }

    // Roep deze functie aan wanneer je score wilt verhogen
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);  // Score in console
        UpdateScoreText();             // Score in UI updaten
    }

    // Functie om de UI tekst bij te werken
    void UpdateScoreText()
    {
       // scoreText.text = "Score: " + score;
        GetComponent<TextMeshProUGUI>().text = "Score: " + score; // Zorg dat TMP component ook wordt bijgewerkt
    }
}
