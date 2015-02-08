using UnityEngine;
using System.Collections;

public class FeuFollet : MonoBehaviour {

	public	bool	activate = true;
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
			transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0f);
		} 
		else
			Screen.showCursor = true;
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag != "Player")
			Destroy (gameObject);
	}
}
