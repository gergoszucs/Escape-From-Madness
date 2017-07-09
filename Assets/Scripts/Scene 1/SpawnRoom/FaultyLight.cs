using UnityEngine;

[RequireComponent(typeof(Light))]
public class FaultyLight : MonoBehaviour {

    public Light secondaryLight;
    public AudioClip faultySound, normalBuzz;

    Light lampLight;
    AudioSource lampSound;
    LampShaderController shaderController;
    SpawnRoomDoor spawnRoomDoor;

    float timePassed, faultStart, faultLength;

	void Start () {
        lampLight = GetComponent<Light>();
        lampSound = GetComponent<AudioSource>();
        shaderController = FindObjectOfType<LampShaderController>();
        spawnRoomDoor = FindObjectOfType<SpawnRoomDoor>();

        timePassed = 0f;
	}
	
	// Make light look like its faulty
	void Update () {
        if (!spawnRoomDoor.IsDoorOpen()) {
            if (timePassed == 0f) {
                faultStart = Random.Range(3f, 9f);
                faultLength = Random.Range(0.5f, 4f);
                timePassed = Time.timeSinceLevelLoad;
            }

            // Fault effect begins after 3-9 sec
            if (Time.timeSinceLevelLoad - timePassed > faultStart) {
                FaultyEffect();
            }

            // Fault effect done after 0.5-4 sec
            if ((Time.timeSinceLevelLoad - timePassed > faultStart + faultLength)) {
                NormalEffect();
            }
        } else if(lampSound.isPlaying) {
            lampSound.Stop();
        } 
    }

    void FaultyEffect() {
        if (lampSound.clip != faultySound) {
            lampSound.clip = faultySound;
            lampSound.volume = 0.2f;
            lampSound.Play();
        }

        float currentEmission = Random.value;

        if (currentEmission > .95f) {
            secondaryLight.intensity = 0.5f;
            lampLight.intensity = 2.5f;
        } else {
            secondaryLight.intensity = Random.Range(0f, 0.2f);
            lampLight.intensity = Random.Range(0f, 2.5f);
        }

        shaderController.ChangeEmission(currentEmission);
    }

    void NormalEffect() {
        if (lampSound.clip != normalBuzz) {
            lampSound.clip = normalBuzz;
            lampSound.volume = 0.1f;
            lampSound.Play();
        }
        secondaryLight.intensity = 0.2f;
        lampLight.intensity = 2.5f;
        shaderController.ChangeEmission(1f);
        timePassed = 0f;
    }
}