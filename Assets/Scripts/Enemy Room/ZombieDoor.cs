using UnityEngine;

public class ZombieDoor : MonoBehaviour {

    AudioSource audioPlayer;
    Animator animator;
    Enemy enemy;
    OpenEnemyDoor enemyDoor;
    PlayerCamera player;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        enemy = FindObjectOfType<Enemy>();
        enemyDoor = FindObjectOfType<OpenEnemyDoor>();
        player = FindObjectOfType<PlayerCamera>();
    }

    public void OpenDoorAfter(float delay) {
        Invoke("OpenDoor", delay);
    }

    void OpenDoor() {
        animator.SetTrigger("Open");
        audioPlayer.Play();
        Invoke("EnemyRoar", 2f);
        Invoke("CloseDoor", 7f);
    }

    void EnemyRoar() {
        enemyDoor.LetPlayerCloseDoor();
        enemy.Roar();
        player.PlayNoNoNoSound();
    }

    void CloseDoor() {
        animator.SetTrigger("Close");
        audioPlayer.Play();
    }
}