using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] checkpoints;
    public bool levelcompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        checkpoints = Object.FindObjectsOfType<Checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckpointsCompleted()
    {
        if (checkpoints.All(go => go.Completed == true))
        {
            levelcompleted = true;
            SoundManager.PlayLevelCompleteSoundClip();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
