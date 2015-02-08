using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

	public GameObject canvasCredits;

	public void OnPlayClick()
	{
		Application.LoadLevel(1);
	}

	public void OnQuitClick()
	{
		Application.Quit();
	}

	public void OnCreditsClick()
	{
		canvasCredits.SetActive(!canvasCredits.activeSelf);
	}
}
