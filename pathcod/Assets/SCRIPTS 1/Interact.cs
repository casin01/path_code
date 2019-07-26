using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact : MonoBehaviour {

	private displayimage currentDisplay;

	void Start(){
		currentDisplay = GameObject.Find ("displayImage").GetComponent<displayimage> ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.IsPointerOverGameObject () == false) {
				Vector2 rayPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (rayPosition, Vector2.zero, 100);

				if (hit && hit.transform.tag == "interactable") {
					hit.transform.GetComponent<Iinteractable> ().Interact (currentDisplay);
				}
			}
		}
	}
}
