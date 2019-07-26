using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Books : MonoBehaviour {
	public RaycastHit2D [] names;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D Hit=Physics2D.Raycast (ray.origin, ray.direction * 10);;

			if(Hit){
				Debug.Log (Hit.collider.gameObject.name);
			}		
		}
	}
}

/*	public enum bookS {none, chosen}

	public bookS bookstate{ get; set; }

	public GameObject currentbook { get; set; }
	public GameObject previousbook { get; set; }

	private GameObject Boook;

	private Sprite Csprite, Psprite;

	public void Start()	{
		Boook = GameObject.Find ("books");
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (Boook.GetComponent<changebook>().IsCompleted == true)
			return;
		else{
			previousbook = this.gameObject;
			previousbook.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y+10, this.transform.position.z);
			currentbook = this.gameObject;
			currentbook.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y+10, this.transform.position.z);
			Psprite = previousbook.GetComponent<Sprite>();
			Csprite = currentbook.GetComponent<Sprite>();
			ChangeSprites(Csprite, Psprite);
		}
	}

	void ChangeSprites(Sprite firstSprite, Sprite secondSprite) {
		Sprite temp = firstSprite;
		firstSprite= secondSprite;
		secondSprite = temp;
	}*/
