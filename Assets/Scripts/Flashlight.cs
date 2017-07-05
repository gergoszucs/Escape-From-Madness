using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {

    public GameObject lampLight, colliderObject;
    public Text playerMessage;
    public AudioClip flashLightOn, flashLightOff;

    AudioSource audioPlayer;
    PickupFlashlight flashLightCollider;
    bool hasTriedToPickup;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        flashLightCollider = FindObjectOfType<PickupFlashlight>();

        hasTriedToPickup = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && !hasTriedToPickup && flashLightCollider.IsCollidingWithPlayer()) {
            hasTriedToPickup = true;
            audioPlayer.Play();
            playerMessage.text = "";
            colliderObject.SetActive(false);
            transform.position = new Vector3(100f, 0f, 0f);
            Invoke("ShowFlashlightHelp", 2f);
        }

        if (Input.GetKeyDown(KeyCode.X) && hasTriedToPickup) {
            if (lampLight.activeSelf) {
                audioPlayer.clip = flashLightOff;
            } else {
                audioPlayer.clip = flashLightOn;
            }

            audioPlayer.Play();
            lampLight.SetActive(!lampLight.activeSelf);
        }
    }

    void ShowFlashlightHelp() {
        
        playerMessage.text = "X - Turn flashlight on/off";
        Invoke("HideFlashlightHelp", 4f);
    }

    void HideFlashlightHelp() {
        playerMessage.text = "";
    }

    public bool HasTriedToPickup() {
        return hasTriedToPickup;
    }
}