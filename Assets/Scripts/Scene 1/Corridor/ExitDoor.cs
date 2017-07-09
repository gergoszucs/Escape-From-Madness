using UnityEngine;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour {

    public AudioClip doorLocked, doorOpen;
    public GameObject flashlight;
    public Text playerMessage;

    AudioSource effectPlayer;
    OpenExitDoor doorCollider;
    EnemyDoor enemyDoor;
    Enemy enemy;
    LevelManager levelManager;

    void Start () {
        effectPlayer = GetComponent<AudioSource>();
        doorCollider = FindObjectOfType<OpenExitDoor>();
        enemyDoor = FindObjectOfType<EnemyDoor>();
        enemy = FindObjectOfType<Enemy>();
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.F) && doorCollider.IsCollidingWithPlayer() && !effectPlayer.isPlaying) {
            if (enemyDoor.IsDoorOpen() && !enemyDoor.IsDoorClosed()) {
                effectPlayer.clip = doorLocked;
                effectPlayer.Play();
            } else if (enemyDoor.IsDoorClosed()) {
                Destroy(doorCollider.gameObject);
                playerMessage.text = "";
                effectPlayer.clip = doorOpen;
                effectPlayer.Play();
                flashlight.SetActive(false);
                enemy.StopRoaring();
                Invoke("LoadSecondScene", doorOpen.length);
            }
        }
	}

    void LoadSecondScene() {
        levelManager.LoadNextLevel();
    }
}