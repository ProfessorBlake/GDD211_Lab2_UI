using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoItem : MonoBehaviour
{
	public string ItemName { get { return itemName; } }
	public Sprite ItemSprite { get { return sprRend.sprite; } }
	public int Heals { get { return heals; } }

    [SerializeField] private string itemName;
	[SerializeField] private int heals;

    private SpriteRenderer sprRend;

	private void Start()
	{
		sprRend = GetComponent<SpriteRenderer>();
	}
}
