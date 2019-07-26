using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Laptop : MonoBehaviour, IPointerClickHandler {

	public GameObject EnterPassword;
	public GameObject trIgger;
	public GameObject login;
	private bool isCorrectPassword = false;
	private GameObject displayImage;

	public string CorrectPassword;
	private string inputPassword;

	void Start () {
		displayImage = GameObject.Find("displayImage");
	}

	void Update () {
//		VerifyPassword();
//		HideDisplay();
		if(displayImage.GetComponent<displayimage>().CurrentState == displayimage.State.normal) {
			this.gameObject.SetActive(false);
		}
	}

	public void VerifyPassword()  {
		if (isCorrectPassword) return;

	//	if ((Input.GetKey(KeyCode.Return))||(Input.GetMouseButtonDown(0))) {
			inputPassword = EnterPassword.transform.Find("Text").GetComponent<Text>().text;
			EnterPassword.transform.Find("Text").GetComponent<Text>().text = "";

			if (inputPassword == CorrectPassword) {
				isCorrectPassword = true;

				Destroy (gameObject);
				Destroy (trIgger);
				login.SetActive (true);
			}
//		}
	}

	public void HideDisplay() {
//		if(Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
			this.gameObject.SetActive(false);
//		}

//		if(displayImage.GetComponent<displayimage>().CurrentState == displayimage.State.normal) {
//			this.gameObject.SetActive(false);
//		}
	}

	public void OnPointerClick(PointerEventData eventData) {
		if (isCorrectPassword) return;
	}
}
