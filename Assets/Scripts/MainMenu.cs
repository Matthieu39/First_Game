using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  public string levelToLoad;
  public GameObject settingsWindow;

    public void StartGame()
    {
      SceneManager.LoadScene(levelToLoad);
      PlayerPrefs.DeleteAll();
    }

    public void Settings()
    {
      settingsWindow.SetActive(true);
    }

    public void CloseSettings()
    {
      settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
      Application.Quit();
    }
}
