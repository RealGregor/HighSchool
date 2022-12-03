using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2MineMover : MonoBehaviour {
	public float spawn1Xmin, spawn1Xmax, spawn1Ymin, spawn1Ymax, spawn2Xmin, spawn2Xmax, spawn3Xmin, spawn3Xmax, spawn23Ymin, spawn23Ymax;

	private float velX;
	private float velY;

	private float a_X, a_Y;

	private float posX, posY;

	private bool done = false;
	private int which;

	private Rigidbody2D rb;
	private PlayerController playerController;
	private Boss2Script boss2Script;

	public GameObject mineExplosion;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
		boss2Script = GameObject.FindGameObjectWithTag ("Boss2").GetComponent<Boss2Script>();
		if(transform.position.x < -0.2f){
			posX = Random.Range (spawn2Xmin, spawn2Xmax);
			//posX = transform.position.x;
			posY = Random.Range (spawn23Ymin, spawn23Ymax);

			velY = -2f;
			velX = -4f;
			which = 1;

			a_X = 3f;

		}else if(transform.position.x > 0.2f){
			posX = Random.Range (spawn3Xmin, spawn3Xmax);
			posY = Random.Range (spawn23Ymin, spawn23Ymax);

			which = 2;
			velY = -2f;
			velX = 4f;

			a_X = -3f;
		}else{
			posX = Random.Range (spawn1Xmin, spawn1Xmax);
			posY = Random.Range (spawn1Ymin, spawn1Ymax);

			float distanceX = posX;
			float distanceY = posY - transform.position.y;

			which = 3;
			if(Mathf.Abs(distanceX) > Mathf.Abs(distanceY)){
				float x = Mathf.Abs(distanceY) / Mathf.Abs(distanceX);
				float res = 3f/Mathf.Sqrt (Mathf.Pow(x,2) + 1);
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
				float res = 3f/Mathf.Sqrt (Mathf.Pow(y,2) + 1);
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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Mathf.Abs (transform.position.x - posX) > 0.05f || Mathf.Abs (transform.position.y - posY) > 0.05f) {//maybe more accurate?
			if(which == 3){
				return;
			}
			if (done || Mathf.Abs(posX - transform.position.x) > 0.05f) {//just to be sure i pu 0.1f
				velX += Time.fixedDeltaTime * a_X;	
			} else {
				done = true;
				float s_y = Mathf.Abs(transform.position.y - posY);
				float t = s_y / velY;
				a_X = (2 * velX) / t;
			}
			rb.velocity = new Vector2 (velX, velY);
		} else {
			rb.velocity = new Vector2 (0f,0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player") || other.CompareTag("Bolt")){
			if(other.CompareTag("Player")){
				playerController.ChangeHealth (-0.5f);
				playerController.CallTintChange ();
				playerController.CallInvulnerable ();//try again if it is good
			}else{
				Destroy (other.gameObject);
			}
			Instantiate (mineExplosion, transform.position, transform.rotation);
			boss2Script.ChangeMineCount(-1);
			Destroy (gameObject);
		}
	}
	public void Destroy(){
		Instantiate (mineExplosion, transform.position, transform.rotation);
		Destroy (gameObject);	
	}
}
