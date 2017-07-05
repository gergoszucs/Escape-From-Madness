using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    static LevelManager instance;
    AudioSource backgroundMusic;

    void Start() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            instance = this;

            AudioListener.volume = PlayerPrefsManager.GetMasterVolume() == 0 ? 100f : PlayerPrefsManager.GetMasterVolume();
            backgroundMusic = GetComponent<AudioSource>();
        }

        if(SceneManager.GetActiveScene().buildIndex == 0) {
            Invoke("LoadNextLevel", 4.0f);
        }
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadPreviousLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadLevel(int levelBuildIndex) {
        SceneManager.LoadScene(levelBuildIndex);
    }

    public void ExitGame() {
        Application.Quit();
    }

    private void OnLevelWasLoaded(int level) {
        if(level == 1 && !backgroundMusic.isPlaying) {
            backgroundMusic.Play();
        }

        if(level != 1 && level != 2) {
            backgroundMusic.Stop();
        }
    }
}