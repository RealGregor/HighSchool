using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMover : MonoBehaviour {
	private float speed = -2f;

	private PlayerController playerController;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        try
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        catch (Exception e) { }
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = Vector2.up * speed;
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			if(gameObject.CompareTag("SpeedPowerUp")){
				playerController.StartCoroutine ("TemporarySpeedChange");
				//change speed
			}else if(gameObject.CompareTag("FireRatePowerUp")){
				playerController.StartCoroutine ("TemporaryFireRateChange");
				//change fier rate
			}else if(gameObject.CompareTag("HealthPowerUp")){
				playerController.ChangeHealth (1);
				//add 1 health
			}else{
				playerController.ChangeShield (1);
				//add 1 shield bar
			}
			Destroy (gameObject);
		}
	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }
}
