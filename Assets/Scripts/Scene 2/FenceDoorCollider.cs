using UnityEngine;
using UnityEngine.UI;

public class FenceDoorCollider : MonoBehaviour {

    public Text playerMessage;

    FenceDoor door;
    Chest chest;
    bool isColliding;

    void Start() {
        door = FindObjectOfType<FenceDoor>();
        chest = FindObjectOfType<Chest>();

        isColliding = false;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && !door.IsDoorOpen() && !door.IsActive()) {
            isColliding = true;
            if (chest.IsGunFound()) {
                playerMessage.text = "F - Open Door";
            } else {
                playerMessage.text = "I need a gun before going out there";
            }
        } else if (collider.tag == "Player") {
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