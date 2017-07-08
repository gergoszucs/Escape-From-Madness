using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using PostProcess;

public class Intro : MonoBehaviour {

    public GameObject gergo, cranfield, efm, panel;
    public AudioClip breathSound, heartbeatSound;

    Text gergoText, cranfieldText, efmText;
    AudioSource heartbeatPlayer, breathPlayer;
    BlinkEffect blinkEffect;
    Animator cameraAnimator;
    LevelManager levelManager;

    void Start() {
        Time.timeScale = 1f;
        gergoText = gergo.GetComponent<Text>();
        cranfieldText = cranfield.GetComponent<Text>();
        efmText = efm.GetComponent<Text>();
        blinkEffect = FindObjectOfType<Camera>().GetComponent<BlinkEffect>();
        cameraAnimator = FindObjectOfType<Camera>().GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        heartbeatPlayer = audioSources[0];
        heartbeatPlayer.loop = true;
        heartbeatPlayer.clip = heartbeatSound;

        breathPlayer = audioSources[1];
        breathPlayer.clip = breathSound;

        heartbeatPlayer.Play();
        Invoke("PlayCranfieldAnimation", 2.5f);
    }

    void PlayCranfieldAnimation() {
        cranfield.GetComponent<Animation>().Play();
        Invoke("FadeCredits", 3.5f);
    }

    void FadeCredits() {
        StartCoroutine(FadeTextToZeroAlpha(1f, gergoText));
        StartCoroutine(FadeTextToZeroAlpha(1f, cranfieldText));
        Invoke("ShowTitle", 1f);
    }

    void ShowTitle() {
        StartCoroutine(FadeTextToFullAlpha(1f, efmText));
        Invoke("FadeTitle", 4f);
    }

    void FadeTitle() {
        StartCoroutine(FadeTextToZeroAlpha(1f, efmText));
        Invoke("Blink1", 1f);
    }

    void Blink1() {
        panel.SetActive(false);

        blinkEffect.SetDefaultFadeInAnimationCurves(0.8f);
        blinkEffect.SetDefaultFadeOutAnimationCurves(0.8f);
        blinkEffect.Blink();
        Invoke("PlayBreathing", 1.1f);
        Invoke("Blink2", 3f);
    }

    void PlayBreathing() {
        breathPlayer.Play();
    }

    void Blink2() {
        blinkEffect.SetDefaultFadeInAnimationCurves(0.6f);
        blinkEffect.SetDefaultFadeOutAnimationCurves(0.6f);
        blinkEffect.Blink();
        Invoke("PlayBreathing", 1.1f);
        Invoke("Blink3", 3f);
    }

    void Blink3() {
        blinkEffect.inAndOut = false;
        blinkEffect.SetDefaultFadeInAnimationCurves(0f);
        blinkEffect.Blink();
        Invoke("PlayBreathing", 0.5f);
        Invoke("AnimateCamera", 0.5f + breathSound.length);
    }

    void AnimateCamera() {
        cameraAnimator.SetTrigger("isAwake");
        Invoke("GoToNextLevel", 10f);
    }

    void GoToNextLevel() {
        heartbeatPlayer.Stop();
        levelManager.LoadNextLevel();
    }

    IEnumerator FadeTextToZeroAlpha(float t, Text i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);

        while (i.color.a > 0.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);

        while (i.color.a < 1.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
}