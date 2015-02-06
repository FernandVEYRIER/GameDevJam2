using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public static bool isPlaying;

	public GameObject pauseCanvas;


	void Start () 
	{
		isPlaying = true;

	}
	

	void Update () 
	{
		//handles pause
		if (Input.GetButtonDown("Pause"))
		{
			isPlaying = !isPlaying;
			pauseCanvas.SetActive(!pauseCanvas.activeSelf);
			Time.timeScale = (Time.time == 1) ? 0 : 1;
		}
	}
}
