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

   
 
    [SerializeField] private GameObject activePanel;
    static private UIManager instance;
    static public UIManager Instance;

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
     
        Time.timeScale = 0f;
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
        
    }

    public void LevelComplete()
    {
        startPanel.SetActive(false);

    }
    public void NextScene()
    {
        //hide the panel
        startPanel.SetActive(false);
        Time.timeScale = 1f;
        //load the next scene in build order

    }

    public void PlayerDied()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        reloadPanel.SetActive(true);
        activePanel = reloadPanel;
    }

    public void PlayerReload()
    {
        activePanel.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 1f;
        ResetGameTime(); 
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResetGameTime()
    {
        isGameOver = false;
        gameTime = 0f;
        UpdateTimeUI();
    }
}
