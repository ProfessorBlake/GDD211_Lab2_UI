using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public void SlideWidth(float value)
	{
		transform.localScale = new Vector3(value, transform.localScale.y, transform.localScale.z);
	}

	public void SlideHeight(float value)
	{
		transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z);
	}

	public void DropdownHandler(int value)
	{
		Debug.Log(value);
	}
}
