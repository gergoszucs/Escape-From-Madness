using UnityEngine;

public class MonsterRunCollider : MonoBehaviour {

    public GameObject monster;

    ScareCollider scareCollider;

	void Start () {
        scareCollider = FindObjectOfType<ScareCollider>();
	}

    void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Player" && scareCollider.HasMonsterAppeared()) {
            monster.GetComponent<Animation>().Play();
        }
    }
}