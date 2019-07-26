using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {
	public GameObject paneleff;

	public void GameStart(){
		StartCoroutine (gamestart());
	}

	public void ExitGame(){
		Application.Quit ();
	}

	IEnumerator gamestart(){
		Instantiate (paneleff, GameObject.Find ("Canvas").transform);
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene (1);
	}

}
