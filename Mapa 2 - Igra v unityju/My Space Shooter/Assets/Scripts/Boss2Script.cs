using System.Collections;
using UnityEngine;

public class Boss2Script : MonoBehaviour {//CAN DO: clear the lasers when boss dies
	private bool move = true;
	private bool moveUp = false;
	private bool minions = false;
	private bool primaryAttack = false;

	private int health;

	//have fixed bullet speed or dynamically change it? fixed for noww k
	private float secondaryAttackRate = 0.3f;
	private float minionsWait = 3f;
	private float attackWait = 3f;

	private Rigidbody2D rb;
	private GameController gameController;

	public GameObject smallExplosion;
	public GameObject bossExplosion;

	public float spawnMin1, spawnMax1, spawnMin2, spawnMax2;
	public GameObject minion;

	public Transform[] attack1Spawns;
	public GameObject laser;

	public GameObject mine;
	public Transform[] mineSpawns;
	private GameObject[] mines = new GameObject[5];
	private int mineCount = 0;

	public float moveSpeed;
	public float hitDelay;//we'll se if it gud

	// Use this for initialization
	void Start () {
		health = 75;
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y <= 3.2 && move){
			move = false;
			StartCoroutine ("Attack");
		}
		if(health <= 0 && !moveUp){
			moveUp = true;
			moveSpeed *= -1;
		}else if(moveUp && health <= 0 && transform.position.y >= 6.85){
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
		if(health == 0 && !gameController.GetBoss2Destroyed() && other.CompareTag("Bolt"))
        {
			Instantiate (smallExplosion, other.transform.position, other.transform.rotation);
			//destroy boss
			//add sound to those explosion -- mujltiple??
			StopCoroutine ("Attack");
			StopCoroutine ("PrimaryAttack");
			StopCoroutine ("SecondaryAttack");
			StopCoroutine("CreateMinions");
			StartCoroutine ("Explode");
			gameController.Boss2Destroyed ();
		}
	}

	private IEnumerator Explode(){
		while(transform.position.y <= 5.7){//i think i like it
			//could have done publlic floats(x only) and determined it like that.. maybe do it??
			Instantiate (bossExplosion, new Vector3(Random.Range(transform.position.x-0.7f, transform.position.x+0.7f), Random.Range(transform.position.y-0.6f, transform.position.y+1.4f), -1), transform.rotation);//instantiate explosion
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
        while (!gameController.GetBoss2Destroyed()){
            //GameObject[] lasers = GameObject.FindGameObjectsWithTag("Enemy Bolt");//not good-> because i have too many lasers on the scene atm
            //foreach (GameObject laser in lasers) {
            //    Destroy(laser);
            //}
			int which = Mathf.FloorToInt(Random.Range (0, 2.99f));
			Debug.Log(which);
			if(which == 0){
				StopCoroutine ("PrimaryAttack");
				StartCoroutine ("PrimaryAttack");
			}else if(which == 1){
				primaryAttack = false;
				StartCoroutine ("SecondaryAttack");
			}else{
				if (!minions) {
					primaryAttack = false;
					minions = true;
					StartCoroutine ("CreateMinions");	
				} else {
					which = Mathf.FloorToInt(Random.Range (0, 1.99f));
					if(which == 0){
						primaryAttack = false;
						StartCoroutine ("SecondaryAttack");
					}else{
						StopCoroutine ("PrimaryAttack");
						StartCoroutine ("PrimaryAttack");
					}
				}
			}
			yield return new WaitForSeconds (attackWait/*dynamically change??*/); 
		}
	}

	private IEnumerator PrimaryAttack(){
		primaryAttack = true;
		int[] index = new int[3];
		index [0] = -1; index [1] = -2; index [2] = -3;
		for(int i = 0; i < 3; i++){
			index[i] = Mathf.FloorToInt (Random.Range(0, 5.99f));
			while(index[0] == index[1] || index[1] == index[2] ||index[0] == index[2]){
				index[i] = Mathf.FloorToInt (Random.Range(0, 5.99f));
			}
		}
		while(primaryAttack){//create sound here? like hmming 
			Instantiate (laser, attack1Spawns[index[0]].position, attack1Spawns[index[0]].rotation);
			Instantiate (laser, attack1Spawns[index[1]].position, attack1Spawns[index[1]].rotation);
			Instantiate (laser, attack1Spawns[index[2]].position, attack1Spawns[index[2]].rotation);
			yield return new WaitForSeconds(0.01f);
		}
	}
	private IEnumerator SecondaryAttack(){
		if (mineCount <= 3) {
			int which = Mathf.FloorToInt (Random.Range(0, 2.99f));
			if(mineCount == 3){
				if(mines[which] != null){
					mines[which].GetComponent<Boss2MineMover>().Destroy();			
				}
				mines [which] = null;
				mineCount--;
			}
			for(int i = 0; i < 3; i++){
				for(int j = 0; j < 5; j++){
					if(mines[j] == null){
						mines[j] = Instantiate (mine, mineSpawns[i].position, mineSpawns[i].rotation);
						break;
					}
				}
				mineCount++;
			}
		}else if (mineCount == 4) {
			int which1 = Mathf.FloorToInt (Random.Range(0, 1.99f));
			int which2 = Mathf.FloorToInt (Random.Range(2, 3.99f));
			if(mines[which1] != null){
				mines[which1].GetComponent<Boss2MineMover>().Destroy();			
			}
			yield return new WaitForSeconds (0.3f);
			mines [which1] = null;
			if(mines[which2] != null){
				mines[which2].GetComponent<Boss2MineMover>().Destroy();
			}
			mines [which2] = null;
			mineCount -= 2;
			for(int i = 0; i < 3; i++){
				for(int j = 0; j < 5; j++){
					if(mines[j] == null){
						mines[j] = Instantiate (mine, mineSpawns[i].position, mineSpawns[i].rotation);
						break;
					}
				}
				mineCount++;
			}
		}else if (mineCount == 5) {
			int which1 = Mathf.FloorToInt (Random.Range(0, 2.99f));
			int which2 = Mathf.FloorToInt (Random.Range(3, 4.99f));
			for(int i = 0; i < 5; i++){
				if(i != which1 && i != which2){
					if(mines[i] != null){
						mines[i].GetComponent<Boss2MineMover>().Destroy();
						yield return new WaitForSeconds (0.3f);
					}
					mines [i] = null;
					mineCount--;
				}
			}
			for(int i = 0; i < 3; i++){
				for(int j = 0; j < 5; j++){
					if(mines[j] == null){
						mines[j] = Instantiate (mine, mineSpawns[i].position, mineSpawns[i].rotation);
						break;
					}
				}
				mineCount++;
			}
		}
		yield return new WaitForSeconds (0.1f);
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

	public void ChangeMineCount(int amount){
		mineCount += amount;
	}

    public void StopAttacking() {
        if (gameController.GameOver)
        {
            health = 0;
            StopCoroutine("Attack");
            StopCoroutine("PrimaryAttack");
            StopCoroutine("SecondaryAttack");
            StopCoroutine("CreateMinions");
            gameController.Boss2Destroyed();
        }
    }
}
