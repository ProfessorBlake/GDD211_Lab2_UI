using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InvItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text txt;
    [SerializeField] private Image img;

    private int heals;

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log("Healed " + heals);
		Destroy(gameObject);
	}

	public void Setup(string name, Sprite sprite, int h)
	{
        txt.text = name + $"({h})";
        img.sprite = sprite;
        heals = h;
	}
}
