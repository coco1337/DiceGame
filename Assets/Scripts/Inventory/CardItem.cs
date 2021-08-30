using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardItem : ScriptableObject
{
	public string itemName;
	public Sprite ItemImage;
	public int ItemIndex;
	public CardItem(string aa, Sprite bb, int cc)
	{
		this.itemName = aa;
		this.ItemImage = bb;
		this.ItemIndex = cc;
	}
}
