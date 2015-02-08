using UnityEngine;
using System.Collections;

public class PicsKill : MonoBehaviour {

	public GameObject gameManager;

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log(col);
		if (col.collider2D.tag == "Player")
			gameManager.GetComponent<GameManager>().playerDeath(col.collider2D.gameObject);
	}
}
