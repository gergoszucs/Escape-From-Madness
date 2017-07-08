using UnityEngine;
using UnityEngine.UI;

public class OpenEnemyDoor : MonoBehaviour {

    public Text playerMessage;

    EnemyDoor door;
    bool isColliding;
    bool canClose;

    void Start() {
        door = FindObjectOfType<EnemyDoor>();

        isColliding = false;
        canClose = false;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && !door.IsDoorOpen() && !door.IsActive()) {
            isColliding = true;
            playerMessage.text = "F - Open Door";
        } else if (collider.tag == "Player" && door.IsDoorOpen() && !door.IsActive() && canClose) {
            isColliding = true;
            playerMessage.text = "F - Shut Door";
        } else {
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

    public void LetPlayerCloseDoor() {
        canClose = true;
    }

    public bool CanClose() {
        return canClose;
    }
}