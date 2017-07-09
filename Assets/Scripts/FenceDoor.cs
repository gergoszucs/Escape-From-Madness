using UnityEngine;

public class FenceDoor : MonoBehaviour {

    FenceDoorCollider doorCollider;
    AudioSource audioPlayer;
    Animation animation;

    bool isDoorOpen, isActive;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        doorCollider = FindObjectOfType<FenceDoorCollider>();
        animation = GetComponent<Animation>();

        isDoorOpen = false;
        isActive = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && doorCollider.IsCollidingWithPlayer() && !isDoorOpen && !isActive) {
            isActive = true;
            animation.Play();
            audioPlayer.Play();
            Invoke("SetDoorOpen", audioPlayer.clip.length);
        }
    }

    void SetDoorOpen() {
        isDoorOpen = true;
        isActive = false;
        Destroy(doorCollider);
    }

    public bool IsDoorOpen() {
        return isDoorOpen;
    }

    public bool IsActive() {
        return isActive;
    }
}