using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject pauseMenu;
	public GameObject mainMenu;
	public GameObject upgradeMenu;
	public GameObject optionsMenu;
	public GameObject helpMenu;
    public GameObject gameOverMenu;
    public GameObject gameWonMenu;

    public GameObject restartButton;

    public GameController gameController;
    private SurvivalGameController survivalGameController;
    //plus optionsmenupause and helpmenupause

    public GameObject player;

	public AudioSource[] audios;

	

	private bool pause = false;
	private bool upgrade = false;
    bool canRestart = false;

	// Use this for initialization
	void Start () {
		survivalGameController = GameObject.FindGameObjectWithTag ("SurvivalGameController").GetComponent<SurvivalGameController> ();
    }
    

	// Update is called once per frame
	void Update () {
        if (gameController.GameWon) { gameWonMenu.SetActive(true); return; }
        if ((gameController.GameOver || SurvivalGameController.GameOver) && Input.GetKeyDown(KeyCode.R) && canRestart) {
            if (survivalGameController.survival){
                survivalGameController.RestartGame();
            }
            else{
                gameController.restartGame();
            }
            gameOverMenu.SetActive(false);
            return;
        }
        if (gameController.GameOver || SurvivalGameController.GameOver) {
            if (gameOverMenu.activeInHierarchy) {
                return;
            }
            canRestart = false;
            StartCoroutine(Restart());
            gameOverMenu.SetActive(true);
            return;
        }
		if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown (KeyCode.Escape)) && !pause && !upgrade && !mainMenu.activeInHierarchy && !upgradeMenu.activeInHierarchy && !optionsMenu.activeInHierarchy && !helpMenu.activeInHierarchy) {
			pauseMenu.SetActive (true);
			Time.timeScale = 0;
			pause = true;
			audios[0].Pause ();
			audios[1].UnPause ();
		} else if((Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Escape)) && pauseMenu.activeInHierarchy){
			pauseMenu.SetActive (false);
			Time.timeScale = 1;
			pause = false;
			audios[1].Pause ();
			audios[0].UnPause ();//the !pause below is accidentally genius
		}else if(Input.GetKeyDown (KeyCode.U) && survivalGameController.survival && !pause && !mainMenu.activeInHierarchy && !upgradeMenu.activeInHierarchy && !optionsMenu.activeInHierarchy && !helpMenu.activeInHierarchy){
			upgradeMenu.SetActive (true);
			Time.timeScale = 0;
			upgrade = true;
			audios[0].Pause ();
			audios[1].UnPause ();
		}else if((Input.GetKeyDown (KeyCode.U) || Input.GetKeyDown (KeyCode.Escape)) && upgradeMenu.activeInHierarchy){
			upgradeMenu.SetActive (false);
			Time.timeScale = 1;
			upgrade = false;
			audios[1].Pause ();
			audios[0].UnPause ();
		}
	}

    /// <summary>
    /// Ends the game and loads main scene 
    /// </summary>
	public void End(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("Main");
	}
    /// <summary>
    /// Sets the scaled time back to 1(unpause the game)
    /// </summary>
	public void Continue(){
		Time.timeScale = 1;
		pause = false;
		upgrade = false;
		audios[1].Pause ();
		audios[0].UnPause ();
	}

    /// <summary>
    /// Sets the game over menu active
    /// </summary>
    public void SetGameOverMenuActive() {
        gameOverMenu.SetActive(true);
    }
    /// <summary>
    /// Get information whether the game is paused or not
    /// </summary>
    /// <returns>pause</returns>
	public bool GetP(){
		return pause;
	}
    private IEnumerator Restart() {
        restartButton.SetActive(false);
        yield return new WaitForSeconds(2f);
        canRestart = true;
        restartButton.SetActive(true);
    }
    public void ExitApplication() {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
