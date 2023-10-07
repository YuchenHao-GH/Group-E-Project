using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeControlDown : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Button addButton = GetComponent<Button>();
        addButton.onClick.AddListener(IncreaseVolume);
    }

    private void IncreaseVolume()
    {
        AudioListener.volume -= 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
