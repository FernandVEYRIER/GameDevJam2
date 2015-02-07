using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour {

	public GameObject canvasDisp;
	public Text charDisp;
	public Text textDisp;
	public Image backgroundDisp;
	public Image characterImage;

	[System.Serializable]
	public class DialogBox
	{
		public string characterName;
		[Multiline]
		public string text;
		public Sprite backGround;
		public Sprite characterImage;
	}

	public DialogBox [] _dialogBox;

	public bool dispOnStart = true;
	public bool dispOnCollision = false;
	public bool destroyAfterDisp = false;
	bool isDisplaying = false;

	void Start () 
	{
		canvasDisp.SetActive(false);
		this.GetComponent<Collider2D>().enabled = dispOnCollision;
		isDisplaying = dispOnStart;
	}
	
	int i = 0;
	void Update () 
	{
		if (Input.GetKeyUp(KeyCode.Return) && isDisplaying)
			i++;
		if (isDisplaying)
		{
			GameManager.isPlaying = false;
			canvasDisp.SetActive(true);
			if (i >=_dialogBox.Length)
			{
				GameManager.isPlaying = true;
				canvasDisp.SetActive(false);
				isDisplaying = false;
				if (destroyAfterDisp)
					Destroy(this.gameObject);
				i = 0;
			}
			else
			{
				//disp box
				textDisp.text = _dialogBox[i].text;
				charDisp.text = _dialogBox[i].characterName;
				characterImage.sprite = _dialogBox[i].characterImage;
				backgroundDisp.sprite = _dialogBox[i].backGround;
			}
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (dispOnCollision && col.collider2D.tag == "Player")
        {
            isDisplaying = true;
        }
    }

    public void startDialogBox()
    {
        isDisplaying = true;
    }
}
