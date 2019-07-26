using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour, Iinteractable {

	public string DisplaySprite;
	public enum property {usable, displayable};

	public string DisplayImage;
//	public string CombinationItem;
	public property itemProperty;
	public GameObject dest;	//destroy

	private GameObject InventorySlots;

	public void Interact(displayimage currentDisplay){
		ItemPickUp ();
	}

	void Start(){
		InventorySlots = GameObject.Find ("Slots");
	}

	public void ItemPickUp(){
		foreach(Transform slot in InventorySlots.transform){
			if(slot.transform.GetChild(0).GetComponent<Image>().sprite.name=="empty"){
				slot.transform.GetChild (0).GetComponent<Image> ().sprite =
					Resources.Load<Sprite> ("inventoryitem/" + DisplaySprite);
				slot.GetComponent<Slot> ().AssignProperty ((int)itemProperty, DisplayImage);
				Destroy (gameObject);
				Destroy (dest);	//destroy
				break;
			}
		}
	}
}
