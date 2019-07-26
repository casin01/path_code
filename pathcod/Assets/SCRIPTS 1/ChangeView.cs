using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeView : MonoBehaviour, Iinteractable {

	public string SpriteName;

	public void Interact(displayimage currentDisplay){
		currentDisplay.GetComponent<SpriteRenderer> ().sprite =
			Resources.Load<Sprite> ("Sprites"+ SceneManager.GetActiveScene().buildIndex + "/" + SpriteName);
		currentDisplay.CurrentState = displayimage.State.ChangedView;
	}
}
