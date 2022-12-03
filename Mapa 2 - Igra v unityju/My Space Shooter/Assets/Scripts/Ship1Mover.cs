using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship1Mover : MonoBehaviour {

	private float speed;
	private Rigidbody2D rb;
	private PlayerController playerController;
	private SurvivalGameController sgc;

	public GameObject ship1Explosion;
	public GameObject smallExplosion;

	// Use this for initialization
	void Start () {
		sgc = GameObject.FindGameObjectWithTag ("SurvivalGameController").GetComponent<SurvivalGameController>();
        try {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        } catch (Exception e) {

        }
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
			Instantiate (ship1Explosion, transform.position, transform.rotation);
			if (other.CompareTag ("Player")) {
				playerController.ChangeHealth (-1);
			 	playerController.CallTintChange ();
			 	playerController.CallInvulnerable ();
				Destroy (gameObject);
			} else{
				Destroy (gameObject);
			}
			sgc.AddScore (10);
		}
	}
}
