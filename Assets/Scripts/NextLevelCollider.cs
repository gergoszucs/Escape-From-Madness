using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class NextLevelCollider : MonoBehaviour {

    public GameObject eyesCenter;
    public GameObject monsters;

    LevelManager levelManager;
    GameObject player;
    PlayerCamera playerCamera;

    bool isCollided = false;

    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = FindObjectOfType<PlayerCamera>();
    }

    void Update() {
        if (isCollided) {
            playerCamera.transform.LookAt(eyesCenter.transform.position + new Vector3(30f, 0f, 0f));
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            player.GetComponent<FirstPersonController>().enabled = false;
            isCollided = true;
            monsters.GetComponent<Animation>().Play();
            Invoke("LoadNextLevel", 5f);
        }
    }

    void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
}