using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Trigger : MonoBehaviour {
	public Text help;
	public GameObject key;
	public Light spotlight;

	void Start(){
		help.enabled = false;
	}

	void OnTriggerStay (Collider other){
	if (GameController.hasKey == false) {
			if (other.gameObject.name == "FPSController(Clone)") {
				help.enabled = true;
				help.text = "Press E to pick up";
				if (Input.GetKeyDown (KeyCode.E)) {
					Destroy (key);
					Destroy (spotlight);
					GameController.hasKey = true;
					GameController.points += 100;
				}
			}
		}
		if (GameController.hasKey == true)
			help.enabled = false;
	}
	void OnTriggerExit (){
	if (help.enabled == true)
		help.enabled = false;
	}
}
