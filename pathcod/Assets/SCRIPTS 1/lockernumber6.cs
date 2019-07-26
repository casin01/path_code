using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockernumber6 : MonoBehaviour, Iinteractable {

	public void Interact(displayimage currentDisplay){
		transform.parent.GetComponent<numberlock6> ().currentIndividualIndex [transform.GetSiblingIndex ()]++;

		if (transform.parent.GetComponent<numberlock6> ().currentIndividualIndex [transform.GetSiblingIndex ()] > 9)
			transform.parent.GetComponent<numberlock6> ().currentIndividualIndex [transform.GetSiblingIndex ()] = 0;

		this.gameObject.GetComponent<SpriteRenderer> ().sprite =
			transform.parent.GetComponent<numberlock6> ().numberSprites [transform.parent.GetComponent<numberlock6> ().currentIndividualIndex [transform.GetSiblingIndex ()]];

	}
}
