using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1BulletMover : MonoBehaviour {
	private Rigidbody2D rb;
	private Transform t;
	private PlayerController playerController;

	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		t = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		float distanceX = t.position.x - rb.position.x;
		float distanceY = t.position.y - rb.position.y;
		if(Mathf.Abs(distanceX) > Mathf.Abs(distanceY)){
			float x = Mathf.Abs(distanceY) / Mathf.Abs(distanceX);
			float res = bulletSpeed/Mathf.Sqrt (Mathf.Pow(x,2) + 1);
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
			float res = bulletSpeed/Mathf.Sqrt (Mathf.Pow(y,2) + 1);
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
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Destroy (gameObject);
			playerController.ChangeHealth (-1);
			playerController.CallTintChange ();
			playerController.CallInvulnerable ();//try again if it is good
			//an explosion maybe?
		}
	}
    // Update is called once per frame
    void Update() {

    }
}
