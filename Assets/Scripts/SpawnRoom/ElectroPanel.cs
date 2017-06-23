using UnityEngine;

public class ElectroPanel : MonoBehaviour {

    public AudioClip badIdeaSound, acceptSound, switchSound, powerDown;

    AudioSource audioPlayer;
    SwitchCollider switchCollider;
    bool isFirstTry, isSwitched, isPowerDown;

	void Start () {
        audioPlayer = GetComponent<AudioSource>();
        switchCollider = FindObjectOfType<SwitchCollider>();
        isFirstTry = true;
        isSwitched = false;
        isPowerDown = false;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.F) && !audioPlayer.isPlaying && switchCollider.IsCollidingWithPlayer()) {
            if (isFirstTry) {
                audioPlayer.clip = badIdeaSound;
                audioPlayer.Play();
                isFirstTry = false;
            } else if(!isSwitched) {
                audioPlayer.clip = acceptSound;
                audioPlayer.Play();
                isSwitched = true;
                Invoke("Switch", acceptSound.length);
            }
        }
	}

    void Switch() {
        audioPlayer.clip = switchSound;
        audioPlayer.Play();
        Invoke("PowerDown", switchSound.length);
    }
    
    void PowerDown() {
        audioPlayer.clip = powerDown;
        audioPlayer.Play();
        Invoke("SetPowerDown", powerDown.length);
    }

    void SetPowerDown() {
        isPowerDown = true;
    }

    public bool IsPowerDown() {
        return isPowerDown;
    }

    public bool IsSwitched() {
        return isSwitched;
    }

    public bool IsPlayingAudio() {
        return audioPlayer.isPlaying;
    }
}