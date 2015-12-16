using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WellTrigger : MonoBehaviour {
	public GameObject Water;
	public Text help;

	void Update (){
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			help.enabled = true;
			help.text = "Press 'E' to heal";
			if (Input.GetKeyDown (KeyCode.E) && GameController.hp < 200)
				GameController.hp += 10;

			if (GameController.hp >= 200)
				help.text = "You have enought Health";
		}
	}
	void OnTriggerExit(){
		help.enabled = false;
	}

}
