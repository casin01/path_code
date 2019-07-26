using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonbehavior : MonoBehaviour {

	public enum Buttonid{
		roomChange, retunn
	}

	public Buttonid thisButtonid;

	private displayimage currentDisplay;

	void Start(){
		currentDisplay = GameObject.Find ("displayImage").GetComponent<displayimage> ();
	}

	void Update(){
		hidedisplay ();
		Display ();
	}

	void hidedisplay(){
		if (currentDisplay.CurrentState == displayimage.State.normal && thisButtonid == Buttonid.retunn) {
			GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, 
				GetComponent<Image> ().color.b, 0);
			GetComponent<Button> ().enabled = false;
			this.transform.SetSiblingIndex (0);
		}

		if (!(currentDisplay.CurrentState == displayimage.State.normal) && thisButtonid == Buttonid.roomChange) {
			GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, 
				GetComponent<Image> ().color.b, 0);
			GetComponent<Button> ().enabled = false;
			this.transform.SetSiblingIndex (0);
		}
	}

	void Display(){
		if (!(currentDisplay.CurrentState == displayimage.State.normal) && thisButtonid == Buttonid.retunn) {
			GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, 
				GetComponent<Image> ().color.b, 1);
			GetComponent<Button> ().enabled = true;
		}

		if (currentDisplay.CurrentState == displayimage.State.normal && thisButtonid == Buttonid.roomChange) {
			GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, GetComponent<Image> ().color.g, 
				GetComponent<Image> ().color.b, 1);
			GetComponent<Button> ().enabled = true;
		}
	}
}
