using UnityEngine;
using UnityEngine.UI;

public class PickupFlashlight : MonoBehaviour {

    public Text playerMessage;

    Flashlight flashLight;
    bool isColliding;

    void Start() {
        flashLight = FindObjectOfType<Flashlight>();
        isColliding = false;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && !flashLight.HasTriedToPickup()) {
            isColliding = true;
            playerMessage.text = "F - Take Flashlight";
        } else if (flashLight.HasTriedToPickup()) {
            playerMessage.text = "";
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            isColliding = false;
            playerMessage.text = "";
        }
    }

    public bool IsCollidingWithPlayer() {
        return isColliding;
    }
}