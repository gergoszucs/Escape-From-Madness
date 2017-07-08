using UnityEngine;
using UnityEngine.UI;

public class BlockedPathCollider : MonoBehaviour {

    public Text playerMessage;

    Flashlight flashlight;
    bool isColliding, hasPlayedDarkVoice, hasPlayedBlockedVoice;

    void Start() {
        flashlight = FindObjectOfType<Flashlight>();

        isColliding = false;
        hasPlayedDarkVoice = false;
        hasPlayedBlockedVoice = false;
    }

    void Update() {
        if (isColliding && !hasPlayedDarkVoice && !flashlight.HasPickedUp()) {
            hasPlayedDarkVoice = true;
            playerMessage.text = "It's way too dark, I must find some source of light first!";
            Invoke("ClearMessage", 3f);
        }

        if (isColliding && !hasPlayedBlockedVoice && flashlight.HasPickedUp()) {
            hasPlayedBlockedVoice = true;
            playerMessage.text = "Anna's voice is coming from the other way!";
            Invoke("ClearMessage", 3f);
        }
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player") {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            isColliding = false;
        }
    }

    void ClearMessage() {
        playerMessage.text = "";
    }
}