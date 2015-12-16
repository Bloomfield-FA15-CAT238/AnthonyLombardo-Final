using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Guard : MonoBehaviour {
	private AIGuardStates state = AIGuardStates.Guarding;
	static private GameObject standingPoint = null;
	static private GameObject guardingPoint = null;

	#region Enemy Options
	public float walkingSpeed = 3.0f;
	public float standingSpeed = 0f;
	public float attackingSpeed = 3.0f;
	public float attackingDistance = 1.0f;
	#endregion
	
	private GameObject playerOfInterest;

	void Start () {
		if (standingPoint == null) 
			standingPoint = GameObject.FindGameObjectWithTag("StandingPoint");

		if (guardingPoint == null) 
			guardingPoint = GameObject.FindGameObjectWithTag("GuardPoint");
		
	}

	void Update(){
		switch (state) {
		case AIGuardStates.Guarding:
			OnGuardUpdate ();
			break;
		case AIGuardStates.Attacking:
			OnAttackUpdate ();
			break;
		case AIGuardStates.Standing:
			OnStandingUpdate();
			break;
		}
	}

	void OnGuardUpdate(){
		float step = (attackingSpeed * Time.deltaTime) * 10;
		transform.position = Vector3.MoveTowards (transform.position, guardingPoint.transform.position, step);
		GetComponent<Renderer>().material.color = new Color (0.0f, 1.0f, 0.0f);
		float distance = Vector3.Distance (transform.position, guardingPoint.transform.position);
		if (distance < .5)
			SwitchToStanding ();
	}

	void OnAttackUpdate(){
			float step = (attackingSpeed * Time.deltaTime) * 7;
			transform.position = Vector3.MoveTowards (transform.position, playerOfInterest.transform.position, step);
			GetComponent<Renderer> ().material.color = new Color (1.0f, 0.0f, 0.0f);
			float distance = Vector3.Distance (transform.position, playerOfInterest.transform.position);
			if (distance < 5)
				GameController.hp -= 1.0f;
			if (distance <= attackingDistance)
				SwitchToGuard ();
	}

	void OnStandingUpdate(){
		if (GameController.hasKey ){
			float step = (attackingSpeed * Time.deltaTime) * 5;
			transform.position = Vector3.MoveTowards (transform.position, standingPoint.transform.position, step);
			GetComponent<Renderer>().material.color = new Color (1.0f, 1.0f, 0.0f);
			float distance = Vector3.Distance (transform.position, standingPoint.transform.position);
			if (distance < .5)
				Destroy (this);
		}
	}

	void SwitchToGuard(){
		state = AIGuardStates.Guarding;
		playerOfInterest = null;
	}

	void SwitchToAttack(GameObject target){
		state = AIGuardStates.Attacking;
		playerOfInterest = target;
	}

	void SwitchToStanding(){
		state = AIGuardStates.Standing;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player" && !GameController.hasKey) 
			SwitchToAttack (other.gameObject);
		if (other.gameObject.tag == "Player" && GameController.hasKey)
			SwitchToStanding ();
	}
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player")
			SwitchToGuard ();
	}
}
