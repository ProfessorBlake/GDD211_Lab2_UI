using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiItem : MonoBehaviour
{
    public string ItemName { get; private set; }

    [SerializeField] private TMP_Text text;
    [SerializeField] private Image img;

    public void SetDetail(string name, Sprite sprite)
	{
        ItemName = name;
        text.text = name;
        img.sprite = sprite;
	}

    public void UpdateCount(int cnt)
	{
        text.text = $"{cnt}x {ItemName}";
    }
}
