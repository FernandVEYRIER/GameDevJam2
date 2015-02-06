using UnityEngine;
using System.Collections;

public class TorchScript : MonoBehaviour {

	public float maxAngle = 60;
	public float minAngle = 58;

	public float minIntensity = 0.8f;
	public float maxIntensity = 1;

	void Start () 
	{
		StartCoroutine(simulateTorch());
	}
	
	IEnumerator simulateTorch()
	{
		while (true)
		{
			this.GetComponent<Light>().intensity = Random.Range(minIntensity, maxIntensity);
			this.GetComponent<Light>().spotAngle = Random.Range(minAngle, maxAngle);
			yield return new WaitForSeconds(0.1f);
		}
	}
}
