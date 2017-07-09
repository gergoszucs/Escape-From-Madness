using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class CloseFaucet : MonoBehaviour {

    public Text playerMessage;
    public GameObject zombie;
    public AudioClip closeFaucetSound, scareSound;

    GameObject[] wallTexts;
    AudioSource soundPlayer;
    GameObject player, fpsCamera;
    DaughterScream screamPlayer;
    bool isColliding, faucetClosed;

    void Awake() {
        wallTexts = GameObject.FindGameObjectsWithTag("WallText");

        foreach (GameObject text in wallTexts) {
            text.SetActive(false);
        }
    }

    void Start() {
        soundPlayer = GetComponentInParent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        fpsCamera = GameObject.FindGameObjectWithTag("MainCamera");
        screamPlayer = FindObjectOfType<DaughterScream>();

        isColliding = false;
        faucetClosed = false;
    }

    void Update() {
        if(isColliding && Input.GetKey(KeyCode.F) && !faucetClosed) {

            faucetClosed = true;
            soundPlayer.clip = closeFaucetSound;
            soundPlayer.loop = false;
            soundPlayer.Play();
            Invoke("PlayScare", 0.5f);
        }
    }

    void PlayScare() {
        player.transform.position = new Vector3(66.3f, 0.98f, 57.79f);
        player.transform.rotation = Quaternion.identity;
        player.transform.Rotate(0, 180, 0);
        fpsCamera.transform.rotation = Quaternion.identity;
        fpsCamera.transform.Rotate(0, 180, 0);

        player.GetComponent<FirstPersonController>().enabled = false;
        zombie.SetActive(true);
        Invoke("HideZombie", scareSound.length);

        soundPlayer.spatialBlend = 0f;
        soundPlayer.clip = scareSound;
        soundPlayer.Play();
    }

    void HideZombie(){
        player.GetComponent<FirstPersonController>().enabled = true;
        zombie.SetActive(false);

        Invoke("StartScreams", 2f);
    }

    void StartScreams() {
        foreach (GameObject text in wallTexts) {
            text.SetActive(true);
        }

        screamPlayer.PlayScreams();
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