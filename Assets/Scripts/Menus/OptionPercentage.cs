using UnityEngine;
using UnityEngine.UI;

public class OptionPercentage : MonoBehaviour {

    public Slider slider;

    Text text;

    private void Start() {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        text.text = ((int)(slider.value * 100)).ToString();
	}
}