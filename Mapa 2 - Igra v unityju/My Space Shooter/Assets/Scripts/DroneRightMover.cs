using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRightMover : MonoBehaviour {
	public float speed = -0.3f;
	public float attackWait;

	public GameObject bullet;
	public Transform shotSpawn;

	private bool move = true;
	private bool moveLeft = false;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		if(transform.position.x <= 3.37 && move){
			StartCoroutine ("StartAndStop");
			move = false;
		}
		if (move) {
			rb.velocity = new Vector2 (speed, 0f);
		} else if (moveLeft) {
			rb.velocity = new Vector2 (speed, 0f);
		} else {
			rb.velocity = new Vector2 (0f, 0f);
		}
	}

	private IEnumerator Attack(){
		while(true){
			Instantiate (bullet, shotSpawn.position, shotSpawn.rotation);
			yield return new WaitForSeconds (attackWait);
		}
	}

	private IEnumerator StartAndStop(){
		StartCoroutine ("Attack");
		yield return new WaitForSeconds (2.5f);
		StopCoroutine ("Attack");
		moveLeft = true;
		speed *= -1;
	}
}
