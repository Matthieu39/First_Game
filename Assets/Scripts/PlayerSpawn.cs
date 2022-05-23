using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public LoadAndSaveData LoadAndSaveData;
    private GameObject Player;
  void Awake()
  {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = transform.position;
  }
    private void Start()
    {
        // transform.position= GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
        // GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position = LoadAndSaveData.instance.lastCheck;
        // transform.position = LoadAndSaveData.instance.lastCheck;

        LoadAndSaveData.LoadData();
        transform.position = LoadAndSaveData.spawnPosition;

        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position ;
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = transform.position ;


    }
}
