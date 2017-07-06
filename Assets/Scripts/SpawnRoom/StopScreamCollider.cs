using UnityEngine;

public class StopScreamCollider : MonoBehaviour {

    public GameObject blockingStretcher;

    DaughterScream screamPlayer;

	void Start () {
        screamPlayer = FindObjectOfType<DaughterScream>();
	}

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player" && screamPlayer.GetComponent<AudioSource>().isPlaying) {
            screamPlayer.StopScreams();
            Destroy(blockingStretcher);
        }
    }
}