using UnityEngine;

public class AnnaCollider : MonoBehaviour {

    PlayerCamera player;
    bool hasScreamed;

	void Start () {
        player = FindObjectOfType<PlayerCamera>();
        hasScreamed = false;
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player" && !hasScreamed) {
            hasScreamed = true;
            player.ScreamForAnna();
        }
    }
}
