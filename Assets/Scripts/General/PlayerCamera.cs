using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public AudioClip annaScream, deathSound, nononoSound;

    AudioSource playerVoice;

	void Start () {
        playerVoice = GetComponent<AudioSource>();
	}
	
    public void ScreamForAnna() {
        playerVoice.clip = annaScream;
        playerVoice.loop = false;
        playerVoice.Play();
    }

    public void PlayDyingSound() {
        playerVoice.clip = deathSound;
        playerVoice.loop = false;
        playerVoice.Play();
    }

    public void PlayNoNoNoSound() {
        playerVoice.clip = nononoSound;
        playerVoice.loop = false;
        playerVoice.Play();
    }
}