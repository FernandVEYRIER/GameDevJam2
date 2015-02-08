using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	GameObject player;
	Vector3 vel;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
			return;
		}
		this.transform.position = Vector3.SmoothDamp(this.transform.position, player.transform.position + new Vector3(0, 0, -10), ref vel, 0.25f);
		//this.transform.position = player.transform.position + new Vector3(0, 0, -10);
	}
}
