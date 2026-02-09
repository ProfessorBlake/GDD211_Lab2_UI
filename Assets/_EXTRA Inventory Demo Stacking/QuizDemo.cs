using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizDemo : MonoBehaviour
{
	private bool spinning;

	private void Update()
	{
		if (spinning)
			transform.Rotate(new Vector3( 1, 2, 3) * Time.deltaTime * 100);
	}

	public void OnToggleChange(bool isOn)
	{
		spinning = isOn;
	}
}
