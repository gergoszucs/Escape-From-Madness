using System.Collections;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public GameObject[] zombies;

	void Start () {
        StartCoroutine(ActivateZombie());
    }

    IEnumerator ActivateZombie() {
        while (true) { 
            int index = Random.Range(0, 60);
            if (zombies[index].activeSelf) {
                yield return new WaitForSeconds(0.1f);
            } else {
                zombies[index].SetActive(true);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}