using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class LeverSystem : MonoBehaviour {

	public Sprite leverSpriteOff;
	public Sprite leverSpriteOn;

	public GameObject [] torch;

	public KeyCode key;
	bool areActive = false;

	void Start () 
	{
		this.GetComponent<SpriteRenderer>().sprite = leverSpriteOff;
		foreach (GameObject _torch in torch)
		{
			_torch.SetActive(false);
		}
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (Input.GetKeyDown(key))
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
}
