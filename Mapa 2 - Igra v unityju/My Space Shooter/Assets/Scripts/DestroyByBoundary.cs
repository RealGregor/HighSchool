using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {
	public PlayerController playerController;
	private SurvivalGameController sgc;
	private float hullReinforcement;

	private float playerHealth = 5f;
	// Use this for initialization
	void Start () {
		sgc = GameObject.FindGameObjectWithTag ("SurvivalGameController").GetComponent<SurvivalGameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("Enemy") || other.CompareTag("Bolt") || other.CompareTag("Enemy Bolt")){
			//if enemy, take a life
			if(other.CompareTag("Enemy") && other.gameObject.transform.position.y <= -5){
				if(playerController == null && playerHealth > 0f){
					playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>();
				}
				if(playerController != null){
					playerHealth = playerController.GetHealth() - 1 + hullReinforcement;
					playerController.ChangeHealth (-1 + hullReinforcement);
				}
				sgc.AddScore (-20);
			}
			Destroy (other.gameObject);
		}
	}
	public void HullReinforced(){
		hullReinforcement = 0.5f;
	}
}
