using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject levelCompletePanel;
    public GameObject endText;

    private void Start()
    {
        Time.timeScale = 1f;
        endText.SetActive(false);
        levelCompletePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(.5f);
        endText.SetActive(true);

        yield return new WaitForSeconds(3f);
        levelCompletePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
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
