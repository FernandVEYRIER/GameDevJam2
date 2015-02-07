using UnityEngine;
using System.Collections;

public class LeverDoorSystem : MonoBehaviour {

	public GameObject door;	
	public KeyCode key;

	public Sprite leverSpriteOff;
	public Sprite leverSpriteOn;

	bool canOpen;

	void Update()
	{
		if (canOpen && Input.GetKeyDown(key))
		{
			door.GetComponent<Animator>().SetBool("isOpen", !door.GetComponent<Animator>().GetBool("isOpen"));
			if (door.GetComponent<Animator>().GetBool("isOpen"))
				this.GetComponent<SpriteRenderer>().sprite = leverSpriteOn;
			else
				this.GetComponent<SpriteRenderer>().sprite = leverSpriteOff;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		canOpen = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		canOpen = true;
	}
}
