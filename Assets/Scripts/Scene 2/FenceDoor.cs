using UnityEngine;

public class FenceDoor : MonoBehaviour {

    public GameObject monsters;
    public GameObject scareMonster;

    FenceDoorCollider doorCollider;
    AudioSource audioPlayer;
    Animation animation;
    Chest chest;
    FlashlightOnOff flashlightController;

    bool isDoorOpen, isActive;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        doorCollider = FindObjectOfType<FenceDoorCollider>();
        animation = GetComponent<Animation>();
        chest = FindObjectOfType<Chest>();
        flashlightController = FindObjectOfType<FlashlightOnOff>();

        isDoorOpen = false;
        isActive = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && doorCollider.IsCollidingWithPlayer() && !isDoorOpen && !isActive && chest.IsGunFound()) {
            isActive = true;
            animation.Play();
            audioPlayer.Play();
            Invoke("SetDoorOpen", audioPlayer.clip.length);
        }
    }

    void SetDoorOpen() {
        monsters.SetActive(true);
        isDoorOpen = true;
        isActive = false;
        Destroy(doorCollider);
        Destroy(scareMonster);
        flashlightController.ShouldLampWork(false);
    }

    public bool IsDoorOpen() {
        return isDoorOpen;
    }

    public bool IsActive() {
        return isActive;
    }
}