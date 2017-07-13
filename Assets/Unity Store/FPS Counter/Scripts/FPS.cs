using System.Collections;
using UnityEngine;

public class FPS : MonoBehaviour {

    float deltaTime = 0.0f;
    float fps = 0.0f;

    void Awake() {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 5000;
        
    }

    void Start() {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        InvokeRepeating("UpdateFps", 0.0f, 0.2f);
    }

    void Update() {
        if (Time.timeScale != 0f) {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        }
    }

    void OnGUI() {
        if (PlayerPrefsManager.GetDrawFPS()) {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            string text = string.Format("{0:0.} FPS", fps);
            GUI.Label(rect, text, style);
        }
    }

    void UpdateFps() {
        fps = 1.0f / deltaTime;
    }
}
