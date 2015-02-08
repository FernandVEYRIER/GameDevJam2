using UnityEngine;
using System.Collections;

public class FollowActive : MonoBehaviour {
	
	public string[] players;
	private int			index = 0;
	private GameObject	player;
	Vector3 vel;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag(players [index]);
	}

	// Update is called once per frame
	void Update () 
	{
		//player = GameObject.FindGameObjectWithTag(players[index]);
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (GameObject.FindGameObjectWithTag("Feufollet") != null)
				index++;
			if (index >= players.Length)
				index = 0;
			//if (players[index] != null)
			player = GameObject.FindGameObjectWithTag(players[index]);
			if (GameObject.FindGameObjectWithTag("Feufollet") != null && player.name == "shotBub(Clone)" && Input.GetKeyDown(KeyCode.Tab))
			{
				player.collider2D.GetComponent<FeuFollet>().activate = true;
			}
			else if (GameObject.FindGameObjectWithTag("Feufollet") != null)
				GameObject.FindGameObjectWithTag("Feufollet").GetComponent<FeuFollet>().activate = false;
		}
		//if (player == null)
		//	return;
		if (player != GameObject.FindGameObjectWithTag("Feufollet"))
			this.transform.position = Vector3.SmoothDamp(this.transform.position, player.transform.position + new Vector3(0, 0, -10), ref vel, 0.25f);
		if (player == GameObject.FindGameObjectWithTag("Feufollet") && player.GetComponent<FeuFollet>().time == true)
			this.transform.position = Vector3.SmoothDamp(this.transform.position, player.transform.position + new Vector3(0, 0, -10), ref vel, 0.25f);
	}
}
