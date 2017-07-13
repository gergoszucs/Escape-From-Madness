using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour {

    public GameObject pauseBackground, pauseMenu, pauseOptions, volumeObject, playerMessages;
    public GameObject resumeButton, optionsButton, menuButton, exitButton, backButton, fpsObject;
    public Transform player;

    Color originalTextColor;
    Slider volumeSlider;
    Toggle drawFPSToggle;

    void Start() {
        originalTextColor = resumeButton.GetComponentInChildren<Text>().color;
        volumeSlider = volumeObject.GetComponent<Slider>();
        drawFPSToggle = fpsObject.GetComponent<Toggle>();

        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        drawFPSToggle.onValueChanged.AddListener(OnDrawFPSChanged);
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseBackground.activeInHierarchy || pauseOptions.activeInHierarchy) {
                UnPause();
            } else {
                Pause();
            }
        }
    }       

    void OnVolumeChanged(float value) {
        AudioListener.volume = volumeSlider.value;
    }

    void OnDrawFPSChanged(bool value) {
        PlayerPrefsManager.SetDrawFPS(drawFPSToggle.isOn);
    }

    public void Pause() {
        pauseBackground.SetActive(true);
        pauseMenu.SetActive(true);
        playerMessages.SetActive(false);

        Time.timeScale = 0f;
        player.GetComponent<FirstPersonController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ResetButtonColors();
    }

    public void UnPause() {
        pauseBackground.SetActive(false);
        pauseMenu.SetActive(false);
        pauseOptions.SetActive(false);
        playerMessages.SetActive(true);

        Time.timeScale = 1f;
        player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void GoToOptions() {
        pauseOptions.SetActive(true);
        pauseMenu.SetActive(false);

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        drawFPSToggle.isOn = PlayerPrefsManager.GetDrawFPS();
        ResetButtonColors();
    }

    public void BackFromOptions() {
        pauseOptions.SetActive(false);
        pauseMenu.SetActive(true);

        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDrawFPS(drawFPSToggle.isOn);
        ResetButtonColors();
    }

    // Implementing the pause button by disabling panels causes the buttons to stay in focused/highlighted state 
    // in some cases, so they retain their black text color on a black background
    private void ResetButtonColors() {
        backButton.GetComponentInChildren<Text>().color = originalTextColor;
        optionsButton.GetComponentInChildren<Text>().color = originalTextColor;
        resumeButton.GetComponentInChildren<Text>().color = originalTextColor;
        menuButton.GetComponentInChildren<Text>().color = originalTextColor;
        exitButton.GetComponentInChildren<Text>().color = originalTextColor;
    }
}