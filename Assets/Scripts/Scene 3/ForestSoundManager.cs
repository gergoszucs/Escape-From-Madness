using UnityEngine;

public class ForestSoundManager : MonoBehaviour {

    public AudioClip playerDeath;

    AudioSource audioPlayer;

	void Start () {
        audioPlayer = GetComponent<AudioSource>();
	}

    public void PlayAlanDeathSound() {
        audioPlayer.loop = false;
        audioPlayer.volume = 0.8f;
        audioPlayer.clip = playerDeath;
        audioPlayer.Play();
    }
}