using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaMover : MonoBehaviour {
	public float speed;
	private Transform posXLeft;
	private Transform posXRight;

	private Rigidbody2D rb;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		rb = GetComponent<Rigidbody2D> ();
		posXLeft = GameObject.FindGameObjectWithTag ("PlasmaSpawnLeft").GetComponent<Transform>();
		posXRight = GameObject.FindGameObjectWithTag ("PlasmaSpawnRight").GetComponent<Transform>();
		float distanceX = 0;
		if (transform.position.x < 0) {
			distanceX = posXLeft.position.x - transform.position.x;
		} else {
			distanceX = posXRight.position.x - transform.position.x;
		}
		float distanceY = posXLeft.position.y - transform.position.y;
		if(Mathf.Abs(distanceX) > Mathf.Abs(distanceY)){
			float x = Mathf.Abs(distanceY) / Mathf.Abs(distanceX);
			float res = speed/Mathf.Sqrt (Mathf.Pow(x,2) + 1);
			float velocityX = 0;
			if (distanceX >= 0) {
				velocityX = res;
			} else {
				velocityX = res*-1;
			}
			float velocityY = res * x * -1;
			rb.velocity = new Vector2 (velocityX, velocityY);
		}else{
			float y = Mathf.Abs(distanceX) / Mathf.Abs(distanceY);
			float res = speed/Mathf.Sqrt (Mathf.Pow(y,2) + 1);
			float velocityX = 0;
			if (distanceX >= 0) {
				velocityX = res * y;
			} else {
				velocityX = res * y * -1;
			}
			float velocityY = res * -1;
			rb.velocity = new Vector2 (velocityX, velocityY);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Destroy (gameObject);
			playerController.ChangeHealth (-1);//maybe 0.5f
			playerController.CallTintChange ();
			playerController.CallInvulnerable ();//try again if it is good
		}
	}
}
