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
		player = GameObject.Find(players [index]);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (GameObject.Find("shotBub(Clone)") != null)
				index++;
			if (index == players.Length)
				index = 0;
			if (players[index] != null)
				player = GameObject.Find(players[index]);
			if (GameObject.Find("shotBub(Clone)") != null && player.name == "shotBub(Clone)" && Input.GetKeyDown(KeyCode.Tab))
			{
				player.GetComponent<FeuFollet>().activate = true;
			}
			else if (GameObject.Find("shotBub(Clone)") != null)
				GameObject.Find("shotBub(Clone)").GetComponent<FeuFollet>().activate = false;
		}
		if (player != GameObject.Find("shotBub(Clone)"))
			this.transform.position = Vector3.SmoothDamp(this.transform.position, player.transform.position + new Vector3(0, 0, -10), ref vel, 0.25f);
		if (player == GameObject.Find("shotBub(Clone)") && player.GetComponent<FeuFollet>().time == true)
			this.transform.position = Vector3.SmoothDamp(this.transform.position, player.transform.position + new Vector3(0, 0, -10), ref vel, 0.25f);
	}
}
