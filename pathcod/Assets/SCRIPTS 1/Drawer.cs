using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour, Iinteractable {

	public string UnlockItem;

	private GameObject inventory;

	public GameObject unlockcre;
	public GameObject unlockdes;

	void Start () {
		inventory = GameObject.Find ("Inventory");
		unlockcre.SetActive (false);
		unlockdes.SetActive (true);
	}
	
	public void Interact(displayimage currentDisplay){
		if (inventory.GetComponent<Inventory> ().currentSelectedSlot.gameObject.transform.GetChild (0).GetComponent<Image> ().sprite.name == UnlockItem) {
			unlockcre.SetActive (true);
			unlockdes.SetActive (false);
			inventory.GetComponent<Inventory> ().currentSelectedSlot.GetComponent<Slot> ().ItemProperty = Slot.property.empty;
			inventory.GetComponent<Inventory> ().currentSelectedSlot.gameObject.transform.GetChild (0).GetComponent<Image> ().sprite =
				Resources.Load<Sprite> ("inventoryitem/empty");
		}
	}
}
