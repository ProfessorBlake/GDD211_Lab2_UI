using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float sensitivity;
    [SerializeField] private ParticleSystem[] lasers;
    [SerializeField] private GameObject damagePopupPrefab;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private Transform worldSpaceCanvas;

    private float damageDelay = 0f;
    private float damageDelayReset = 0.1f; // Deal damage ever 0.1 sec

	private void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ToggleLasers(false);
	}

	void Update()
    {
        damageDelay -= Time.deltaTime;

        transform.Rotate(transform.up, Input.GetAxis("Mouse X") * sensitivity);
        cameraTransform.localEulerAngles = new Vector3(
            cameraTransform.localEulerAngles.x - Input.GetAxis("Mouse Y") * sensitivity,
            0f,
            0f);

        if (Input.GetMouseButton(0))
        {
            ToggleLasers(true);
            if (damageDelay <= 0f)
            {
                damageDelay = damageDelayReset;
                if (Physics.SphereCast(cameraTransform.position, 0.5f, cameraTransform.forward, out RaycastHit hit, Mathf.Infinity, enemyLayerMask))
                {
                    GameObject popup = Instantiate(damagePopupPrefab, worldSpaceCanvas, true);
                    popup.transform.position = hit.point;
                }
            }
        }
        else
            ToggleLasers(false);

        
    }

    private void ToggleLasers(bool on)
	{
		for (int i = 0; i < lasers.Length; i++)
		{
            if (on)
                lasers[i].Play();
            else
                lasers[i].Stop();
		}
	}
}
