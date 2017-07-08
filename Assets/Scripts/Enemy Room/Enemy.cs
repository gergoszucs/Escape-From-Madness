using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class Enemy : MonoBehaviour {

    public Transform alan;
    public GameObject charactedModel;

    Animator animator;
    NavMeshAgent agent;
    AudioSource audioPlayer;
    LevelManager levelManager;
    PlayerCamera playerCamera;
    GameObject player;

    float moveSpeed;
    bool hasCollided, shouldChase;

	void Start () {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioPlayer = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        playerCamera = FindObjectOfType<PlayerCamera>();
        player = GameObject.FindGameObjectWithTag("Player");

        moveSpeed = 1f;
        hasCollided = false;
        shouldChase = false;
	}
	
	void Update () {
        if (shouldChase) {
            agent.SetDestination(alan.position);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            playerCamera.PlayDyingSound();
            animator.SetTrigger("Attack");
            player.GetComponent<FirstPersonController>().enabled = false;
            charactedModel.SetActive(false);
            Vector3 lookAtZombie = transform.position + new Vector3(0f, 2.5f, 0f);
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x - 1f, 1.6f, playerCamera.transform.position.z);
            playerCamera.transform.LookAt(lookAtZombie);
            Invoke("LoadDeathScene", 4f);
        }
    }

    void LoadDeathScene() {
        levelManager.LoadLevel(8);
    }

    public void Roar() {
        audioPlayer.Play();
        animator.SetTrigger("Roar");
        Invoke("Walk", 2f);
    }

    public void StopRoaring() {
        audioPlayer.Stop();
    }

    void Walk() {
        shouldChase = true;
        animator.SetTrigger("Walk");
    }
}
