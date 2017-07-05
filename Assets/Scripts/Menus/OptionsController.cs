using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public LevelManager levelManager;

    // Use this for initialization
    void Start() {
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float value) {
        AudioListener.volume = volumeSlider.value;
    }

    public void SaveAndExit() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        levelManager.LoadPreviousLevel();
    }
}
