using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeText2 : MonoBehaviour
{
	[TextArea(5,20)] [SerializeField] private string completeMessage;
	[SerializeField] private TMP_Text txt;
	[SerializeField] private string playerName2;

	private int messageIndex;
	private float delay;
	private float delayReset = 0.05f;

	private void Start()
	{
		completeMessage = completeMessage.Replace("playerName", playerName2);
	}

	private void Update()
	{
		delay -= Time.deltaTime;
		if(delay <= 0)
		{
			if (messageIndex < completeMessage.Length)
			{
				messageIndex++;
			}
			txt.text = completeMessage.Substring(0, messageIndex);
			delay = delayReset;
		}

		if (Input.GetKey(KeyCode.Space))
		{
			messageIndex = completeMessage.Length - 1;
		}
	}
}
