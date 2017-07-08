using UnityEngine;
using UnityEngine.UI;

public class SwitchCollider : MonoBehaviour {

    public Text playerMessage;

    ElectroPanel electroPanel;
    SpawnRoomDoor door;
    bool isColliding;

    void Start() {
        electroPanel = FindObjectOfType<ElectroPanel>();
        door = FindObjectOfType<SpawnRoomDoor>();

        isColliding = false;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && !electroPanel.IsSwitched() && !electroPanel.IsPlayingAudio() && !door.IsActive()) {
            isColliding = true;
            playerMessage.text = "F - Pull Electrical Switch";
        } else if (electroPanel.IsPlayingAudio() || door.IsActive()) {
            isColliding = false;
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