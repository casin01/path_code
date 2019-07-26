using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class changebook : MonoBehaviour {
	public bool IsCompleted { get; private set; }
	public string Password;

	private bool itemSpawn;
	public GameObject ClaimItem;
	public GameObject arrow;
	public GameObject skybok;
	private GameObject displayImage;
	public GameObject ChangedStateSprite;

	void Start()
	{
		itemSpawn = false;
		displayImage = GameObject.Find("displayImage");
	}

	void Update()
	{
		if (CompletePuzzle() && !itemSpawn)
		{
//			var claimItem = Instantiate(ClaimItem, GameObject.Find("bookpanel").transform, false);
//			claimItem.transform.localScale = new Vector3 (0.34f, 2.20f, 1);
			ChangedStateSprite.SetActive(true);           
			this.gameObject.layer = 1;
			ClaimItem.SetActive (true);
			skybok.SetActive (true);
			arrow.SetActive (true);
			itemSpawn = true;
			Destroy (GameObject.Find ("bookk"));
		}

		if(displayImage.GetComponent<displayimage>().CurrentState == displayimage.State.normal) {
			this.gameObject.SetActive(false);
		}
	}

	public void HideDisplay()
	{

//		if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
//		{
			this.gameObject.SetActive(false);
//		}

		if(displayImage.GetComponent<displayimage>().CurrentState == displayimage.State.normal) {
			this.gameObject.SetActive(false);
		}
	}

	bool CompletePuzzle() {
		if (IsCompleted) return true;

		IsCompleted = true;

		for (int i = 1; i < 5; i++) {
//			Debug.Log (transform.GetChild(i).GetComponent<Image>().sprite.name.Substring(transform.GetChild(i).GetComponent<Image>().sprite.name.Length-1)[0]);
			if (Password [i] !=  transform.GetChild(i).GetComponent<Image>().sprite.name.Substring(transform.GetChild(i).GetComponent<Image>().sprite.name.Length-1)[0]) {	
				IsCompleted=false;
			}
		}
		
		return IsCompleted;
	}
}