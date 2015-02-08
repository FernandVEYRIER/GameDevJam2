using UnityEngine;
using System.Collections;

public class EndTutorial : MonoBehaviour {

	float distance;
	Transform feuFollet;

	void Update () 
	{
		if (GameObject.FindGameObjectWithTag("Feufollet") == null)
			return;
		feuFollet = GameObject.FindGameObjectWithTag("Feufollet").GetComponent<Transform>();
		distance = Vector2.Distance(this.transform.position, feuFollet.position);
		if (distance < 1 && this.GetComponent<LeverSystem>().areActive == false)
		{
			GameObject.Find("_GameManager").GetComponent<GameManager>().winPlayer();
		}
	}
}
