using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePausePanel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PausePanel;
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
