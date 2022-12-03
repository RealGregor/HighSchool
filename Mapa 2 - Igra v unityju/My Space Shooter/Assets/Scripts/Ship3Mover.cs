using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship3Mover : MonoBehaviour {
	private int health = 2;

	private float speed;

	private Rigidbody2D rb;
	private PlayerController playerController;
	private SurvivalGameController sgc;
    private GameController gameController;

	public Transform shotSpawn;
	public GameObject enemy3Bolt;
	public GameObject ship3Explosion;
	public GameObject smallExplosion;

	public float attackWait;

	// Use this for initialization
	void Start () {
		sgc = GameObject.FindGameObjectWithTag ("SurvivalGameController").GetComponent<SurvivalGameController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		speed = sgc.GetSpeed();
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (0, speed);
		StartCoroutine ("Attack");
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
			health--;//maybe more if we change the bullet 'strength'
			if (other.CompareTag ("Player")) {
				playerController.ChangeHealth (-2);
				Instantiate (ship3Explosion, transform.position, transform.rotation);
				playerController.CallTintChange ();
				playerController.CallInvulnerable ();
				//add score?
				sgc.AddScore (30);
				Destroy (gameObject);
			} else if (health <= 0) {
				//add score?
				Instantiate (ship3Explosion, transform.position, transform.rotation);
				sgc.AddScore (30);
				Destroy (gameObject);
			} else {
				Instantiate (smallExplosion, other.transform.position, other.transform.rotation);
				StartCoroutine ("TintChange");
			}
		}
	}

	private IEnumerator TintChange(){
		GetComponent<SpriteRenderer> ().color = new Color(223/255f, 46/255f, 46/255f);
		yield return new WaitForSeconds (0.16f);
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	private IEnumerator Attack(){
		yield return new WaitForSeconds (0.7f);
		while (!gameController.GameWon && !gameController.GameOver) {
			Instantiate (enemy3Bolt, shotSpawn.position, shotSpawn.rotation);
			yield return new WaitForSeconds (attackWait);
		}
	}
}
