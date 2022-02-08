using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float sensitivity;

	private void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

	void Update()
    {
        transform.Rotate(transform.up, Input.GetAxis("Mouse X") * sensitivity);
        cameraTransform.localEulerAngles = new Vector3(
            cameraTransform.localEulerAngles.x - Input.GetAxis("Mouse Y") * sensitivity,
            0f,
            0f);
    }
}
