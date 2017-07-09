using UnityEngine;

public class Chainsaw : MonoBehaviour {

    AudioSource chainsawAudio;

	void Start () {
        chainsawAudio = GetComponent<AudioSource>();
	}

    public void PlayChainsawAudioAfter(float delay) {
        Invoke("PlayAudio", delay);
    }

    void PlayAudio() {
        chainsawAudio.Play();
    }

    public void StopAudio() {
        chainsawAudio.Stop();
    }
}