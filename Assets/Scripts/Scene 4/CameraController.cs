using PostProcess;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject UI, EFM, gergo, house, anna;

    BlinkEffect blinkEffect;
    AudioSource audioPlayer, bgMusicPlayer;
    Animation animation;
    LevelManager levelManager;

    void Start() {
        audioPlayer = GetComponent<AudioSource>();
        bgMusicPlayer = anna.GetComponent<AudioSource>();
        blinkEffect = GetComponent<BlinkEffect>();
        animation = GetComponent<Animation>();
        levelManager = FindObjectOfType<LevelManager>();

        blinkEffect.SetDefaultFadeInAnimationCurves(0.8f);
        blinkEffect.SetDefaultFadeOutAnimationCurves(0.8f);
        blinkEffect.Blink();
        Invoke("WakeUp", 3f);
    }

    void WakeUp() {
        audioPlayer.Play();
        blinkEffect.inAndOut = false;
        blinkEffect.SetDefaultFadeInAnimationCurves(0f);
        blinkEffect.Blink();

        Invoke("LookAround", 1f);
    }

    void LookAround() {
        animation.Play();
        Invoke("SleepBack", animation.clip.length);
    }

    void SleepBack() {
        Invoke("ShowUI", 1f);
    }

    void ShowUI() {
        UI.SetActive(true);
        Destroy(house);
        EFM.GetComponent<Animation>().Play();
        Invoke("FadeInCredits", 4.5f);
    }

    void FadeInCredits() {
        gergo.GetComponent<Animation>().Play();
        InvokeRepeating("DeafenSound", 1f, 0.1f);
        Invoke("LoadMenu", 11f);
    }

    void DeafenSound() {
        bgMusicPlayer.volume -= 0.01f;
    }

    void LoadMenu() {
        levelManager.LoadLevel(1);
    }
}