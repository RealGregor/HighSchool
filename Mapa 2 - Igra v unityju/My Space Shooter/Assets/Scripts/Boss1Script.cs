using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Script : MonoBehaviour {
	private bool move = true;
	private bool moveUp = false;
	private bool minions = false;
	private bool secondaryAttack = false;

	private int health;

	//have fixed bullet speed or dynamically change it? fixed for noww k
	private float secondaryAttackRate = 0.3f;
	private float minionsWait = 3f;
	private float attackWait = 3f;

	private Rigidbody2D rb;
	private GameController gameController;

	public GameObject smallExplosion;
	public GameObject bossExplosion;

	public GameObject bullet;
	public Transform bulletSpawn;

	public Transform attack1Spawn1, attack1Spawn2, attack1Spawn3, attack1Spawn4, attack1Spawn5;
	public GameObject missile;

	public float spawnMin1, spawnMax1, spawnMin2, spawnMax2;
	public GameObject minion;

	public float moveSpeed;
	public float hitDelay;//we'll se if it gud




	// Use this for initialization
	void Start () {
		health = 50;
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
		}else if(moveUp && health <= 0 && transform.position.y >= 6.2){
			Destroy (gameObject);
		}
		//if(GameObject.FindGameObjectWithTag("Player") == null){//there is a chance that another bullet will be spawned before update is called so make sure that error doesn't happen. precaution
		//	StopCoroutine ("Attack");
		//	StopCoroutine ("PrimaryAttack");
		//	StopCoroutine ("SecondaryAttack");
		//	StopCoroutine("CreateMinions");
		//}
	}

	void FixedUpdate(){
		if (move) {
			rb.velocity = new Vector2 (0f, moveSpeed);
            return;
		} else if (moveUp) {
			rb.velocity = new Vector2 (0f, moveSpeed);
            return;
		}
	        rb.velocity = new Vector2 (0f, 0f);
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
		if(health == 0 && !gameController.GetBoss1Destroyed() && other.CompareTag("Bolt")){
			Instantiate (smallExplosion, other.transform.position, other.transform.rotation);
			secondaryAttack = false;
			StopCoroutine ("Attack");
			StopCoroutine ("PrimaryAttack");
			StopCoroutine ("SecondaryAttack");
			StopCoroutine("CreateMinions");
			StartCoroutine ("Explode");
			gameController.Boss1Destroyed ();
            //destroy boss
            //add sound to those explosion -- mujltiple??
        }
    }
    private IEnumerator Explode(){
		while(transform.position.y <= 5.7){//i think i like it
			//could have done publlic floats(x only) and determined it like that.. maybe do it??
			Instantiate (bossExplosion, new Vector3(Random.Range(transform.position.x-0.9f, transform.position.x+0.9f), Random.Range(transform.position.y-0.3f, transform.position.y+0.3f), -1), transform.rotation);//instantiate explosion
			//play sound -- make sound first
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
		while(!gameController.GetBoss1Destroyed()){
			int which = Mathf.FloorToInt(Random.Range (0, 2.99f));
			Debug.Log(which);
			if(which == 0){
				secondaryAttack = false;
				StartCoroutine ("PrimaryAttack");
			}else if(which == 1){
				if(!secondaryAttack){
					secondaryAttack = true;
					StartCoroutine ("SecondaryAttack");
				}
			}else{
				if (!minions) {
					minions = true;
					secondaryAttack = false;
					StartCoroutine ("CreateMinions");	
				} else {
					which = Mathf.FloorToInt(Random.Range (0, 1.99f));
					if(which == 0){
						if(!secondaryAttack){
							secondaryAttack = true;
							StartCoroutine ("SecondaryAttack");
						}
					}else{
						secondaryAttack = false;
						StartCoroutine ("PrimaryAttack");
					}
				}
			}
			yield return new WaitForSeconds (attackWait);                               /*dynamically change ?? */

        }
	}

	private IEnumerator PrimaryAttack(){// do we actually want it to be a coroutine?
		Instantiate(missile, attack1Spawn1.position, attack1Spawn1.rotation);
		yield return new WaitForSeconds (0.2f);
		Instantiate(missile, attack1Spawn2.position, attack1Spawn2.rotation);
		Instantiate(missile, attack1Spawn3.position, attack1Spawn3.rotation);
		Instantiate(missile, attack1Spawn4.position, attack1Spawn4.rotation);
		Instantiate(missile, attack1Spawn5.position, attack1Spawn5.rotation);
	}
	private IEnumerator SecondaryAttack(){//has to be an IEnumerator
		while(secondaryAttack){
			Debug.Log("Shooting");
			Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
			yield return new WaitForSeconds (secondaryAttackRate);//maybe change this
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
            secondaryAttack = false;
            StopCoroutine("Attack");
            StopCoroutine("PrimaryAttack");
            StopCoroutine("SecondaryAttack");
            StopCoroutine("CreateMinions");
            gameController.Boss1Destroyed();
        }
    }
}
