using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Script : MonoBehaviour {
	private bool move = true;
	private bool moveUp = false;
	private bool minions = false;

	private int health;

	//have fixed bullet speed or dynamically change it? fixed for noww k
	private float minionsWait = 3f;
	private float attackWait = 3f;

	private Rigidbody2D rb;
	private GameController gameController;

	public GameObject smallExplosion;
	public GameObject bossExplosion;

	public GameObject plasmaBullet;
	public Transform plasmaSpawnLeft;
	public Transform plasmaSpawnRight;

	public Transform[] droneSpawns;
	public GameObject droneLeft;
	public GameObject droneRight;

	public float spawnMin1, spawnMax1, spawnMin2, spawnMax2;
	public GameObject minion;

	public float moveSpeed;
	public float hitDelay;//we'll se if it gud

	// Use this for initialization
	void Start () {
		health = 100;//100
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y <= 4 && move){
			move = false;
			StartCoroutine ("Attack");
		}
		if(health <= 0 && !moveUp){
			moveUp = true;
			moveSpeed *= -1;
		}else if(moveUp && health <= 0 && transform.position.y >= 6.1){
			Destroy (gameObject);
		}
	}

	void FixedUpdate(){
		if (move) {
			rb.velocity = new Vector2 (0f, moveSpeed);
		} else if (moveUp) {
			rb.velocity = new Vector2 (0f, moveSpeed);
		} else {
			rb.velocity = new Vector2 (0f, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Bolt")){
			Instantiate (smallExplosion, other.transform.position, other.transform.rotation);
			health--;
            gameController.ChangeBossHealth(-1, health);
            Destroy (other.gameObject);
			StartCoroutine("HitMarker");
			//maybe a sound and explosion?
		}
		if(health == 0 && !gameController.GetBoss3Destroyed() && other.CompareTag("Bolt"))
        {
			Instantiate (smallExplosion, other.transform.position, other.transform.rotation);
			//destroy boss
			//add sound to those explosion -- mujltiple??
			StopCoroutine ("Attack");
			StopCoroutine ("PrimaryAttack");
			StopCoroutine ("SecondaryAttack");
			StopCoroutine("CreateMinions");
			StartCoroutine ("Explode");
			gameController.Boss3Destroyed ();
		}
	}

	private IEnumerator Explode(){
		while(transform.position.y <= 5.7){//i think i like it
			//could have done publlic floats(x only) and determined it like that.. maybe do it??
			//change +- x, +-y
			Instantiate (bossExplosion, new Vector3(Random.Range(transform.position.x-0.17f, transform.position.x+0.17f), Random.Range(transform.position.y-0.5f, transform.position.y+0.6f), -1), transform.rotation);//instantiate explosion
			yield return new WaitForSeconds (0.3f);//could have explosionWait instead of fixed delay??
		}
		yield break;
	}

	private IEnumerator HitMarker(){//TintChange()
		GetComponent<SpriteRenderer> ().color = new Color(223/255f, 46/255f, 46/255f);
		yield return new WaitForSeconds (hitDelay);
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	private IEnumerator Attack(){
        while (!gameController.GetBoss3Destroyed()){
			int which = Mathf.FloorToInt(Random.Range (0, 2.99f));
			Debug.Log(which);
			if(which == 0){
				PrimaryAttack ();
			}else if(which == 1){
				this.SecondaryAttack ();
			}else{
				if (!minions) {
					minions = true;
					StartCoroutine ("CreateMinions");
				} else {
					which = Mathf.FloorToInt(Random.Range (0, 1.99f));
					if(which == 0){
						this.SecondaryAttack ();
					}else{
						PrimaryAttack ();
					}
				}
			}
			yield return new WaitForSeconds (attackWait/*dynamically change??*/); 
		}
	}

	private void PrimaryAttack(){
		Instantiate (plasmaBullet, plasmaSpawnLeft.position, plasmaSpawnLeft.rotation);
		Instantiate (plasmaBullet, plasmaSpawnRight.position, plasmaSpawnRight.rotation);
	}
	private void SecondaryAttack(){
		int which1 = Mathf.FloorToInt (Random.Range (0, 3.99f));
		int which2 = Mathf.FloorToInt (Random.Range (0, 3.99f));
		while (which1 == which2) {
			which2 = Mathf.FloorToInt (Random.Range (0, 3.99f));
		}
		if (droneSpawns [which1].position.x < 0) {
			Instantiate (droneLeft, droneSpawns [which1].position, droneSpawns [which1].rotation);
		} else {
			Instantiate (droneRight, droneSpawns [which1].position, droneSpawns [which1].rotation);
		}
		if (droneSpawns [which2].position.x < 0) {
			Instantiate (droneLeft, droneSpawns [which2].position, droneSpawns [which2].rotation);
		} else {
			Instantiate (droneRight, droneSpawns [which2].position, droneSpawns [which2].rotation);
		}
	}
	private IEnumerator CreateMinions(){
		for(int i = 0; i < 5/*maybe hange this value dynamically -> based on the health of the boss??*/; i++){
			int which = Mathf.FloorToInt (Random.Range(0, 1.99f));
			if (which == 0) {
				Instantiate (minion, new Vector2(Random.Range(spawnMin1, spawnMax1), 5.5f), gameObject.transform.rotation);
			} else {
				Instantiate (minion, new Vector2(Random.Range(spawnMin2, spawnMax2), 5.5f), gameObject.transform.rotation);
			}
			yield return new WaitForSeconds (minionsWait/*change dynamically?*/);
		}
		minions = false;
	}

    public void StopAttacking() {
        if (gameController.GameOver)
        {
            health = 0;
            StopCoroutine("Attack");
            StopCoroutine("PrimaryAttack");
            StopCoroutine("SecondaryAttack");
            StopCoroutine("CreateMinions");
            gameController.Boss3Destroyed();
        }
    }
}
