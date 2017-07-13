using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
    const string DRAW_FPS_KEY = "draw_fps";

    public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}

	public static float GetMasterVolume(){
        if (!PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) {
            PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, 90f);
        }

		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

    public static void SetDrawFPS(bool shouldDraw) {
        PlayerPrefs.SetInt(DRAW_FPS_KEY, shouldDraw ? 0 : 1);
    }

    public static bool GetDrawFPS() {
        return PlayerPrefs.GetInt(DRAW_FPS_KEY) == 0;
    }
}