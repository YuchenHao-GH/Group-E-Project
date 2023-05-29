using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject nextLevelPanel;
    public GameObject gameOverPanel;
    [SerializeField] private GameObject activePanel;
    static private UIManager instance;
    static public UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("There is not UIManager in the scene.");
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance != null)
        {
            // there is already another UI Manager, destroy self
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 0)
        {
            // we're on the menu scene, show the start panel
            startPanel.SetActive(true);
            activePanel = startPanel;
        }
    }

    public void LevelComplete()
    {
        Scene scene = SceneManager.GetActiveScene();
        int lastScene = SceneManager.sceneCountInBuildSettings - 1;
        Debug.Log($"build index = {scene.buildIndex}");
        Debug.Log($"last scene = {lastScene}");

        if (scene.buildIndex == lastScene)
        {
            //we're on the last scene, show the game over panel 
            gameOverPanel.SetActive(true);
            activePanel = gameOverPanel;
        }
        else
        {
            //show the next level panel 
            nextLevelPanel.SetActive(true) ;
            activePanel = nextLevelPanel;
        }
    }
    public void NextScene()
    {
        //hide the panel
        activePanel.SetActive(false);
        //load the next scene in build order
        Scene scene = SceneManager.GetActiveScene();
        int lastScene = SceneManager.sceneCountInBuildSettings - 1;
        
        int next;
        if ((scene.buildIndex == lastScene))
        {
            next = 0;
            // we're returning to the menu scene, show the start panel
            startPanel.SetActive(true);
            activePanel = startPanel;
        }
        else
        {
            next = scene.buildIndex + 1;
        }
        SceneManager.LoadScene(next);
    }
}
