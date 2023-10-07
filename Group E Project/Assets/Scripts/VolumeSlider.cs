using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
    }
}