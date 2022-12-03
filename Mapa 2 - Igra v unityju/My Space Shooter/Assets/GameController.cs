using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float startWait;
	public float enemyWait;
	public float positionY;
	public float minX;
	public float maxX;

	public AudioSource original;

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

	public GameObject boss1;
	public Transform boss1Spawn;

	public GameObject boss2;
	public Transform boss2Spawn;

	public GameObject boss3;
	public Transform boss3Spawn;

	public GameObject player;
    public Slider bossHealthSlider;

	public bool GameOver { get; set; }
    public bool GameWon { get; set; }
    private bool boss1Alive;
	private bool boss2Alive;
	private bool boss3Alive;

	public GameObject[] powerUps;

	private float boss1PosXMin1 = -2.9f;
	private float boss1PosXMax1 = -2.2f;
	private float boss1PosXMin2 = 2.2f;
	private float boss1PosXMax2 = 2.9f;
	private float boss2PosXMin1 = -2.85f;
	private float boss2PosXMax1 = -2.07f;
	private float boss2PosXMin2 = 2.07f;
	private float boss2PosXMax2 = 2.85f;
	private float boss3PosXMin1 = -2.75f;
	private float boss3PosXMax1 = -1.6f;
	private float boss3PosXMin2 = 1.6f;
	private float boss3PosXMax2 = 2.75f;

	public AudioSource[] audios;


	// Use this for initialization
	void Start () {
        GameOver = false;
        GameWon = false;
		boss1Alive = false;
		boss2Alive = false;
		boss3Alive = false;
	}
	
	// Update is called once per frame
	void Update () {
		audios[0].volume = original.volume;
		audios[1].volume = original.volume;
	}

	public void Activate(){
		player.SetActive (true);
		StartCoroutine ("Spawner");
		StartCoroutine ("PowerUpSpawner");
	}

	IEnumerator Spawner(){
		audios[1].Pause ();
		audios[0].Play();
		yield return new WaitForSeconds (startWait);
        for (int i = 0; i < 1/*was 4 before*/; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(enemy1, new Vector3(Random.Range(minX, maxX), positionY, 0), transform.rotation);
                yield return new WaitForSeconds(enemyWait);
            }
        }
        Instantiate(boss1, boss1Spawn.position, boss1Spawn.rotation);//instantiate boss1
        bossHealthSlider.maxValue = 50;
        bossHealthSlider.value = 50;
        bossHealthSlider.gameObject.SetActive(true);
        boss1Alive = true;
        yield return new WaitUntil(() => !boss1Alive);
        bossHealthSlider.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 1/*4*/; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int which = Mathf.FloorToInt(Random.Range(0, 1.99f));
                if (which == 0)
                {
                    Instantiate(enemy1, new Vector3(Random.Range(minX, maxX), positionY, 0), transform.rotation);
                }
                else
                {
                    Instantiate(enemy2, new Vector3(Random.Range(minX, maxX), positionY, 0), transform.rotation);
                }
                yield return new WaitForSeconds(enemyWait);
            }
        }//USTVARJANJE 
        Instantiate(boss2, boss2Spawn.position, boss2Spawn.rotation);//instantiate boss2
        bossHealthSlider.maxValue = 75;
        bossHealthSlider.value = 75;
        bossHealthSlider.gameObject.SetActive(true);
        boss2Alive = true;
        yield return new WaitUntil(() => !boss2Alive);
        bossHealthSlider.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 1/*4*/; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int which = Mathf.FloorToInt(Random.Range(0, 2.99f));
                if (which == 0)
                {
                    Instantiate(enemy1, new Vector3(Random.Range(minX, maxX), positionY, 0), transform.rotation);
                }
                else if (which == 1)
                {
                    Instantiate(enemy2, new Vector3(Random.Range(minX, maxX), positionY, 0), transform.rotation);
                }
                else
                {
                    Instantiate(enemy3, new Vector3(Random.Range(minX, maxX), positionY, 0), transform.rotation);
                }
                yield return new WaitForSeconds(enemyWait);
            }
        }
        Instantiate (boss3, boss3Spawn.position, boss3Spawn.rotation);//instantiate boss3
        bossHealthSlider.maxValue = 100;
        bossHealthSlider.value = 100;
        bossHealthSlider.gameObject.SetActive(true);
        boss3Alive = true;
		yield return new WaitUntil (() => !boss3Alive);
        bossHealthSlider.gameObject.SetActive(false);
        yield return new WaitForSeconds(4f);

        StopAllCoroutines();
        if (!GameOver) {
            GameWon = true;
        }
	}
	private IEnumerator PowerUpSpawner(){
		yield return new WaitForSeconds (30f);
		while(true){
			int which = Mathf.FloorToInt (Random.Range(0f, 3.99f));
			if (boss1Alive) {
				int which1 = Mathf.FloorToInt (Random.Range(0f, 1.99f));
				if (which1 == 0) {
					Instantiate (powerUps [which], new Vector2(Random.Range (boss1PosXMin1, boss1PosXMax1), positionY), powerUps[which].transform.rotation);
				} else {
					Instantiate (powerUps [which], new Vector2(Random.Range (boss1PosXMin2, boss1PosXMax2), positionY), powerUps[which].transform.rotation);
				}
			} else if (boss2Alive) {
				int which1 = Mathf.FloorToInt (Random.Range(0f, 1.99f));
				if (which1 == 0) {
					Instantiate (powerUps [which], new Vector2(Random.Range (boss2PosXMin1, boss2PosXMax1), positionY), powerUps[which].transform.rotation);
				} else {
					Instantiate (powerUps [which], new Vector2(Random.Range (boss2PosXMin2, boss2PosXMax2), positionY), powerUps[which].transform.rotation);
				}
			} else if (boss3Alive) {
				int which1 = Mathf.FloorToInt (Random.Range(0f, 1.99f));
				if (which1 == 0) {
					Instantiate (powerUps [which], new Vector2(Random.Range (boss3PosXMin1, boss3PosXMax1), positionY), powerUps[which].transform.rotation);
				} else {
					Instantiate (powerUps [which], new Vector2(Random.Range (boss3PosXMin2, boss3PosXMax2), positionY), powerUps[which].transform.rotation);
				}
			} else {
				Instantiate (powerUps [which], new Vector2(Random.Range (minX, maxX), positionY), powerUps[which].transform.rotation);
			}
			yield return new WaitForSeconds (30f);
		}
	}

	public void endGame(){
        GameOver = true;
        GameWon = false;
		StopAllCoroutines ();
        //audios[1].Stop();
        if (boss1Alive) {
            GameObject.FindGameObjectWithTag("Boss1").GetComponent<Boss1Script>().StopAttacking();
        } else if (boss2Alive) {
            GameObject.FindGameObjectWithTag("Boss2").GetComponent<Boss2Script>().StopAttacking();
        } else if (boss3Alive) {
            GameObject.FindGameObjectWithTag("Boss3").GetComponent<Boss3Script>().StopAttacking();
        }
	}
    public void restartGame() {
        GameOver = false;
        GameWon = false;
        boss1Alive = false;
        boss2Alive = false;
        boss3Alive = false;
        player.SetActive(true);
        StartCoroutine("Spawner");
        StartCoroutine("PowerUpSpawner");
        List<GameObject> objectsToBeRemoved = new List<GameObject>();
        objectsToBeRemoved.AddRange(GameObject.FindGameObjectsWithTag("Enemy Mine"));
        objectsToBeRemoved.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        objectsToBeRemoved.AddRange(GameObject.FindGameObjectsWithTag("Enemy Bolt"));

        foreach (GameObject objectToBeRemoved in objectsToBeRemoved) {
            Destroy(objectToBeRemoved);
        }

    }
	public void Boss1Destroyed(){
		boss1Alive = false;
	}
	public bool GetBoss1Destroyed(){
		return !boss1Alive;
	}
	public void Boss2Destroyed(){
		boss2Alive = false;
	}
	public bool GetBoss2Destroyed(){
		return !boss2Alive;
	}
	public void Boss3Destroyed(){
		boss3Alive = false;
	}
	public bool GetBoss3Destroyed(){
        return !boss3Alive;
        
    }
    public void ChangeBossHealth(float amount, float health) {
        StartCoroutine(BossHealthVisual(amount, health));
    }
    private IEnumerator BossHealthVisual(float amount, float health)
    {
        //if (amount > 0)// === IF I WANT THE BOSS TO REGENERATE HEALTH ===
        //{
        //    for (float f = health - amount; f < health; f += 0.05f)
        //    {
        //        bossHealthSlider.value = f;
        //        yield return new WaitForSeconds(0.01f);//,mebi shcange
        //    }
        //}
        //if (amount < 0)
        //{
        for (float f = health + amount * -1; f > health; f -= 0.1f)
        {
            bossHealthSlider.value = f;
            yield return new WaitForSeconds(0.01f);//change amybe if too fast
        }
        //}
    }
}
