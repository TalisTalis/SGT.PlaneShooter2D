using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public AudioClip pauseButtonSound;
    int currentIndex;

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void Reload()
    {
        Time.timeScale = 1;
        AudioSource.PlayClipAtPoint(pauseButtonSound, Camera.main.transform.position, 0.5f);
        SceneManager.LoadScene(currentIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentIndex + 1);
    }
}
