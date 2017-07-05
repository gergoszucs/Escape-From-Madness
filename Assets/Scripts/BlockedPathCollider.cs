using UnityEngine;
using UnityEngine.UI;

public class BlockedPathCollider : MonoBehaviour {

    public Text playerMessage;
    public AudioClip pathIsBlocked;

    AudioSource voice;
    Flashlight flashlight;
    bool isColliding, hasPlayedDarkVoice, hasPlayedBlockedVoice;

    void Start() {
        voice = GetComponentInParent<AudioSource>();
        flashlight = FindObjectOfType<Flashlight>();

        isColliding = false;
        hasPlayedDarkVoice = false;
        hasPlayedBlockedVoice = false;
    }

    void Update() {
        if (isColliding && !hasPlayedDarkVoice && !flashlight.HasTriedToPickup()) {
            hasPlayedDarkVoice = true;
            voice.Play();
        }

        if (isColliding && !hasPlayedBlockedVoice && flashlight.HasTriedToPickup()) {
            hasPlayedBlockedVoice = true;
            voice.clip = pathIsBlocked;
            voice.Play();
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
}