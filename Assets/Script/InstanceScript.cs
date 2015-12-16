using UnityEngine;
using System.Collections;

public class InstanceScript : MonoBehaviour {
	public int justANumber;
	private static InstanceScript instance;
	public static InstanceScript Instance {
		set{
			instance = value;
		}get{
			if (!instance){
				GameObject singleton = new GameObject();
				instance = singleton.AddComponent<InstanceScript>();
			}
			return instance;
		}
	}
}
