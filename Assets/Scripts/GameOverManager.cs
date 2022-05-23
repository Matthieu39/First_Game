using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
  public GameObject gameOverUI;
  public Poison poison;
  public static GameOverManager instance;

  private void Awake(){

    if(instance != null){
      Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scene");
      return ;
      // PERMET DE S SASSURER QU IL N Y A QU UN SEUL INVENTAIRE
      //Singleton
    }
    instance = this;
  }

public void Update(){
  poison = GameObject.FindGameObjectWithTag("Poison").GetComponent<Poison>();
}

  public void OnPlayerDeath()
  {
    poison.isPoisoned = false;
    if(CurrentSceneManager.instance.isPlayerPresentByDefault)
    {
      DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
    }

    gameOverUI.SetActive(true);
  }

  public void RetryButton()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    PlayerHealth.instance.Respawn();
    gameOverUI.SetActive(false);
  }

  public void MenuButton()
  {
    DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
    SceneManager.LoadScene("MainMenu");
  }

  public void QuitButton()
  {
    Application.Quit();
  }







}
