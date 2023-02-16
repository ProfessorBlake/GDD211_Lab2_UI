using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeText : MonoBehaviour
{
	[SerializeField] private TMP_Text txt;
    [TextArea(3,10)] [SerializeField] private string message;

	private int shownIndex;

	private float delay;
	private float delayReset = 0.1f;

	private void Update()
	{
		delay -= Time.deltaTime;
		if(delay <= 0)
		{
			shownIndex++;
			txt.text = message.Substring(0, shownIndex);
			delay = delayReset;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			shownIndex += 5;
		}
	}
}
