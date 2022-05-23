using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScene : MonoBehaviour
{
  public string level;
  private Animator fadeSystem;

  private void Awake()
  {
    fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
  }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
          StartCoroutine(loadNextScene());

        }
    }


    public IEnumerator loadNextScene(){
      // Ajout pour les sauvegardes
      LoadAndSaveData.instance.SaveData();
      // Ajout pour les sauvegardes
      fadeSystem.SetTrigger("FadeIn");
      yield return new WaitForSeconds(1f);
      SceneManager.LoadScene(level);

}
}
