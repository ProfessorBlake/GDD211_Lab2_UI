using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollviewImage : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private TMP_Text labelText;
	[SerializeField] private string col;

	public void OnPointerClick(PointerEventData eventData)
	{
		labelText.text = $"Color: {col}";
		labelText.color = GetComponent<Image>().color;
	}
}
