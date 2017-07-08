using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {

    public GameObject lampLight, colliderObject;
    public Text playerMessage;
    public AudioClip flashLightOn, flashLightOff;
    public GameObject blockingStretcher;

    AudioSource audioPlayer;
    PickupFlashlight flashLightCollider;
    StopScreamCollider screamCollider;
    Chainsaw chainsaw;
    bool hasPickedUp;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        flashLightCollider = FindObjectOfType<PickupFlashlight>();
        screamCollider = FindObjectOfType<StopScreamCollider>();
        chainsaw = FindObjectOfType<Chainsaw>();

        hasPickedUp = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && !hasPickedUp && flashLightCollider.IsCollidingWithPlayer()) {
            hasPickedUp = true;
            audioPlayer.Play();
            playerMessage.text = "";
            colliderObject.SetActive(false);
            transform.position = new Vector3(100f, 0f, 0f);
            Invoke("ShowFlashlightHelp", 2f);

            if (screamCollider.HasCollided()) {
                chainsaw.PlayChainsawAudioAfter(5f);
                Destroy(blockingStretcher);
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && hasPickedUp) {
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

    public bool HasPickedUp() {
        return hasPickedUp;
    }
}