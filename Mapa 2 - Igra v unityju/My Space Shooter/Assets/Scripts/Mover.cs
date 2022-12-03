using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public GameObject smallExplosion;

	private Rigidbody2D rb;
	private float speed = 4;

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		if(gameObject.CompareTag("Enemy Bolt")){
			playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		}
		rb = GetComponent<Rigidbody2D> ();
		if (gameObject.CompareTag ("Enemy Bolt")) {
			rb.velocity = new Vector2 (0.0f, speed * -1);
		} else {
			rb.velocity = new Vector2 (0.0f, speed);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (gameObject.CompareTag ("Enemy Bolt")) {
			if(other.CompareTag("Player")){
				Destroy (gameObject);
				Instantiate (smallExplosion, transform.position, transform.rotation);
				playerController.ChangeHealth (-1);
				playerController.CallTintChange ();
				playerController.CallInvulnerable ();
				// instantiate a lil explsion lkater maybe?
			}
		} else {
			if (other.CompareTag ("Enemy")) {
				//instantiate an explosion??
				Destroy (gameObject);
			}
		}
	}
}
