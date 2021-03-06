﻿using UnityEngine;
using System.Collections;

public class FeuFollet : MonoBehaviour {

	public	bool	activate = true;
	[HideInInspector]
	public bool	time = false;
	private bool	mouse = false;
	private Vector3 save;
	Vector3 vel;
	void Start ()
	{
		Screen.showCursor = false;
		save = transform.position;
	}
	

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && time == true)
		{
			time = false;
			activate = false;
			mouse = false;
		}
		if (GameObject.Find("SpawLum") == null)
			return;
		if (activate == true)
		{
			if (transform.position == GameObject.Find("SpawLum").transform.position && time == false && mouse == true)
				time = true;
			SpawPos();
		} 
		else
		{
			Screen.showCursor = true;
			initpos();
		}
		if (time == true)
		{
			transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0f);
		}
	}

	public void initpos()
	{
		transform.position = Vector3.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint(new Vector3(40, Screen.height - 40, 0)), 0.1f);
	}

	public void SpawPos()
	{
		transform.position = Vector3.MoveTowards (transform.position, GameObject.Find("SpawLum").transform.position, 0.1f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Ground" && activate == true)
		{
			time = false;
			activate = true;
			mouse = false;
			transform.position = GameObject.Find("SpawLum").transform.position;
			Camera.main.transform.position =  new Vector3 (transform.position.x, transform.position.y, Camera.main.transform.position.z);
		}
	}

	void OnMouseEnter()
	{
		mouse = true;
	}
}
