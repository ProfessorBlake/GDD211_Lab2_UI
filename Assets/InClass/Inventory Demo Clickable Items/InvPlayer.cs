using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvPlayer : MonoBehaviour
{
	[SerializeField] private GameObject invItemPrefab;
	[SerializeField] private Transform inventory;

	[SerializeField] private int health;

	private void Update()
	{
		transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * 4;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DemoItem item = collision.GetComponent<DemoItem>();
		if(item != null)
		{
			GameObject newInvItemGO = Instantiate(invItemPrefab, inventory);
			InvItem invItem = newInvItemGO.GetComponent<InvItem>();

			invItem.Setup(item.ItemName, item.ItemSprite, item.Heals);

			Destroy(collision.gameObject);
		}
	}
}
