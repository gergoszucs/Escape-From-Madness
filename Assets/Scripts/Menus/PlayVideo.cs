using UnityEngine;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour {

    public MovieTexture movie;

    RawImage rawImage;

	void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        rawImage = GetComponent<RawImage>();
        movie.loop = true;
        rawImage.texture = movie;
        movie.Play();
    }
}