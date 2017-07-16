using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    static LevelManager instance;
    AudioSource backgroundMusic;
    static int inventoryAmmo, magazineAmmo;

    void Start() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            instance = this;

            AudioListener.volume = PlayerPrefsManager.GetMasterVolume();
            backgroundMusic = GetComponent<AudioSource>();

            inventoryAmmo = 60;
            magazineAmmo = 0;
        }

        if (!PlayerPrefs.HasKey("master_volume") || PlayerPrefsManager.GetMasterVolume() > 1f) {
            AudioListener.volume = 1f;
            PlayerPrefs.SetFloat("master_volume", 1);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) {
            Invoke("LoadNextLevel", 4.0f);
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

    public static void SetInventoryAmmo(int ammo) {
        inventoryAmmo = ammo;
    }

    public static int GetInventoryAmmo() {
        return inventoryAmmo;
    }

    public static void SetMagazineAmmo(int ammo) {
        magazineAmmo = ammo;
    }

    public static int GetMagazineAmmo() {
        return magazineAmmo;
    }
}