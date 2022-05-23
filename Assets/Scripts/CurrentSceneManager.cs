using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;

    public static CurrentSceneManager instance;

    private void Awake(){

      if(instance != null){
        Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scene");
        return ;
        // PERMET DE S SASSURER QU IL N Y A QU UN SEUL INVENTAIRE
        //Singleton
      }
      instance = this;
}
}
