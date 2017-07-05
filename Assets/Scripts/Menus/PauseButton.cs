using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public AudioClip onHover;

    Button button;
    Text buttonText;
    Color originalColor;
    AudioSource effectPlayer;

	void Start () {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        originalColor = buttonText.color;
        effectPlayer = GetComponent<AudioSource>();
	}

    public void OnPointerEnter(PointerEventData eventData) {
        buttonText.color = Color.black;
        effectPlayer.clip = onHover;
        effectPlayer.Play();
    }

    public void OnPointerExit(PointerEventData eventData) {
        buttonText.color = originalColor;
    }
}