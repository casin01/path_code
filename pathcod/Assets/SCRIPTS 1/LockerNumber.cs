using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerNumber : MonoBehaviour, Iinteractable {

	public void Interact(displayimage currentDisplay){
		transform.parent.GetComponent<NumberLock> ().currentIndividualIndex [transform.GetSiblingIndex ()]++;

		if (transform.parent.GetComponent<NumberLock> ().currentIndividualIndex [transform.GetSiblingIndex ()] > 9)
			transform.parent.GetComponent<NumberLock> ().currentIndividualIndex [transform.GetSiblingIndex ()] = 0;

		this.gameObject.GetComponent<SpriteRenderer> ().sprite =
			transform.parent.GetComponent<NumberLock> ().numberSprites [transform.parent.GetComponent<NumberLock> ().currentIndividualIndex [transform.GetSiblingIndex ()]];
			
	}
}
