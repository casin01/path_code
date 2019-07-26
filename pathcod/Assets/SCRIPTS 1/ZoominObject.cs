﻿using UnityEngine;
using System.Collections;

public class ZoominObject:MonoBehaviour, Iinteractable {
	public float ZoomRatio = .5f;

	public void Interact(displayimage currentDisplay){
		Camera.main.orthographicSize *= ZoomRatio;
		Camera.main.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y,
			Camera.main.transform.position.z);
		gameObject.layer = 2;
		currentDisplay.CurrentState = displayimage.State.zoom;

		ConstrainCamera ();
	}

	void ConstrainCamera(){
		var height = Camera.main.orthographicSize;
		var width = height * Camera.main.aspect;

		var cameraBounds = GameObject.Find ("cameraBounds");

		if (Camera.main.transform.position.x + width > cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D> ().size.x / 2) {			
			Camera.main.transform.position += new Vector3 (cameraBounds.transform.position.x + cameraBounds.GetComponent<BoxCollider2D> ().size.x / 2 -
				(Camera.main.transform.position.x + width), 0, 0);
		}

		if (Camera.main.transform.position.x - width < cameraBounds.transform.position.x - cameraBounds.GetComponent<BoxCollider2D> ().size.x / 2) {
			Camera.main.transform.position += new Vector3 (cameraBounds.transform.position.x - cameraBounds.GetComponent<BoxCollider2D> ().size.x / 2 -
				(Camera.main.transform.position.x - width), 0, 0);
		}

		if (Camera.main.transform.position.y + height > cameraBounds.transform.position.y + cameraBounds.GetComponent<BoxCollider2D> ().size.y / 2) {
			Camera.main.transform.position += new Vector3 (0, cameraBounds.transform.position.y + cameraBounds.GetComponent<BoxCollider2D> ().size.y / 2 -
				(Camera.main.transform.position.y + height), 0);
		}

		if (Camera.main.transform.position.y - height < cameraBounds.transform.position.y - cameraBounds.GetComponent<BoxCollider2D> ().size.y / 2) {
			Camera.main.transform.position += new Vector3 (0, cameraBounds.transform.position.y - cameraBounds.GetComponent<BoxCollider2D> ().size.y / 2 -
				(Camera.main.transform.position.y - height), 0);
		}
	}
}

