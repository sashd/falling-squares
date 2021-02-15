using UnityEngine;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        GameManager.OnScoreChange += UpdateText;
    }

    private void OnDestroy()
    {
        GameManager.OnScoreChange -= UpdateText;
    }

    private void UpdateText(int value)
    {
        if (scoreText == null)
            return;

        scoreText.text = value.ToString();
    }
}
