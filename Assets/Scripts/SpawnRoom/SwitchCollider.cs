using UnityEngine;
using UnityEngine.UI;

public class SwitchCollider : MonoBehaviour {

    public Text playerMessage;

    ElectroPanel electroPanel;
    bool isColliding;

    void Start() {
        electroPanel = FindObjectOfType<ElectroPanel>();

        isColliding = false;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && !electroPanel.IsSwitched() && !electroPanel.IsPlayingAudio()) {
            isColliding = true;
            playerMessage.text = "F - Pull Electrical Switch";
        } else if (electroPanel.IsPlayingAudio()) {
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