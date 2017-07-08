using UnityEngine;

public class ElectroPanel : MonoBehaviour {

    public AudioClip switchSound, powerDown;

    AudioSource audioPlayer;
    SwitchCollider switchCollider;
    SpawnRoomDoor door;
    bool isSwitched, isPowerDown;

	void Start () {
        audioPlayer = GetComponent<AudioSource>();
        switchCollider = FindObjectOfType<SwitchCollider>();
        door = FindObjectOfType<SpawnRoomDoor>();
        isSwitched = false;
        isPowerDown = false;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.F) && !audioPlayer.isPlaying && switchCollider.IsCollidingWithPlayer() && !door.IsActive()) {
            if(!isSwitched) {
                audioPlayer.clip = switchSound;
                audioPlayer.Play();
                isSwitched = true;
                Invoke("PowerDown", switchSound.length);
            }
        }
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