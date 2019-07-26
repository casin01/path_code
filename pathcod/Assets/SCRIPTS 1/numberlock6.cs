using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class numberlock6 : MonoBehaviour {

	public string Password;

	public GameObject OpenLockerSprite;
	private GameObject displayImage;

	[HideInInspector]
	public Sprite[] numberSprites;

	public int[] currentIndividualIndex={0, 0, 0, 0, 0, 0};

	private bool isOpen;

	void Start(){
		displayImage = GameObject.Find ("displayImage");
		OpenLockerSprite.SetActive (false);
		isOpen = false;
		LoadAllNumberSprites ();
	}

	void Update(){
		OpenLocker ();
	}

	void LoadAllNumberSprites(){
		numberSprites = Resources.LoadAll<Sprite> ("inventoryitem/number");
	}

	bool VerifyCorrectCode(){
		bool correct = true;

		for(int i=0;i<6;i++){
			if(Password[i]!= transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Substring(transform.GetChild(i).GetComponent<SpriteRenderer>().sprite.name.Length-1)[0]){
				correct=false;
			}
		}

		return correct;
	}

	void OpenLocker(){
		if (isOpen)
			return;

		if (VerifyCorrectCode ()) {
			isOpen = true;
			OpenLockerSprite.SetActive (true);

			for (int i = 0; i < 6; i++) {
				Destroy (transform.GetChild (i).gameObject);
			}
		}
	}

	void LayerManager(){
		if (isOpen)
			return;
		if (displayImage.GetComponent<displayimage> ().CurrentState == displayimage.State.normal) {
			foreach (Transform child in transform) {
				child.gameObject.layer = 2;
			}
		} else {
			foreach (Transform child in transform) {
				child.gameObject.layer = 0;
			}
		}
	}
}
