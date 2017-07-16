using UnityEngine;

public class FlashlightOnOff : MonoBehaviour {

    public AudioClip flashLightOn, flashLightOff;

    AudioSource audioPlayer;
    Light lampLight;
    bool isWorking;

    void Start () {
        audioPlayer = GetComponent<AudioSource>();
        lampLight = GetComponent<Light>();
        isWorking = true;
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && isWorking) {
            if (lampLight.enabled) {
                audioPlayer.clip = flashLightOff;
            } else {
                audioPlayer.clip = flashLightOn;
            }

            audioPlayer.Play();
            lampLight.enabled = !lampLight.enabled;
        }
    }

    public void ShouldLampWork(bool shouldWork) {
        lampLight.enabled = false;
        isWorking = shouldWork;
    }
}
