﻿using UnityEngine;
using System.Collections;

public class LeverBlue : MonoBehaviour {
	
	public Sprite	levier_on;
	public Sprite	levier_off;
	public GameObject	luciole;
	private bool	activate = false;
	private GameObject obj = null;
	private bool		pos = false;
	void Update()
	{
		if (activate)
		{
			if (obj == null)
				obj = (GameObject)Instantiate(luciole, transform.position, transform.rotation);
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player" && Input.GetKeyDown (KeyCode.E))
		{
			activate = !activate;
		}
		if (activate)
			gameObject.GetComponent<SpriteRenderer> ().sprite = levier_on;
		else
			gameObject.GetComponent<SpriteRenderer> ().sprite = levier_off;
	}
}
