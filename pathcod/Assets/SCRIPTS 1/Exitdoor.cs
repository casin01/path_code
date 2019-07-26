using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exitdoor : MonoBehaviour, Iinteractable {

	public GameObject ChangedStateSprite;
	public string UnlockItem;

	public GameObject EscapeMessage;
	public GameObject panelscr;
	private GameObject inventory;
	private GameObject InventorySlots;

	void Start() {
		ChangedStateSprite.SetActive(false);
		inventory = GameObject.Find("Inventory");
//		InventorySlots = GameObject.Find ("Slots");
	}

	public void Interact(displayimage currentDisplay)
	{
		if (inventory.GetComponent<Inventory>().currentSelectedSlot.gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem || UnlockItem == "")
		{
			ChangedStateSprite.SetActive(true);           
			this.gameObject.layer = 1;

	/*		foreach (Transform slot in InventorySlots.transform) {
				if (slot.transform.GetChild (0).GetComponent<Image> ().sprite.name == ("hidden"+SceneManager.GetActiveScene().buildIndex)) {
					PlayerPrefs.SetInt (""+SceneManager.GetActiveScene ().buildIndex, 1);
					break;
				}
				else
					PlayerPrefs.SetInt (""+SceneManager.GetActiveScene ().buildIndex, 0);
			}
*/

			StartCoroutine (LoadMenu ());
		}

	}

	public IEnumerator LoadMenu(){
		Instantiate (EscapeMessage, GameObject.Find ("Canvas").transform);
		Instantiate (panelscr, GameObject.Find ("Canvas").transform);
		PlayerPrefs.SetInt ("Stage "+SceneManager.GetActiveScene ().buildIndex, 1);
		yield return new WaitForSeconds (5);
		if (SceneManager.GetActiveScene ().buildIndex == 4) {
			SceneManager.LoadScene (0);
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
}
