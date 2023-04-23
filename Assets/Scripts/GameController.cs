using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public AudioClip pauseButtonSound;
    public AudioClip resumeButtonSound;
    public AudioClip levelcompleteSound;
    //public AudioClip gameoverSound;
    public GameObject levelCompletePanel;
    public GameObject endText;

    public AudioSource mainSound;
    public AudioSource gameoverSound;

    private void Start()
    {
        mainSound.Play();
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
        AudioSource.PlayClipAtPoint(levelcompleteSound, Camera.main.transform.position, 0.5f);
        levelCompletePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        mainSound.Stop();
    }

    public void GameOver()
    {
        mainSound.Stop();
        //AudioSource.PlayClipAtPoint(gameoverSound, Camera.main.transform.position, 1f);
        gameoverSound.Play();
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseGame()
    {
        mainSound.Pause();
        AudioSource.PlayClipAtPoint(pauseButtonSound, Camera.main.transform.position, 0.5f);
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        AudioSource.PlayClipAtPoint(resumeButtonSound, Camera.main.transform.position, 0.5f);
        mainSound.Play();
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);        
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
