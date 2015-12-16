using UnityEngine;
using System.Collections;

public class JustOne : MonoBehaviour {

	public void OnClick(){
		InstanceScript.Instance.justANumber += 1;
	}
}
