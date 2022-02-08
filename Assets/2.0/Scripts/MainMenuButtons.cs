using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;

    public void ColorButton()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			ColorBlock colors = buttons[i].colors;
			colors.normalColor = Random.ColorHSV();
			buttons[i].colors = colors;
		}
	}

	public void ShuffleOrderButton()
	{
		foreach(Button b in buttons)
		{
			b.transform.SetSiblingIndex(Random.Range(0, buttons.Count));
		}
	}

	public void DestroyButton()
	{
		Button b = buttons[Random.Range(0, buttons.Count)];
		buttons.Remove(b);
		Destroy(b.gameObject);
	}

	public void ShakeButton()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			buttons[i].transform.eulerAngles = new Vector3(0f, 0f, Random.Range(-10, 10));
		}
	}
}
