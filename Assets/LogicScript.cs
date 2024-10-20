using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    public string sceneName;

    [ContextMenu("Increase Score")]
    public void AddScore(int pointValue)
    {
        score += pointValue;
        scoreText.text = score.ToString();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(sceneName);
    }
}
