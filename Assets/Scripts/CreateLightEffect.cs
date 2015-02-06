using UnityEngine;
using System.Collections;

public class CreateLightEffect : MonoBehaviour {

	public float minLight = 0.5f;
	public float averageLight = 0.8f;
	public float maxLight = 1.5f;

	float currentIntensity;

	void Start () 
	{
		StartCoroutine(changeLight());
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.GetComponent<Light>().intensity = currentIntensity;
	}

	IEnumerator changeLight()
	{
		while (true)
		{
			currentIntensity = Random.Range(minLight, averageLight);
			if ((int)Time.timeSinceLevelLoad % 32 == 0)
			{
				currentIntensity = maxLight;
				//yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(0.1f);
		}
	}
}
