using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class displayimage : MonoBehaviour {

	public enum State
	{
		normal, zoom, ChangedView
	};

	public State CurrentState{ get; set; }

	public int CurrentWall {
		get { return currentWall; }
		set {
			if((SceneManager.GetActiveScene().buildIndex==2)||(SceneManager.GetActiveScene().buildIndex==3)){
				if (value == 4)
					currentWall = 1;
				else if (value == 0)
					currentWall = 3;
				else
					currentWall = value;
			}

			else{
			if (value == 5)
				currentWall = 1;
			else if (value == 0)
				currentWall = 4;
			else
				currentWall = value;
			}
		}
	}

	private int currentWall;
	private int previousWall;

//	void Awake(){
//		Screen.SetResolution (990, 512, true);
//	}

	void Start(){
		previousWall = 0;
		currentWall = 1;
	}

	void Update(){
		if (currentWall != previousWall) {
			GetComponent<SpriteRenderer> ().sprite 
				= Resources.Load<Sprite> ("Sprites"+SceneManager.GetActiveScene().buildIndex +"/map" + currentWall.ToString ());
		}

		previousWall = currentWall;
	}
}
