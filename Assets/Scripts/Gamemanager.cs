using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int score = 0;
    public TextMeshProUGUI scoreText;

    public static void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
       // scoreText.text = "Score: " + score;
    }
}
