using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
	[SerializeField] private float speed;

    private PlayerController player;
	private Vector3 targetPos;
	private Vector3 heading;

	private void Start()
	{
		player = FindObjectOfType<PlayerController>();
		targetPos = new Vector3(
				player.transform.position.x + Random.Range(-15f, 15f),
				transform.position.y,
				player.transform.position.z + Random.Range(0, 5f));
	}


	void Update()
    {
		if (Random.value > 0.99f)
		{
			targetPos = new Vector3(
				player.transform.position.x + Random.Range(-20f, 20f), 
				transform.position.y,
				player.transform.position.z + Random.Range(0, 10f));
		}
		heading = Vector3.Lerp(heading, (targetPos - transform.position).normalized, Time.deltaTime * 2f);
		transform.LookAt(transform.position +  heading);
		transform.position += heading * speed * Time.deltaTime;
    }

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawSphere(transform.position + heading, 0.5f);
	}
}
