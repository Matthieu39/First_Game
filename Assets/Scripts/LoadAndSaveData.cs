using System.Data;
using System.IO;
using UnityEditor;
// using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAndSaveData : MonoBehaviour
{
    public CheckPoint checkPoint;


    public static LoadAndSaveData instance;

    public Vector3 spawnPosition;
    public float spawnPositionX;
    public float spawnPositionY;
    public float spawnPositionZ;
    private string saveSeparator = "%VALUE%";

    public Vector3 startSpawnPosition;
    public Transform spawn;


    private void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("PlayerSpawn").GetComponent<Transform>();
        checkPoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckPoint>();

        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scene");
            return;
            // PERMET DE S SASSURER QU IL N Y A QU UN SEUL SAUVEGARDE
            //Singleton
        }
        instance = this;


    }

    void Start()
    {
        int currentHealth = PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);

        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateText();

        startSpawnPosition = spawn.position;

    }

    private void Update()
    {
        if (spawn == null)
        {
            spawn = GameObject.FindGameObjectWithTag("PlayerSpawn").GetComponent<Transform>();
        }

        if (checkPoint == null)
        {
            checkPoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckPoint>();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (SceneManager.GetActiveScene().name == "Tutoriel")
            {
                File.Delete(Application.dataPath + "/data0.txt");
                File.Create(Application.dataPath + "/data0.txt");
            }
            else if (SceneManager.GetActiveScene().name == "Niveau1")
            {
                File.Delete(Application.dataPath + "/data1.txt");
                File.Create(Application.dataPath + "/data1.txt");
            }
            else if (SceneManager.GetActiveScene().name == "Niveau2")
            {
                File.Delete(Application.dataPath + "/data2.txt");
                File.Create(Application.dataPath + "/data2.txt");
            }
            else if (SceneManager.GetActiveScene().name == "Niveau3")
            {
                File.Delete(Application.dataPath + "/data3.txt");
                File.Create(Application.dataPath + "/data3.txt");
            }
        }
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("playerHealth", PlayerHealth.instance.currentHealth);

        PlayerPrefs.SetInt("coinsCount", Inventory.instance.coinsCount);

        spawnPosition = checkPoint.playerSpawn.position;
        spawnPositionX = spawnPosition.x;
        spawnPositionY = spawnPosition.y;
        spawnPositionZ = spawnPosition.z;


        string[] saveContent = new string[]
        {
        spawnPositionX.ToString(),
        spawnPositionY.ToString(),
        spawnPositionZ.ToString(),
        };

        string saveString = string.Join(saveSeparator, saveContent);

        if (SceneManager.GetActiveScene().name == "Tutoriel")
        {
            File.WriteAllText(Application.dataPath + "/data0.txt", saveString);
        }
        else if (SceneManager.GetActiveScene().name == "Niveau1")
        {
            File.WriteAllText(Application.dataPath + "/data1.txt", saveString);
        }
        else if (SceneManager.GetActiveScene().name == "Niveau2")
        {
            File.WriteAllText(Application.dataPath + "/data2.txt", saveString);
        }
        else if (SceneManager.GetActiveScene().name == "Niveau3")
        {
            File.WriteAllText(Application.dataPath + "/data3.txt", saveString);
        }
    }

    public void LoadData()
    {
        string savedString = " ";

        if (SceneManager.GetActiveScene().name == "Tutoriel")
        {
            savedString = File.ReadAllText(Application.dataPath + "/data0.txt");
        }
        else if (SceneManager.GetActiveScene().name == "Niveau1")
        {
            savedString = File.ReadAllText(Application.dataPath + "/data1.txt");
        }
        else if (SceneManager.GetActiveScene().name == "Niveau2")
        {
            savedString = File.ReadAllText(Application.dataPath + "/data2.txt");
        }
        else if (SceneManager.GetActiveScene().name == "Niveau3")
        {
            savedString = File.ReadAllText(Application.dataPath + "/data3.txt");
        }


        string[] savedContent = savedString.Split(new[] { saveSeparator }, System.StringSplitOptions.None);

        spawnPositionX = float.Parse(savedContent[0]);
        spawnPositionY = float.Parse(savedContent[1]);
        spawnPositionZ = float.Parse(savedContent[2]);
        spawnPosition = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);


    }


}
