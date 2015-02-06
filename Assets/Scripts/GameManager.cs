using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public static bool isPlaying;

	public GameObject pauseCanvas;


	void Start () 
	{
		isPlaying = true;
		pauseCanvas.SetActive(false);
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

	public void onReloadButton()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void onMenuButton()
	{
		Application.LoadLevel(0);
	}
}
