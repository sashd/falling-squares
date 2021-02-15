using UnityEngine;
using TMPro;


public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private float scaleTime = 0.2f;

    [SerializeField] private GameObject panel;

    [SerializeField] private TextMeshProUGUI currentScore;

    [SerializeField] private TextMeshProUGUI recordScore;

    private void Start()
    {
        panel.transform.localScale = new Vector3(0, 0, 1);
    }

    public void Restart()
    {
        LeanTween.scale(panel, new Vector3(0, 0, 1), scaleTime).setOnComplete(() => GameManager.Restart());
    }

    public void Show(int score, int record)
    {
        LeanTween.scale(panel, new Vector3(1, 1, 1), scaleTime);
        currentScore.text = score.ToString();
        recordScore.text = record.ToString();
    }


}
