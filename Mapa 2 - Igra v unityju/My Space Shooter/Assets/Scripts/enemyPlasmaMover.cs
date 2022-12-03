using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlasmaMover : MonoBehaviour {
	public GameObject smallExplosion;

	private Rigidbody2D rb;
	private float speed = 4;

	private PlayerController playerController;

	// Use this for initialization
	void Start () {//add sound and play it on awake?? yes later
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (0.0f, speed * -1);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			Destroy (gameObject);
			Instantiate (smallExplosion, transform.position, transform.rotation);
			playerController.ChangeHealth (-1);
			playerController.CallTintChange ();
			playerController.CallInvulnerable ();
		}
	}
}
