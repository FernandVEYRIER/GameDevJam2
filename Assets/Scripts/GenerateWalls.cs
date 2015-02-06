using UnityEngine;
using System.Collections;

public class GenerateWalls : MonoBehaviour {

	[Header("Size of the background")]
	public int minWidth = -10;
	public int minHeight = -10;
	public int maxWidth = 10;
	public int maxHeight = 10;

	public GameObject wallObject;

	// Use this for initialization
	void Start () 
	{
		for (int j = minHeight; j < maxHeight; j++)
		{
			for (int i = minWidth; i < maxWidth; i++)
			{
				GameObject go = (GameObject) Instantiate(wallObject, new Vector3(3.8f * i, 1.26f * j, 0), Quaternion.identity);
				go.transform.SetParent(this.transform);
			}
		}
	}
}
