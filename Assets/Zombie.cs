using UnityEngine;

public class Zombie : MonoBehaviour {

    Animation animation;
    ParticleSystem bloodEffect;
    float health;
    bool dead;

	void Start () {
        animation = GetComponent<Animation>();
        bloodEffect = GetComponent<ParticleSystem>();
        health = 100f;
        dead = false;
	}
	
	public void ReduceHealth() {
        if (!dead) {
            bloodEffect.Play();
            health -= 25f;
            if (health <= 0f) {
                animation.Play();
                dead = true;
            }
        }
    }
}