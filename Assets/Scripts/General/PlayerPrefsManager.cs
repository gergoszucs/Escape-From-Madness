using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";

	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}

	public static float GetMasterVolume(){
        if (!PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) {
            PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, 100f);
        }

		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
}