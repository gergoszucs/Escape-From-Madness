using UnityEngine;

public class EnemyDoor : MonoBehaviour {

    public GameObject[] blockingStrechers;

    AudioSource audioPlayer;
    OpenEnemyDoor doorCollider;
    Animator animator;
    ZombieDoor zombieDoor;
    Chainsaw chainsaw;

    bool isDoorOpen, isActive, isDoorClosed;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        doorCollider = FindObjectOfType<OpenEnemyDoor>();
        animator = GetComponent<Animator>();
        zombieDoor = FindObjectOfType<ZombieDoor>();
        chainsaw = FindObjectOfType<Chainsaw>();

        isDoorOpen = false;
        isDoorClosed = false;
        isActive = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && doorCollider.IsCollidingWithPlayer() && !isDoorOpen && !isActive) {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>().Stop();
            isActive = true;
            animator.SetTrigger("Open");
            audioPlayer.Play();
            chainsaw.StopAudio();
            Invoke("SetDoorOpen", audioPlayer.clip.length);
        } else if (Input.GetKeyDown(KeyCode.F) && doorCollider.IsCollidingWithPlayer() && isDoorOpen && !isActive && doorCollider.CanClose()) {
            isActive = true;
            isDoorClosed = true;
            animator.SetTrigger("Close");
            audioPlayer.Play();
        }
    }

    void SetDoorInactive() {
        isActive = false;
    }

    void SetDoorOpen() {
        SetDoorInactive();
        isDoorOpen = true;
        zombieDoor.OpenDoorAfter(5f);

        foreach (GameObject strecher in blockingStrechers) {
            strecher.SetActive(true);
        }
    }

    public bool IsDoorOpen() {
        return isDoorOpen;
    }

    public bool IsDoorClosed() {
        return isDoorClosed;
    }

    public bool IsActive() {
        return isActive;
    }
}