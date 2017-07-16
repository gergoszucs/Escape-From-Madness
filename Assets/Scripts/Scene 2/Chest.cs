using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour {

    public Text playerMessage;
    public AudioClip lootGunSound;
    public GameObject weaponManager, health, ammo, gun;

    ChestCollider chestCollider;
    AudioSource audioPlayer;
    Animation animation;
    KeyCollider key;

    bool isChestOpen, isActive, gunFound, triedOpening;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        chestCollider = FindObjectOfType<ChestCollider>();
        animation = GetComponent<Animation>();
        key = FindObjectOfType<KeyCollider>();

        gunFound = false;
        isChestOpen = false;
        isActive = false;
        triedOpening = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && chestCollider.IsCollidingWithPlayer() && !isChestOpen && !isActive) {
            if (key.HasTakenKey()) {
                isActive = true;
                animation.Play();
                audioPlayer.Play();
                Invoke("SetChestOpen", audioPlayer.clip.length);
            } else {
                triedOpening = true;
                Invoke("ResetOpening", 3f);
            }

        }

        if (Input.GetKeyDown(KeyCode.F) && chestCollider.IsCollidingWithPlayer() && isChestOpen && !isActive && !gunFound) {
            gunFound = true;
            audioPlayer.clip = lootGunSound;
            audioPlayer.Play();
            Destroy(chestCollider);
            Invoke("DrawGun", lootGunSound.length);
            Destroy(gun);
            ammo.SetActive(true);
        }
    }

    void DrawGun() {
        weaponManager.SetActive(true);
        playerMessage.text = "Left Mouse Button - Fire \nRight Mouse Button - Aim down the sight \nR - Reload";
        Invoke("DismissHelp", 5f);
    }

    void DismissHelp() {
        playerMessage.text = "";
    }

    void ResetOpening() {
        triedOpening = false;
    }

    void SetChestOpen() {
        isChestOpen = true;
        isActive = false;
    }

    public bool IsGunFound() {
        return gunFound;
    }

    public bool IsChestOpen() {
        return isChestOpen;
    }

    public bool IsActive() {
        return isActive;
    }

    public bool HasTriedToOpen() {
        return triedOpening;
    }
}
