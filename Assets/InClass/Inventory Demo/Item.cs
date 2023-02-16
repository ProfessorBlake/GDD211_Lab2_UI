using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public Sprite ItemSprite 
	{
		get { return sprRend.sprite; }
	}

	public string ItemName { get { return itemName; } }

	[SerializeField] private string itemName;

    private SpriteRenderer sprRend;

	private void Start()
	{
		sprRend = GetComponent<SpriteRenderer>();
	}
}
