using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class CloseFaucet : MonoBehaviour {

    public Text playerMessage;
    public GameObject zombie;
    public AudioClip closeFaucetSound, crawlerSound;

    AudioSource soundPlayer;
    GameObject player, fpsCamera;
    Animator playerAnimator;
    Quaternion originalRot;
    bool isColliding, faucetClosed;

    void Start() {
        soundPlayer = GetComponentInParent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        fpsCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        originalRot = player.transform.rotation;

        isColliding = false;
        faucetClosed = false;
    }

    void Update() {
        if(isColliding && Input.GetKey(KeyCode.F)) {
            faucetClosed = true;
            soundPlayer.clip = closeFaucetSound;
            soundPlayer.loop = false;
            soundPlayer.Play();
            Invoke("PlayScare", 0.5f);
        }
    }

    void PlayScare() {
        player.GetComponent<FirstPersonController>().enabled = false;
        //player.transform.rotation = Quaternion.identity;
        //fpsCamera.transform.rotation = Quaternion.identity;
        playerAnimator.applyRootMotion = false;
        playerAnimator.SetTrigger("Mirror");
        Invoke("DisableAnimator", 4f);
        zombie.SetActive(true);

        Invoke("HideZombie", 2.5f);

        soundPlayer.spatialBlend = 0f;
        soundPlayer.clip = crawlerSound;
        soundPlayer.Play();
    }

    void HideZombie(){
        zombie.SetActive(false);
    }

    void DisableAnimator() {
        playerAnimator.applyRootMotion = true;
        player.GetComponent<FirstPersonController>().enabled = true;
        player.transform.rotation = originalRot;
        //fpsCamera.transform.rotation = Quaternion.identity;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag == "Player" && !faucetClosed) {
            isColliding = true;
            playerMessage.text = "F - Close Faucet";
        } else if (faucetClosed) {
            playerMessage.text = "";
        }
    }

    void OnTriggerExit(Collider collider) {
        if (collider.tag == "Player") {
            isColliding = false;
            playerMessage.text = "";
        }
    }
}