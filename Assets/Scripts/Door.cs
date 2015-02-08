using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Sprite	spr;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			gameObject.GetComponent<SpriteRenderer> ().sprite = spr;
		}
	}
}
