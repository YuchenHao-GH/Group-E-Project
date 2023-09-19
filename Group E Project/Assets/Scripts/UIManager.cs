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
    public GameObject reloadPanel;

    private TimeRecord timeRecord;
 
    [SerializeField] private GameObject activePanel;
    static private UIManager instance;
    static public UIManager Instance;

    public Text timeText;
    private float gameTime = 0f;
    private bool isGameOver = false;

    //{
        //get
        //{
            //if (instance == null)
            //{
                //Debug.LogError("There is not UIManager in the scene.");
            //}
            //return instance;
        //}
    //}

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
        UpdateTimeUI();
    }

    void Update()
    {
        if (!isGameOver)
        {
            gameTime += Time.deltaTime;
            UpdateTimeUI();
        }
    }

    void UpdateTimeUI()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60f);
        int seconds = Mathf.FloorToInt(gameTime % 60f);
        timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
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

    public void PlayerDied()
    {
        isGameOver = true;
        reloadPanel.SetActive(true);
        activePanel = reloadPanel;
    }

    public void PlayerReload()
    {
        activePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetGameTime(); 
    }

    private void ResetGameTime()
    {
        isGameOver = false;
        gameTime = 0f;
        UpdateTimeUI();
    }
}
