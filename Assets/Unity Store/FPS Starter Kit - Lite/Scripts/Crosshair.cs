using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Texture2D crosshairTexture;
    Rect position;

    void  Start (){
		position = new Rect( ( Screen.width - crosshairTexture.width ) / 2, ( Screen.height - crosshairTexture.height ) / 2, crosshairTexture.width, crosshairTexture.height );
    }

    void  OnGUI (){
        if(Time.timeScale != 0) {
            GUI.DrawTexture(position, crosshairTexture);
        }
    }
}