using UnityEngine;

public class BathroomDoor : MonoBehaviour {

    public GameObject[] lampsToTurnOff;
    public GameObject[] shadersToDisable;

    AudioSource audioPlayer;
    OpenBathroomDoor doorCollider;
    Animator animator;
    bool isDoorOpen, isActive;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        doorCollider = FindObjectOfType<OpenBathroomDoor>();
        animator = GetComponent<Animator>();

        isDoorOpen = false;
        isActive = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && doorCollider.IsCollidingWithPlayer() && !isDoorOpen) {
            isActive = true;
            animator.SetTrigger("OpenDoor");
            audioPlayer.Play();
            Invoke("SetDoorOpen", audioPlayer.clip.length);
        }
    }

    void SetDoorInactive() {
        isActive = false;
    }

    void SetDoorOpen() {
        SetDoorInactive();
        isDoorOpen = true;
        Destroy(doorCollider);

        foreach (GameObject obj in lampsToTurnOff) {
            obj.GetComponent<Light>().enabled = false;
        }

        foreach (GameObject obj in shadersToDisable) {
            obj.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black * Mathf.LinearToGammaSpace(0f));
        }
        
    }

    public bool IsDoorOpen() {
        return isDoorOpen;
    }

    public bool IsActive() {
        return isActive;
    }
}