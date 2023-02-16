using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
	[SerializeField] private float power;
	[SerializeField] private GameObject UIItemPrefab;
	[SerializeField] private Transform Inventory;

	private Dictionary<string, int> itemDict = new Dictionary<string, int>();
	private List<UiItem> uiItemList = new List<UiItem>();

	private Vector2 input;

	private void Update()
	{
		input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}

	private void FixedUpdate()
	{
		rb.AddForce(input * power);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Item hitItem = collision.GetComponent<Item>();
		if(hitItem != null)
		{
			// Add item if not in dict
			if (!itemDict.ContainsKey(collision.gameObject.name))
			{
				GameObject uiItem = Instantiate(UIItemPrefab, Inventory);
				uiItem.GetComponent<UiItem>().SetDetail(
					collision.gameObject.name,
					hitItem.ItemSprite
					);
				uiItemList.Add(uiItem.GetComponent<UiItem>());
				itemDict.Add(collision.gameObject.name, 1);
			}
			else
			{
				itemDict[collision.gameObject.name] = itemDict[collision.gameObject.name] + 1;
				uiItemList.Find(x => x.ItemName == collision.gameObject.name).UpdateCount(itemDict[collision.gameObject.name]);
			}
		}

		Destroy(collision.gameObject);
	}
}
