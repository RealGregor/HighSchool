 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary{
	public float xmin, xmax, ymin, ymax;
}

public class PlayerController : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	public Transform shotSpawn;
	public GameObject missile;
	public GameObject playerExplosion;

	//public Slider healthSlider;
	//public Slider shieldSlider;
	public SliderVisualChange sliderVisualChange;

    private bool isInvulnerable = false;
	private float enemyDamage = 0f;
    
	private float health = 5f;
	private int shieldCount;

	private Rigidbody2D rb;
	private float fireRate = 0.7f;
	private float nextFire;
	private GameController gameController;
    private SurvivalGameController survivalGameController;

    private float resetSpeed;//used for reseting speed after the player presses the reset button
    private Vector3 resetPosition;
    
    // Use this for initialization
    void Start () {
        resetSpeed = speed;
        resetPosition = this.transform.position;

        survivalGameController = GameObject.FindGameObjectWithTag("SurvivalGameController").GetComponent<SurvivalGameController>(); ;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ();
		sliderVisualChange.CallActivateLifeCount (ref health);
		rb = GetComponent<Rigidbody2D> ();
	}

    private void OnEnable()
    {
        sliderVisualChange.CallActivateLifeCount(ref health);
    }

    // Update is called once per frame
    void Update(){
		if(Input.GetButton("Fire1") && Time.time >= nextFire && Time.timeScale == 1){
			nextFire = Time.time + fireRate;
			Instantiate (missile, shotSpawn.position, shotSpawn.rotation);
		}
	}

    //will be executed once per physics step
    void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		rb.velocity = new Vector2 (moveHorizontal, moveVertical) * speed;
		rb.position = new Vector2 (
			Mathf.Clamp(rb.position.x, boundary.xmin, boundary.xmax),
			Mathf.Clamp(rb.position.y, boundary.ymin, boundary.ymax)
		);
	}
	void OnTriggerEnter2D(Collider2D other){
		
	}
	public void ChangeHealth(float amount){
        if (!gameObject.activeInHierarchy) { return; }
		//float health = sliderChange(ref health, amount);
		sliderVisualChange.CallHealthChange(ref health, amount, ref isInvulnerable, enemyDamage, ref shieldCount);
		if(health <= 0){
			DestroySelf ();
		}
	}
	public void ChangeShield(int amount){
        if (!gameObject.activeInHierarchy) { return; }
        sliderVisualChange.CallShieldChange (ref shieldCount, amount);
	}

	public void CallTintChange(){
        if (!gameObject.activeInHierarchy) { return; }
		StopCoroutine ("TintChange");
		StartCoroutine ("TintChange");
	}

	public void CallInvulnerable(){
        if (!gameObject.activeInHierarchy) { return; }
        if(!isInvulnerable){
			StartCoroutine ("Invulnerable");
		}
	}

	IEnumerator TintChange(){
		GetComponent<SpriteRenderer> ().color = new Color(223/255f, 46/255f, 46/255f);
		yield return new WaitForSeconds (0.2f);//we'll se maybe we change
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	IEnumerator Invulnerable(){
		isInvulnerable = true;
		yield return new WaitForSeconds(1);
		isInvulnerable = false;
	}

	private void DestroySelf(){
        if (survivalGameController.survival) {
            survivalGameController.EndGame(); 
        } else {
            gameController.endGame();
        }
        gameController.bossHealthSlider.gameObject.SetActive(false);
		Instantiate (playerExplosion, transform.position, transform.rotation);
        StopAllCoroutines();

		gameObject.SetActive (false);

        speed = resetSpeed;
        health = 5f;
        isInvulnerable = false;
        enemyDamage = 0f;
        nextFire = 0f;
        fireRate = 0.7f;
        transform.position = resetPosition;

        sliderVisualChange.CallDeactivateLifeCount();
        //shieldCount = 0; //not needed
        //Destroy (gameObject);
	}

	public IEnumerator TemporarySpeedChange(){
		speed += 1f;
		yield return new WaitForSeconds (10f);
		speed -= 1f;
	}
	public IEnumerator TemporaryFireRateChange(){
		fireRate -= 0.35f;
		yield return new WaitForSeconds (10f);
		fireRate += 0.35f;
	}
	public void FireRateChange(){
		fireRate -= 0.1f;
	}
	public void MovementSpeedChange(){
		speed += 0.5f;
	}
	public void EnemyDamage(){
		enemyDamage = 0.5f;
	}
	public float GetHealth(){
		return health;
	}
}
