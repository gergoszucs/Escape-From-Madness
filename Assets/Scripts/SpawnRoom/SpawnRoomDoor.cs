using UnityEngine;

public class SpawnRoomDoor : MonoBehaviour {

    public AudioClip lockedSound, lockedVoice, knockSound, fearVoice, openDoorSound;

    AudioSource audioPlayer;
    OpenDoorCollider doorCollider;
    Animation openDoorAnimation;
    ElectroPanel electroPanel;
    bool isFirstTry, isDoorOpen;

    void Start () {
        audioPlayer = GetComponent<AudioSource>();
        doorCollider = FindObjectOfType<OpenDoorCollider>();
        openDoorAnimation = GetComponent<Animation>();
        electroPanel = FindObjectOfType<ElectroPanel>();

        isFirstTry = true;
        isDoorOpen = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && isFirstTry && doorCollider.IsCollidingWithPlayer()) {
            isFirstTry = false;
            audioPlayer.clip = lockedSound;
            audioPlayer.Play();
            Invoke("PlayLockedReaction", lockedSound.length + 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.F) && electroPanel.IsPowerDown() && doorCollider.IsCollidingWithPlayer()) {
            Debug.Log(electroPanel.IsPowerDown());
            openDoorAnimation.Play();
            audioPlayer.clip = openDoorSound;
            audioPlayer.Play();
            Invoke("SetDoorOpen", openDoorSound.length);
        }
    }

    void PlayLockedReaction() {
        audioPlayer.clip = lockedVoice;
        audioPlayer.Play();
        Invoke("PlayKnockOnDoor", lockedVoice.length + 1.5f);
    }

    void PlayKnockOnDoor() {
        audioPlayer.clip = knockSound;
        audioPlayer.Play();
        Invoke("PlayFearVoice", knockSound.length + 1.5f);
    }

    void PlayFearVoice() {
        audioPlayer.clip = fearVoice;
        audioPlayer.Play();
    }

    void SetDoorOpen() {
        isDoorOpen = true;
    }

    public bool IsDoorOpen() {
        return isDoorOpen;
    }

    public bool HasTriedToOpen() {
        return !isFirstTry;
    }
}