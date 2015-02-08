using UnityEngine;
using System.Collections;

public class LeverDoorSystem : MonoBehaviour {

	public GameObject []door;	
	public KeyCode key;

	public Sprite leverSpriteOff;
	public Sprite leverSpriteOn;

	bool canOpen = false;

	void Update()
	{
		if (canOpen && Input.GetKeyDown(key))
		{
			foreach (GameObject _door in door)
			{
				_door.GetComponent<Animator>().SetBool("isOpen", !_door.GetComponent<Animator>().GetBool("isOpen"));
				if (_door.GetComponent<Animator>().GetBool("isOpen"))
					this.GetComponent<SpriteRenderer>().sprite = leverSpriteOn;
				else
					this.GetComponent<SpriteRenderer>().sprite = leverSpriteOff;
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.collider2D.tag == "Player")
			canOpen = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.collider2D.tag == "Player")
			canOpen = true;
	}
}
