using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {
    [SerializeField] private Text scoreText, multiplierText;

    private float score;
    public float Multiplier { get; set; } = 1;

    private void Update() {
        score += 10 * Multiplier * Time.deltaTime;
        scoreText.text = $"{score:F0}";
        multiplierText.text = $"x{Multiplier}";
    }
}