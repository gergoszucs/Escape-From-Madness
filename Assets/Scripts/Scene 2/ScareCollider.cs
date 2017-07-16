using UnityEngine;

public class ScareCollider : MonoBehaviour {

    public GameObject eyes;

    Chest chest;
    bool monsterAppeared;

    void Start () {
        chest = FindObjectOfType<Chest>();

        monsterAppeared = false;
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player" && chest.IsGunFound() && !monsterAppeared) {
            eyes.SetActive(true);
            eyes.GetComponent<AudioSource>().Play();
            monsterAppeared = true;
        }
    }

    public bool HasMonsterAppeared() {
        return monsterAppeared;
    }
}