using UnityEngine;

[RequireComponent(typeof(Light))]
public class FaultyLight : MonoBehaviour {

    public Light secondaryLight;
    public GameObject lampHider;
    public AudioClip faultySound, normalBuzz;

    Light lampLight;
    AudioSource lampSound;

    float timePassed, faultStart, faultLength;

	void Start () {
        lampLight = GetComponent<Light>();
        lampSound = GetComponent<AudioSource>();

        timePassed = 0f;
	}
	
	// Make light look like its faulty
	void Update () {
        if(timePassed == 0f) {
            faultStart = Random.Range(3f,9f);
            faultLength = Random.Range(0.5f,4f);
            timePassed = Time.timeSinceLevelLoad;
        }

        // Fault effect begins after 3-9 sec
        if(Time.timeSinceLevelLoad - timePassed > faultStart) {
            FaultyEffect();
        }

        // Fault effect done after 0.5-4 sec
        if ((Time.timeSinceLevelLoad - timePassed > faultStart + faultLength)) {
            NormalEffect();
        }
    }

    void FaultyEffect() {
        if (lampSound.clip != faultySound) {
            lampSound.clip = faultySound;
            lampSound.volume = 0.8f;
            lampSound.Play();
        }

        if (Random.value < .05f) {
            secondaryLight.intensity = 0.2f;
            lampLight.intensity = 2.5f;
            lampHider.SetActive(false);
            secondaryLight.enabled = true;
            lampLight.enabled = true;
        } else {
            lampHider.SetActive(true);
            secondaryLight.intensity = Random.Range(0f, 0.2f);
            lampLight.intensity = Random.Range(0f, 2.5f);
            /*secondaryLight.enabled = false;
            lampLight.enabled = false;*/
        }
    }

    void NormalEffect() {
        if (lampSound.clip != normalBuzz) {
            lampSound.clip = normalBuzz;
            lampSound.volume = 0.15f;
            lampSound.Play();
        }
        secondaryLight.intensity = 0.2f;
        lampLight.intensity = 2.5f;
        lampHider.SetActive(false);
        secondaryLight.enabled = true;
        lampLight.enabled = true;
        timePassed = 0f;
    }
}