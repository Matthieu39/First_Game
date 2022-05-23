using UnityEngine;

public class CheckPoint : MonoBehaviour
  {
    public Transform playerSpawn;
    private LoadAndSaveData LoadAndSaveData;

    public void Awake()
    {
        playerSpawn =  GameObject.FindGameObjectWithTag("PlayerSpawn").GetComponent<Transform>(); 
        LoadAndSaveData = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LoadAndSaveData>();
    }

    public void OnTriggerEnter2D(Collider2D collision){
      if(collision.CompareTag("Player")){

        playerSpawn.position = transform.position;

        // Ajout pour les sauvegardes
        LoadAndSaveData.instance.SaveData();
      }
    }


  }
