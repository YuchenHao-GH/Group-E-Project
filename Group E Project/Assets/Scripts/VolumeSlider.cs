using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;
    private float Volume;

    private void Awake()
    {
        Volume = PlayerPrefs.GetFloat("Volume", 1);
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        ChangeVolume(Volume);


    }
    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void ChangeVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
        PlayerPrefs.SetFloat("Volume", newVolume);
    }
}