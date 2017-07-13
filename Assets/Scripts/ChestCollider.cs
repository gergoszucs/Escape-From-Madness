using UnityEngine;
using UnityEngine.UI;

public class ChestCollider : MonoBehaviour {

    public Text playerMessage;

    Chest chest;
    
    bool isColliding;

    void Start() {
        chest = FindObjectOfType<Chest>();
        isColliding = false;
    }

    void OnTriggerStay(Collider collider) {
        if (chest.HasTriedToOpen()) {
            isColliding = true;
            playerMessage.text = "The chest is locked";
        } else if (collider.tag == "Player" && !chest.IsChestOpen() && !chest.IsActive()) {
            isColliding = true;
            playerMessage.text = "F - Open Chest";
        } else if (collider.tag == "Player" && chest.IsChestOpen() && !chest.IsActive() && !chest.IsGunFound()) {
            isColliding = true;
            playerMessage.text = "F - Take Pistol";
        } else if ((chest.IsChestOpen() && chest.IsGunFound()) || chest.IsActive()) {
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