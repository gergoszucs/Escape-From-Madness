using UnityEngine;

public class LampShaderController : MonoBehaviour {

    Material mat;
    Color originalColor;
    
    void Start () {
        mat = GetComponent<MeshRenderer>().material;
        originalColor = new Color(0.9540001f, 0.8030629f, 0.5331177f);
    }

    public void ChangeEmission(float emission) {
        mat.SetColor("_EmissionColor", originalColor * Mathf.LinearToGammaSpace(emission));
    }
}