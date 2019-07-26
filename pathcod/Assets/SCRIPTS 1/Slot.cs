using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler {
	private GameObject inventory;

	public enum property {usable, displayable, empty};
	public property ItemProperty{ get; set; }

	private string displayimage;
//	public string combinationItem{ get;private set;}

	void Start(){
		inventory = GameObject.Find ("Inventory");
	}

	public void OnPointerClick(PointerEventData eventData){
//		inventory.GetComponent<Inventory> ().previousSelectedSlot = inventory.GetComponent<Inventory> ().currentSelectedSlot;
		inventory.GetComponent<Inventory> ().currentSelectedSlot = this.gameObject;
//		if(this.gameObject.GetComponent<Slot>().combinationItem!= ".")
//			Combine ();
	}

	public void AssignProperty(int orderNumber, string displayimage){
		ItemProperty = (property)orderNumber;
		this.displayimage = displayimage;
	}

	public void DisplayItem(){
		inventory.GetComponent<Inventory> ().itemDisplayer.SetActive (true);
		inventory.GetComponent<Inventory> ().itemDisplayer.GetComponent<Image>().sprite=
			Resources.Load<Sprite>("inventoryitem/"+displayimage);
	}

/*	void Combine() {
		if(inventory.GetComponent<Inventory>().previousSelectedSlot.GetComponent<Slot>().combinationItem
			== this.gameObject.GetComponent<Slot>().combinationItem && (this.gameObject.GetComponent<Slot>().combinationItem!= ".")) {

			GameObject combinedItem = Instantiate(Resources.Load<GameObject>("Combined Items/" + combinationItem));
			combinedItem.GetComponent<PickUpItem>().ItemPickUp();

			inventory.GetComponent<Inventory>().previousSelectedSlot.GetComponent<Slot>().ClearSlot();
			ClearSlot();
		}
	}*/

	public void ClearSlot() {
		ItemProperty = Slot.property.empty;
		displayimage = "";
//		combinationItem = "";
		transform.GetChild(0).GetComponent<Image>().sprite =  Resources.Load<Sprite>("inventoryitem/empty");
	}
}
