using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship2Mover : MonoBehaviour {
	private int health = 2;

	private float speed;

	private Rigidbody2D rb;
	private PlayerController playerController;
	private SurvivalGameController sgc;

	public GameObject ship2Explosion;
	public GameObject smallExplosion;

	// Use this for initialization
	void Start () {
		sgc = GameObject.FindGameObjectWithTag ("SurvivalGameController").GetComponent<SurvivalGameController>();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		speed = sgc.GetSpeed();
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (0, speed);
	}
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = new Vector2 (0, speed);
	}

	void changeSpeed(float newSpeed){
		this.speed = newSpeed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player") || other.CompareTag("Bolt")){
			health--;//maybe more if we change the bullet 'strength'
			if (other.CompareTag ("Player")) {
				playerController.ChangeHealth (-2);
				Instantiate (ship2Explosion, transform.position, transform.rotation);
				playerController.CallTintChange ();
				playerController.CallInvulnerable ();
				//add score?
				sgc.AddScore (20);
				Destroy (gameObject);
			} else if (health <= 0) {
				//add score?
				Instantiate (ship2Explosion, transform.position, transform.rotation);
				sgc.AddScore (20);
				Destroy (gameObject);
			} else {
				Instantiate (smallExplosion, other.transform.position, other.transform.rotation);
				StartCoroutine ("TintChange");
			}
		}
	}

	private IEnumerator TintChange(){
		GetComponent<SpriteRenderer> ().color = new Color(223/255f, 46/255f, 46/255f);
		yield return new WaitForSeconds (0.16f);
		GetComponent<SpriteRenderer> ().color = Color.white;
	}
}
