using UnityEngine;
using UnityEngine.UI;

public class OpenExitDoor : MonoBehaviour {

    public Text playerMessage;

    EnemyDoor enemyDoor;
    bool isColliding;

    void Start() {
        enemyDoor = FindObjectOfType<EnemyDoor>();

        isColliding = false;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && enemyDoor.IsDoorClosed()) {
            isColliding = true;
            playerMessage.text = "F - Leave House";
        } else if (collider.tag == "Player" &&  enemyDoor.IsDoorOpen()) {
            isColliding = true;
            playerMessage.text = "F - Open Door";
        } else if (collider.tag == "Player") {
            isColliding = true;
            playerMessage.text = "I have to check those noises first!";
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