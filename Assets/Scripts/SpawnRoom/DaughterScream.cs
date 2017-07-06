using UnityEngine;

public class DaughterScream : MonoBehaviour {

    AudioSource screamSound;

	void Start () {
        screamSound = GetComponent<AudioSource>();
	}

	public void PlayScreams() {
        screamSound.Play();
    }

    public void StopScreams() {
        screamSound.Stop();
    }
}