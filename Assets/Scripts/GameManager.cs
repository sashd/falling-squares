using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameOverMenu menu;

    public static event Action<int> OnScoreChange;

    [Range(0,1)]
    [SerializeField] private float timeScaleStep = 0f;

    [Range(1, 2)]
    [SerializeField] private float timeScaleMax = 2f;

    private int score = 0;
    private bool isGameOver = false;

    public static bool GameOver
    {
        get
        {
            return instance.isGameOver;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public static void PlayerPickedFriendlyObject()
    {
        if (instance == null)
            return;

        if (instance.isGameOver)
            return;

        instance.score++;
        OnScoreChange?.Invoke(instance.score);

        if (Time.timeScale < instance.timeScaleMax)
        {
            Time.timeScale += instance.timeScaleStep;
        }
    }

    public static void PlayerPickedEnemyObject()
    {
        if (instance == null)
            return;

        instance.isGameOver = true;

        int currentRecord = PlayerPrefs.GetInt("Record", 0);
        if (currentRecord < instance.score)
        {
            currentRecord = instance.score;
            PlayerPrefs.SetInt("Record", currentRecord);
        }

        instance.menu.Show(instance.score, currentRecord);
    }

    public static void Restart()
    {
        instance.score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
