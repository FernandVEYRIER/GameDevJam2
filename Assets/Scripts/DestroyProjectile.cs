using UnityEngine;
using System.Collections;

public class DestroyProjectile : MonoBehaviour {
	
	// Use this for initialization
	void Awake ()
	{
		Destroy (gameObject, 0.7f);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag != "Player")
			Destroy (gameObject);
	}
}
