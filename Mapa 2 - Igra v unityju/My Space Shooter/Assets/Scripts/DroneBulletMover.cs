using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBulletMover : MonoBehaviour {
	public float speed = 3f;
	public GameObject smallExplosion;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
        try
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        catch (Exception e) {

        }
		if(transform.position.x > 0){
			speed *= -1;
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, 0f);
	}
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {
		if(other.CompareTag("Player") && playerController != null){
			Instantiate (smallExplosion, transform.position, transform.rotation);
			playerController.ChangeHealth (-1);
			playerController.CallTintChange ();
			playerController.CallInvulnerable ();
			Destroy (gameObject);
		}
	}
}
