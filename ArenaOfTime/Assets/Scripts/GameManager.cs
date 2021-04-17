using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LevelLoader LevelLoader;
    public string CurrentLevel;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance.GetComponent<GameManager>();
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager.Start called");
        SceneManager.activeSceneChanged += onActiveSceneChanged;
        SceneManager.sceneLoaded += onSceneLoaded;
        SceneManager.sceneUnloaded += onSceneUnloaded;
        CurrentLevel = "MenuScene";
    }

    private void onSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log($"GameManager.onSceneLaoded: {arg0.name} {arg1}");
        LevelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    private void onSceneUnloaded(Scene arg0)
    {
        Debug.Log($"GameManager.onSceneUnloaded: {arg0.name}");
      
    }

    private void onActiveSceneChanged(Scene arg0, Scene arg1)
    {
        Debug.Log($"GameManager.onActiveSceneChanged: {arg0.name} {arg1.name}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
