using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseMenu;
    public GameObject pauseButton;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    private void Update()
    {

    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
