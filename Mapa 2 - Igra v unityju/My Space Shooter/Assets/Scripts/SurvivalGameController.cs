using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalGameController : MonoBehaviour {
	private float score = 0;
	public bool survival = false;
	public GameObject player;

	public float startWait;
	public float enemyWait;
	public float positionY;
	public float minX;
	public float maxX;

	public AudioSource original;

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

	public GameObject[] powerUps;

	public AudioSource[] audios;

	private int wave = 0;
	private float enemySpeed = -1.3f;
    private float originalEnemyWait;

    public static bool GameOver { get; private set; }

	// Use this for initialization
	void Start () {
        originalEnemyWait = enemyWait;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(){
		player.SetActive (true);
		survival = true;
		StartCoroutine ("Spawner");
		StartCoroutine ("PowerUpSpawner");
		StartCoroutine ("UpgradeDifficulty");
	}
	IEnumerator Spawner(){
		audios[1].Pause ();
		audios[0].Play();
		yield return new WaitForSeconds (startWait);
		while(!GameOver){
			for (int j = 0; j < 10; j++) {
				int which = Mathf.FloorToInt (Random.Range(0,wave));
				if (which >= 6) {
					Instantiate (enemy3, new Vector3 (Random.Range (minX, maxX), positionY, 0), transform.rotation);
				} else if (which >= 3) {
					Instantiate (enemy2, new Vector3 (Random.Range (minX, maxX), positionY, 0), transform.rotation);
				} else {
					Instantiate (enemy1, new Vector3 (Random.Range (minX, maxX), positionY, 0), transform.rotation);
				}
				yield return new WaitForSeconds (enemyWait);
			}
			if(wave < 9){
				wave++;
			}
		}
	}
	private IEnumerator PowerUpSpawner(){
		yield return new WaitForSeconds (30f);
		while(true){
			int which = Mathf.FloorToInt (Random.Range(0f, 3.99f));
			Instantiate (powerUps [which], new Vector2(Random.Range (minX, maxX), positionY), powerUps[which].transform.rotation);
			yield return new WaitForSeconds (30f);
		}
	}
	private IEnumerator UpgradeDifficulty(){
		yield return new WaitForSeconds (30f);
		for(int i = 0; ; i++){
			if (i % 2 == 0) {
				enemyWait -= 0.2f;
			} else {
				enemySpeed -= 0.08f;
			}
			yield return new WaitForSeconds (30f);
		}
	}
	public float GetSpeed(){
		return enemySpeed;
	}
	public float GetScore(){
		return score;
	}
	public void AddScore(float amount){
		score += amount;
		if(score < 0){
			score = 0;
		}
	}
    public void EndGame() {
        GameOver = true;
        StopAllCoroutines();
    }
    public void RestartGame()
    {
        GameOver = false;

        wave = 0;
        enemySpeed = -1.3f;
        enemyWait = originalEnemyWait;

        player.SetActive(true);
        StartCoroutine("Spawner");
        StartCoroutine("UpgradeDifficulty");
        StartCoroutine("PowerUpSpawner");

        List<GameObject> objectsToBeRemoved = new List<GameObject>();
        objectsToBeRemoved.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        objectsToBeRemoved.AddRange(GameObject.FindGameObjectsWithTag("Enemy Bolt"));
        
        foreach (GameObject objectToBeRemoved in objectsToBeRemoved)
        {
            Destroy(objectToBeRemoved);
        }

    }
}
