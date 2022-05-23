using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{

  public GameObject[] objects;

  public static DontDestroyOnLoadScene instance;

  private void Awake(){

    if(instance != null){
      Debug.LogWarning("Il y a plus d'une instance de DontDestroyOnLoadScene dans la scene");
      return ;
      // PERMET DE S SASSURER QU IL N Y A QU UN SEUL INVENTAIRE
      //Singleton
    }
    instance = this;

    foreach (var element in objects)
    {
      DontDestroyOnLoad(element);
    }
  }


  public void RemoveFromDontDestroyOnLoad()
    {
      foreach (var element in objects)
      {
          SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
      }
    }
}