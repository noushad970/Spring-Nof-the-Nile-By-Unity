using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{

    [Header("File Storage Confiq")]
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    [System.Obsolete]
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindALlDataPersistanceObjects();
        loadGame();

    }
    //saving and loading data while choosing new character or new map
    private void Update()
    {
        /*  if (GameOver.GameoverSave)
          {

              saveGame();
              loadGame();
              GameOver.GameoverSave = false;
          }
          */
        if (TriggerCollisionDetection.GameOver)
        {
            saveGame();
            loadGame();
            TriggerCollisionDetection.GameOver = false;
        }
        if(MainMeneManager.itemIsBuyed)
        {
            saveGame();
            loadGame();
            MainMeneManager.itemIsBuyed = false;
        }

    }
    public static DataPersistanceManager instance
    {
        get;
        private set;
    }
    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogError("Found more than one data persistance in this scene");
        }
        instance = this;

    }

    public void newGame()
    {
        this.gameData = new GameData();
    }
    //save the game data
    public void saveGame()
    {
        foreach (IDataPersistence persistence in dataPersistenceObjects)
        {
            persistence.saveData(ref gameData);
        }
        Debug.Log("save Total coins: " + gameData.coin);
        dataHandler.Save(gameData);
    }
    //load the game data
    public void loadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No game data was found,initializing data to new Game Data");
            newGame();
        }
        foreach (IDataPersistence persistence in dataPersistenceObjects)
        {
            persistence.loadData(gameData);
        }
        Debug.Log("Load Total coins: " + gameData.coin);

    }
    //save the game data while exiting the app
    private void OnApplicationQuit()
    {
        saveGame();
    }

    [System.Obsolete]
    private List<IDataPersistence> FindALlDataPersistanceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistencesObjects);
    }
}
