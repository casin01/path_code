using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {

	private displayimage currentDisplay;

	private float initialCameraSize;
	private Vector3 initialCameraPosition;

	void Start(){
		currentDisplay = GameObject.Find ("displayImage").GetComponent<displayimage> ();
		initialCameraSize = Camera.main.orthographicSize;
		initialCameraPosition = Camera.main.transform.position;
	}

	public void OnRightClickArrow(){
		currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;
	}

	public void OnLeftClickArrow(){
		currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;
	}

	public void OnClickReturn(){
		if (currentDisplay.CurrentState == displayimage.State.zoom) {
			GameObject.Find ("displayImage").GetComponent<displayimage> ().CurrentState = displayimage.State.normal;
			var zoomInObjects = FindObjectsOfType<ZoominObject> ();
			foreach (var zoomInObject in zoomInObjects) {
				zoomInObject.gameObject.layer = 0;
			}

			Camera.main.orthographicSize = initialCameraSize;
			Camera.main.transform.position = initialCameraPosition;
		} else {
			currentDisplay.GetComponent<SpriteRenderer> ().sprite
				= Resources.Load<Sprite> ("Sprites"+ SceneManager.GetActiveScene().buildIndex +"/map" + currentDisplay.CurrentWall);
			currentDisplay.CurrentState = displayimage.State.normal;
		}
	}
}
