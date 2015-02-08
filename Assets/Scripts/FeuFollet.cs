using UnityEngine;
using System.Collections;

public class FeuFollet : MonoBehaviour {

	public	bool	activate = true;
	[HideInInspector]
	public bool	time = false;
	private bool	time1 = false;
	private bool	mouse = false;
	//public Transform lum;
	private Vector3 save;
	// Use this for initialization
	void Start ()
	{
		save = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (activate == true)
		{
			Screen.showCursor = false;
			if (transform.position == GameObject.Find("SpawLum").transform.position && time == false && mouse == true)
				time = true;
			SpawPos();
		} 
		else
		{
			Screen.showCursor = true;
			time1 =false;
			initpos();
		}
		if (time == true)
		{
			transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0f);
			//transform.position = Vector3.MoveTowards (transform.position, lum.position, 0.1f);
		}
	}
	public void initpos()
	{
		transform.position = Vector3.MoveTowards (transform.position, Camera.main.ScreenToWorldPoint(new Vector3(40, Screen.height - 40, 1)), 0.1f);
	}
	public void SpawPos()
	{
		transform.position = Vector3.MoveTowards (transform.position, GameObject.Find("SpawLum").transform.position, 0.1f);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("collision");
		if (col.tag != "Player" && activate == true)
		{
			time = false;
			activate = true;
			mouse = false;
			transform.position = GameObject.Find("SpawLum").transform.position;
		}
	}
	void OnMouseEnter()
	{
		mouse = true;
	}
	IEnumerator		timer()
	{
		time = false;
		yield return new WaitForSeconds (1);
		time = true;
	}
}
