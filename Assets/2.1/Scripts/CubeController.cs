using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
	private float spinningX;
	private float spinningY;
	private float spinningZ;

	private void Update()
	{
		transform.Rotate(new Vector3(spinningX, spinningY, spinningZ), 50 * Time.deltaTime);
	}

	public void ToggleSpinX(bool spin)
	{
		if(spin == true)
		{
			spinningX = 1f;
		}
		else
		{
			spinningX = 0f;
		}
	}

	public void ToggleSpinY(bool spin)
	{
		if (spin == true)
		{
			spinningY = 1f;
		}
		else
		{
			spinningY = 0f;
		}
	}

	public void ToggleSpinZ(bool spin)
	{
		if (spin == true)
		{
			spinningZ = 1f;
		}
		else
		{
			spinningZ = 0f;
		}
	}
}
