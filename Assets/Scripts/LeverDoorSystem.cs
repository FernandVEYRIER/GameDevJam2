using UnityEngine;
using System.Collections;

public class LeverDoorSystem : MonoBehaviour {

	public GameObject door;	
	public KeyCode key;

	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKeyUp(key))
		{
			//change door state
			Debug.Log("Door");
		}
	}
}
