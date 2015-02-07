using UnityEngine;
using System.Collections;

public class AttackHeros : MonoBehaviour {

	public Transform	spawnpoint;
	public GameObject	projectile;
	public float		speed;
	private bool		activate = false;
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && activate == false)
		{
			StartCoroutine(timer ());
			GameObject obj = (GameObject)Instantiate (projectile, spawnpoint.position, spawnpoint.rotation);
			obj.transform.localScale = transform.localScale;
			obj.rigidbody2D.velocity = new Vector2(speed, 0f) * transform.localScale.x;
		}
	}
	IEnumerator		timer()
	{
		activate = true;
		yield return new WaitForSeconds (1);
		activate = false;
	}
}
