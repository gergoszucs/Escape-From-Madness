using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using PostProcess;

public class Intro : MonoBehaviour {

    public GameObject gergo, cranfield, efm, panel;

    Text gergoText, cranfieldText, efmText;
    AudioSource heartbeatSound;
    BlinkEffect blinkEffect;

    void Start() {
        gergoText = gergo.GetComponent<Text>();
        cranfieldText = cranfield.GetComponent<Text>();
        efmText = efm.GetComponent<Text>();
        heartbeatSound = GetComponent<AudioSource>();
        blinkEffect = FindObjectOfType<Camera>().GetComponent<BlinkEffect>();

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
        heartbeatSound.Play();
        Invoke("FadeTitle", 4f);
    }

    void FadeTitle() {
        StartCoroutine(FadeTextToZeroAlpha(1f, efmText));
        panel.SetActive(false);
        Invoke("Blink", 1f);
    }

    void Blink() {
        blinkEffect.Blink();
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