using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[HideInInspector]
	public static bool isPlaying;

	public GameObject pauseCanvas;
	public Transform checkpoint;


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
			//Time.timeScale = (Time.time == 1) ? 0 : 1;
		}
		if (!isPlaying)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	public void onReloadButton()
	{
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void onMenuButton()
	{
		Time.timeScale = 1;
		Application.LoadLevel(0);
	}

	GameObject player;

	public void playerDeath(GameObject _player)
	{
		_player.SetActive(false);
		player = _player;
		Invoke ("respawnPlayer", 1);
	}

	void respawnPlayer()
	{		
		player.SetActive(true);
		player.transform.position = checkpoint.position;
	}
}
