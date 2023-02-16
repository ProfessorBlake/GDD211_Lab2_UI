using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public Sprite ItemSprite 
	{
		get { return sprRend.sprite; }
	}

    private SpriteRenderer sprRend;

	private void Start()
	{
		sprRend = GetComponent<SpriteRenderer>();
	}
}
