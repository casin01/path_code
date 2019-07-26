using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplayer : MonoBehaviour, Iinteractable {

	public GameObject DisplayObject;

	public void Interact(displayimage currentDisplay)
	{
		DisplayObject.SetActive(true);
	}
}
