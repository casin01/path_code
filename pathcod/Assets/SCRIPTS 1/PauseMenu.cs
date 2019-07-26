using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameisPaused=false;
	public GameObject pauseMenuUI;

	public void Resume (){
		pauseMenuUI.SetActive (false); 
		Time.timeScale = 1f;
		GameisPaused = false;
	}

	public void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameisPaused = true;
	}

	public void LoadMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("menu");
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
