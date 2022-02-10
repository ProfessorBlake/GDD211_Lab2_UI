using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text txt;

    public void UpdateText(float value)
	{
		txt.text = (Mathf.Round(value * 10) / 10).ToString();
	}
}
