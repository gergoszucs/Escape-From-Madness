using UnityEngine;
using UnityEngine.UI;

public class OpenDoorCollider : MonoBehaviour {

    public Text playerMessage;

    SpawnRoomDoor door;
    ElectroPanel electroPanel;
    bool isColliding;

    void Start() {
        door = FindObjectOfType<SpawnRoomDoor>();
        electroPanel = FindObjectOfType<ElectroPanel>();
        isColliding = false;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && (!door.HasTriedToOpen() || electroPanel.IsPowerDown()) && !door.IsDoorOpen()) {
            isColliding = true;
            playerMessage.text = "F - Open Door";
        } else if ((door.HasTriedToOpen() && !electroPanel.IsPowerDown()) || door.IsDoorOpen()) {
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