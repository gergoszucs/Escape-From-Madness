using UnityEngine;
using UnityEngine.UI;

public class CrouchCollider : MonoBehaviour {

    public Text playerMessage;

    bool isShown;

	void Start () {
        isShown = false;
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player" && !isShown) {
            isShown = true;
            playerMessage.text = "Ctrl - Crouch";
            Invoke("RemoveText", 4f);
        }
    }

    void RemoveText() {
        playerMessage.text = "";
    }
}