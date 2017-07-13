using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider;
    public Toggle fpsToggle;
    public LevelManager levelManager;

    // Use this for initialization
    void Start() {
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);

        fpsToggle.isOn = PlayerPrefsManager.GetDrawFPS();
        fpsToggle.onValueChanged.AddListener(OnDrawFPSChanged);
    }

    void OnVolumeChanged(float value) {
        AudioListener.volume = volumeSlider.value;
    }

    void OnDrawFPSChanged(bool value) {
        PlayerPrefsManager.SetDrawFPS(fpsToggle.isOn);
    }

    public void SaveAndExit() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDrawFPS(fpsToggle.isOn);
        levelManager.LoadPreviousLevel();
    }
}
