using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {
	
	public LayerMask WhatIsGround;
	public Transform groundCheck;
	public float Velocity = 300f;
	public float JumpForce = 300f;
	
	bool isGrounded;
	bool canApplyForce = true;
	int walkAnim;
	int jumpAnim;
	Animator anim;
	
	void Start () 
	{
		anim = this.GetComponent<Animator>();
		walkAnim = Animator.StringToHash("Velocity");
		jumpAnim = Animator.StringToHash("isGrounded");
		isGrounded = true;
	}
	
	void Update () 
	{
		//face the right direction
		if (Mathf.RoundToInt(this.rigidbody2D.velocity.x) != 0)
		{
			this.transform.localScale = new Vector3((Mathf.RoundToInt(this.rigidbody2D.velocity.x) > 0) ? 1 : -1, 1, 1);
		}
		
		//can he jump ?
		if (isGrounded && Input.GetAxis("Vertical") > 0 && !anim.GetBool("Attack"))
		{
			isGrounded = false;
			//reset y velocity
			this.rigidbody2D.velocity = new Vector2(this.rigidbody2D.velocity.x, 0);
			this.rigidbody2D.AddForce(new Vector2(0, JumpForce));
		}
		if (Physics2D.OverlapCircle(groundCheck.position, 0.1f, WhatIsGround))
		{
			isGrounded = true;
		}
		//sets forces
		if (canApplyForce && !anim.GetBool("Attack"))
		{
			this.rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * Velocity, this.rigidbody2D.velocity.y);
		}
		
		//set anims
		anim.SetFloat(walkAnim, Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetBool(jumpAnim, isGrounded);
	}
	
	void OnCollisionStay2D(Collision2D col)
	{
		bool isOnGround = false;
		ContactPoint2D[] allContacts;
		allContacts = col.contacts;
		if (isGrounded)
		{
			canApplyForce = true;
			return;
		}
		foreach(ContactPoint2D contactPoint in allContacts)
		{
			Debug.Log(contactPoint.normal);
			if (contactPoint.normal == new Vector2(0, 1))
			{
				isOnGround = true;
			}
		}
		canApplyForce = isOnGround;
	}
	
	void OnCollisionExit2D(Collision2D col)
	{
		canApplyForce = true;
	}
}