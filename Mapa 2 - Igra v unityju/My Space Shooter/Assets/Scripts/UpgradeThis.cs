using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpgradeThis : MonoBehaviour {
	public float sC, hC, fRC, hRC, eDC;

	private SurvivalGameController survivalGameController;
	public PlayerController playerController;

	private int speed, health, fireRate = 0;

	public Text[] texts;
	public Image[] images;
	public Slider[] sliders;
	public Button[] buttons;

	private int[] values = new int[5];
	private GameManager gameManager;

	public Text upgradeScoreDisplay;
	public Text scoreDisplay;

	public DestroyByBoundary dbb;

	// Use this for initialization
	void Start () {
		survivalGameController = GameObject.FindGameObjectWithTag ("SurvivalGameController").GetComponent<SurvivalGameController>();
		gameManager = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<GameManager>();
		texts [0].text = "" + sC;
		texts [1].text = "" + fRC;
		texts [2].text = "" + hC;
		texts [3].text = "" + hRC;
		texts [4].text = "" + eDC;
	}
	
	// Update is called once per frame
	void Update () {
		scoreDisplay.text = "";//do it a more cleaner way pleasse
		if(gameManager.upgradeMenu.activeInHierarchy){
			upgradeScoreDisplay.text = "Points avaliable to spend: " + survivalGameController.GetScore();
			//spodi nucm se plus helpmenupause plus optionsmenupause
		}else if(!gameManager.mainMenu.activeInHierarchy && !gameManager.GetP() && !gameManager.pauseMenu.activeInHierarchy && !gameManager.optionsMenu.activeInHierarchy && !gameManager.helpMenu.activeInHierarchy && survivalGameController.survival){
			scoreDisplay.text = "Score: " + survivalGameController.GetScore();
		}
		foreach(var v in texts){
			try{//was giving me errors cuz i had ~nan before
				int x = Convert.ToInt16 (v.text);
			}catch(Exception e){
				if(v.text == ""){
					//could do it a little fancier I guess 
				}
				continue;
			}
			if (Convert.ToInt16 (v.text) <= survivalGameController.GetScore()) {
				v.color = Color.green;
			} else {
				v.color = Color.red;
			}
		}
	}
	public void upgradeSpeed(){
		if(survivalGameController.GetScore() >= sC){
			speed++;
			survivalGameController.AddScore (sC*-1);
			sC += sC / 2;
			texts[0].text = "" + sC;
			playerController.MovementSpeedChange ();//Maybe i could add a freeze powerup - or bad one or something that speeds up everything else ands slows down the player
			StartCoroutine (SliderChange(sliders[0], 0));
		}
		if(speed >= 3){
			texts[0].text = "";
			buttons [0].gameObject.SetActive (false);//can we destroy it?
			images [0].gameObject.SetActive(true);
		}
	}
	public void upgradeFireRate(){
		if(survivalGameController.GetScore() >= fRC){
			fireRate++;
			survivalGameController.AddScore (fRC*-1);
			fRC += fRC / 2;
			texts[1].text = "" + fRC;
			playerController.FireRateChange ();
			StartCoroutine (SliderChange(sliders[1], 1));
		}
		if(fireRate >= 5){
			texts[1].text = "";
			buttons [1].gameObject.SetActive (false);
			images [1].gameObject.SetActive(true);
		}
	}
	public void upgradeHealth(){
		if(survivalGameController.GetScore() >= hC){
			if(playerController.sliderVisualChange.healthSlider.value > 4.5f){//is this how i want it to be? maybe i want it to actually add an extra life bar
				return;//maybe >=5 i guess
			}
			health++;
			survivalGameController.AddScore (hC*-1);
			hC+= hC/ 2;
			texts[2].text = "" + hC;
			playerController.ChangeHealth (1);
			StartCoroutine (SliderChange(sliders[2], 2));
		}
		if(health >= 5){
			texts[2].text = "";
			buttons [2].gameObject.SetActive (false);
			images [2].gameObject.SetActive(true);
		}
	}
	public void upgradeHullReinforcement(){
		if(survivalGameController.GetScore() >= hRC){
			texts[3].text = "";
			dbb.HullReinforced ();
			StartCoroutine (SliderChange(sliders[3], 3));
			buttons [3].gameObject.SetActive (false);
			images [3].gameObject.SetActive(true);
		}
	}
	public void upgradeEnemyDamage(){
		if(survivalGameController.GetScore() >= eDC){
			texts[4].text = "";
			playerController.EnemyDamage ();
			StartCoroutine (SliderChange(sliders[4], 4));
			buttons [4].gameObject.SetActive (false);
			images [4].gameObject.SetActive(true);
		}
	}
	private IEnumerator SliderChange(Slider s, int index){
		values[index] += 1;
		for(float f = s.value; f < values[index]; f+= 0.05f){
			s.value = f;
			yield return new WaitForSecondsRealtime (0.01f);
		}
	}

    public class Vector2 {
        public float X{get; set;}
        public float Y { get; set; }
        public float Magnitude { get; set; }
        public double Angle { get; set; }

        public Vector2() { }
        public Vector2(float x, float y) {
            X = x;
            Y = y;
        }
        public Vector2(float magnitude, double angle) {
            Magnitude = magnitude;
            Angle = angle;
        }

        public Vector2 Sum(Vector2 vector) {
            Vector2 vectorSum = new Vector2();
            vectorSum.X = X + vector.X;
            vectorSum.Y = Y + vector.Y;

            vectorSum.Magnitude = Mathf.Sqrt(Mathf.Pow(vectorSum.X,2) + Mathf.Pow(vectorSum.Y, 2));
            vectorSum.Angle = Mathf.Atan(vectorSum.Y / vectorSum.Y);

            return vectorSum;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b) {
            Vector2 vectorSum = new Vector2();
            vectorSum.X = a.X + b.X;
            vectorSum.Y = a.Y + b.Y;

            vectorSum.Magnitude = Mathf.Sqrt(Mathf.Pow(vectorSum.X, 2) + Mathf.Pow(vectorSum.Y, 2));
            vectorSum.Angle = Mathf.Atan(vectorSum.Y / vectorSum.Y);

            return vectorSum;
        }
    }
}