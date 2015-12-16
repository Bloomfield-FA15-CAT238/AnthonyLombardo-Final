using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void OnClickStart () {
		Application.LoadLevel(Application.loadedLevel +1);
	}

	public void OnClickExit (){
		Application.Quit();
	}
}
