using UnityEngine;

public class SpawnRoomDoor : MonoBehaviour {

    public AudioClip lockedSound, knockSound, openDoorSound;

    AudioSource audioPlayer;
    OpenDoorCollider doorCollider;
    Animation openDoorAnimation;
    ElectroPanel electroPanel;
    GameObject sink;
    GameObject[] lampsToTurnOn;
    bool isFirstTry, isDoorOpen, isActive;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        doorCollider = FindObjectOfType<OpenDoorCollider>();
        openDoorAnimation = GetComponent<Animation>();
        electroPanel = FindObjectOfType<ElectroPanel>();
        lampsToTurnOn = GameObject.FindGameObjectsWithTag("TurnOn");
        sink = GameObject.FindGameObjectWithTag("Sink");

        foreach (GameObject light in lampsToTurnOn) {
            light.SetActive(false);
        }

        isFirstTry = true;
        isDoorOpen = false;
        isActive = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && isFirstTry && doorCollider.IsCollidingWithPlayer() && !electroPanel.IsPowerDown() && !electroPanel.IsPlayingAudio()) {
            isActive = true;
            isFirstTry = false;
            audioPlayer.clip = lockedSound;
            audioPlayer.Play();
            Invoke("PlayKnockOnDoor", lockedSound.length + 1.5f);
        }

        if (Input.GetKeyDown(KeyCode.F) && electroPanel.IsPowerDown() && doorCollider.IsCollidingWithPlayer() && !isActive) {
            isActive = true;
            openDoorAnimation.Play();
            audioPlayer.clip = openDoorSound;
            audioPlayer.Play();
            Invoke("SetDoorOpen", openDoorSound.length);
        }
    }

    void PlayKnockOnDoor() {
        audioPlayer.clip = knockSound;
        audioPlayer.Play();
        Invoke("SetDoorInactive", knockSound.length);
    }

    void SetDoorInactive() {
        isActive = false;
    }

    void SetDoorOpen() {
        SetDoorInactive();
        isDoorOpen = true;
        foreach (GameObject light in lampsToTurnOn) {
            light.SetActive(true);
        }
        sink.GetComponent<AudioSource>().Play();
    }

    public bool IsDoorOpen() {
        return isDoorOpen;
    }

    public bool HasTriedToOpen() {
        return !isFirstTry;
    }

    public bool IsActive() {
        return isActive;
    }
}