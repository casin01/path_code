using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	[System.Serializable]
	public class Level {
		public string LevelText;
		public int UnLocked;
		public bool isInteractable;
	}

	public GameObject LevelButton;
	public Transform Spacer;
	public List<Level> LevelList;

	void Start () {
		FillList ();
	}
	
	void FillList(){
		foreach (var level in LevelList) {
			GameObject newbutton = Instantiate(LevelButton) as GameObject;	//newbutton=Button
			LevelButton button = newbutton.GetComponent <LevelButton>();
			button.LevelText.text = level.LevelText;

			if (PlayerPrefs.GetInt (button.LevelText.text)==1) {
				level.UnLocked = 1;
				level.isInteractable = true;
			}

			button.Unlocked = level.UnLocked;
			button.GetComponent<Button> ().interactable = level.isInteractable;
			button.GetComponent<Button> ().onClick.AddListener (() => LoadLevel (button.LevelText.text));

			newbutton.transform.SetParent (Spacer, false);
		}
		SaveAll (); 
	}

	void SaveAll(){
		GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton");
		foreach (GameObject buttons in allButtons) {
			LevelButton button = buttons.GetComponent<LevelButton> ();
			PlayerPrefs.SetInt (button.LevelText.text, button.Unlocked);
		}
	}

	public void DeleteAll(){
		PlayerPrefs.DeleteAll ();
	}

	void LoadLevel(string value){
		SceneManager.LoadScene (value);
	}
}
