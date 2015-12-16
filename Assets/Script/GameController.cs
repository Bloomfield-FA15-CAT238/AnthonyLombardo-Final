using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Transform spawnpoint;
	public GameObject player;
	GameObject controlledPlayer;
	public GameObject table;
	public Text health;
	public Text textPoints;
	public Text help;
	public Button Respawn;
	public static bool hasKey = false;
	public static bool isAlive = true;
	public Text number;
	int num;


	public static float hp;
	public static int points = 0;

	void Start (){
		hp = 100;
		Respawn.gameObject.SetActive (false);
		Instantiate (player, spawnpoint.position, Quaternion.identity);
		if (controlledPlayer == null) {
			controlledPlayer = GameObject.FindGameObjectWithTag("Player");
		}
	}

	void Update() {
		textPoints.text = "Points: " + points;
		HealthHandler ();
		num = InstanceScript.Instance.justANumber;
		number.text = "Number: " + num;
	}

	void HealthHandler(){
		if (hp > 0) {
			health.text = "Health : " + (int)hp + "%";
		}
		if (hp < 0) {
			hp = 0;
			health.text = "Dead";
			isAlive = false;
			help.enabled = true;
			help.text = "You are Dead";
			Respawn.gameObject.SetActive (true);
			controlledPlayer.GetComponent<Collider>().enabled = false;

		}
	}

	void RespawnPlayer() {
		Application.LoadLevel ("Game");
	}

	public void OnClick (){
		RespawnPlayer ();
	}
}
