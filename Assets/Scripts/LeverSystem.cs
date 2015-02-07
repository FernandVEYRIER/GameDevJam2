using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class LeverSystem : MonoBehaviour {

	public Sprite leverSpriteOff;
	public Sprite leverSpriteOn;

	[Header("Lights to be activated")]
	public GameObject [] torch;

	public KeyCode key;
	bool areActive = false;
	bool canActivate = false;

	void Start () 
	{
		this.GetComponent<SpriteRenderer>().sprite = leverSpriteOff;
		foreach (GameObject _torch in torch)
		{
			_torch.SetActive(false);
		}
	}

	void Update()
	{
		if (canActivate && Input.GetKeyDown(key))
		{
			areActive = !areActive;
			if (areActive)
			{
				this.GetComponent<SpriteRenderer>().sprite = leverSpriteOn;
				foreach (GameObject _torch in torch)
				{
					_torch.SetActive(true);
					_torch.GetComponent<TorchScript>().startAnim();
				}
			}
			else
			{
				this.GetComponent<SpriteRenderer>().sprite = leverSpriteOff;
				foreach (GameObject _torch in torch)
				{
					_torch.SetActive(false);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		canActivate = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		canActivate = false;
	}
}
