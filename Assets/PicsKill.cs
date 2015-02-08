using UnityEngine;
using System.Collections;

public class PicsKill : MonoBehaviour {

	public GameObject gameManager;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player")
			gameManager.GetComponent<GameManager>().playerDeath(col.collider.gameObject);
	}
}
