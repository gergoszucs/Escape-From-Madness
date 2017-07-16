using UnityEngine;
using UnityEngine.UI;

public class KeyCollider : MonoBehaviour {

    public Text playerMessage;
    public GameObject key;

    AudioSource audioPlayer;
    bool isColliding, hasPickedUp;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();

        isColliding = false;
        hasPickedUp = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F) && isColliding && !hasPickedUp) {
            hasPickedUp = true;
            Destroy(key.gameObject);
            audioPlayer.Play();
        }
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && !hasPickedUp) {
            isColliding = true;
            playerMessage.text = "F - Take key";
        } else if (collider.tag == "Player" && hasPickedUp) {
            isColliding = true;
            playerMessage.text = "";
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            isColliding = false;
            playerMessage.text = "";
        }
    }

    public bool HasTakenKey() {
        return hasPickedUp;
    }
}