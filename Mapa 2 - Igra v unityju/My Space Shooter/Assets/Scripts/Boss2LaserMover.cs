using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2LaserMover : MonoBehaviour {

	private Rigidbody2D rb;
	private float speed = 4f;

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		try{
			playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		}catch(MissingComponentException){
			Debug.Log ("watata");
		}
		rb.velocity = new Vector2 (0.0f, speed * -1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Destroy (gameObject);
			playerController.ChangeHealth (-1);
			playerController.CallTintChange ();
			playerController.CallInvulnerable ();
			// instantiate a lil explsion lkater maybe?
		}
	}
}
