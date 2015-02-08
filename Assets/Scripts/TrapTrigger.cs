using UnityEngine;
using System.Collections;

public class TrapTrigger : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = this.GetComponent<Animator>();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Player")
		{
			if (anim.GetBool("isOpen") == false)
				anim.SetBool("isOpen", true);
			//close trap
			//Invoke("closeTrap", 1f);
		}
	}

	void closeTrap()
	{
		anim.SetBool("isOpen", false);
	}
}
