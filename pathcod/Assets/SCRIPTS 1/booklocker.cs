using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class booklocker : MonoBehaviour, IPointerClickHandler {

	public enum bookS {none, chosen}
	public bookS bookstate{ get; set; }
	GameObject currentbook { get; set; }
	static GameObject previousbook { get; set; }
	private GameObject books;
	private Image previous;
	private Image current;
	public float num=0.5f;

	void Start(){
		books= GameObject.Find("bookpanel");
	}

	public void OnPointerClick(PointerEventData eventData) {
//	public void Interact(){
//		if (Input.GetMouseButtonDown(0)) {
			if (books.GetComponent<changebook> ().IsCompleted == true)
				return;
		
			if (previousbook == null) {	
				previousbook = this.gameObject;
				previousbook.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + num, this.transform.position.z);
			} else if (previousbook == this.gameObject) {
				previousbook.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y - num, this.transform.position.z);
				previousbook = null;
			} else {
				currentbook = this.gameObject;
				previous = previousbook.GetComponent<Image> ();
				changebook (GetComponent<Image> (), previous);
				previousbook.transform.position = new Vector3 (previousbook.transform.position.x, previousbook.transform.position.y - num, previousbook.transform.position.z);
				previousbook = null;
			}					
//		}
	}

	void changebook(Image firstSprite, Image secondSprite) {
		Sprite temp = firstSprite.sprite;
		firstSprite.sprite= secondSprite.sprite;
		secondSprite.sprite = temp;
	}
}
