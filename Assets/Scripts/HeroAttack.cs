using UnityEngine;
using System.Collections;

public class HeroAttack : MonoBehaviour {

	Animator anim;
	int attackHash;

	// Use this for initialization
	void Start () 
	{
		anim = this.GetComponent<Animator>();
		attackHash = Animator.StringToHash("Attack");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && !anim.GetBool(attackHash) && anim.GetBool("isGrounded"))
		{
			anim.SetBool(attackHash, true);
			Invoke("resetAttack", .5f);
		}
		if (anim.GetBool(attackHash))
			this.rigidbody2D.velocity = Vector2.zero;
	}

	void resetAttack()
	{
		anim.SetBool(attackHash, false);
	}
}
