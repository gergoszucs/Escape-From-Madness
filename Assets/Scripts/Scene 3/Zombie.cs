using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class Zombie : MonoBehaviour {

    public Transform alan;
    public AudioClip deathSound;

    Animation animation;
    ParticleSystem bloodEffect;
    NavMeshAgent agent;
    Animator animator;
    AudioSource audioPlayer;
    CapsuleCollider collider;
    GameObject playerCamera, player, weaponManager;
    LevelManager levelManager;

    float health;
    bool dead;

    static bool killedAlan = false;

	void Start () {
        animation = GetComponent<Animation>();
        bloodEffect = GetComponent<ParticleSystem>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        collider = GetComponent<CapsuleCollider>();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        weaponManager = GameObject.FindGameObjectWithTag("Guns");
        levelManager = FindObjectOfType<LevelManager>();

        health = 100f;
        dead = false;
        animator.SetTrigger("Walk");
        InvokeRepeating("IncreaseSpeed", 30f, 30f);
    }

    void Update() {
        if (!dead) {
            agent.SetDestination(alan.position);
        }
    }

    void IncreaseSpeed() {
        agent.speed += 1;
    }

    public void ReduceHealth() {
        if (!dead) {
            bloodEffect.Play();
            health -= 25f;
            if (health <= 0f) {
                animator.enabled = false;
                animation.Play();
                dead = true;
                agent.isStopped = true;
                audioPlayer.loop = false;
                audioPlayer.clip = deathSound;
                audioPlayer.Play();
                Destroy(collider);
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.tag == "Player" && !killedAlan) {
            killedAlan = true;
            playerCamera.GetComponent<ForestSoundManager>().PlayAlanDeathSound();
            animator.SetTrigger("Attack");
            player.GetComponent<FirstPersonController>().enabled = false;
            Vector3 lookAtZombie = transform.position + new Vector3(0f, 7.5f, 0f);
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x - 1f, 11.5f, playerCamera.transform.position.z);
            playerCamera.transform.LookAt(lookAtZombie);
            weaponManager.SetActive(false);
            Invoke("LoadSceneFour", playerCamera.GetComponent<ForestSoundManager>().playerDeath.length);
        }
    }

    void LoadSceneFour() {
        levelManager.LoadNextLevel();
    }
}