using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItem : MonoBehaviour
{
	public string itemName;
	public Sprite ItemImage;
	public int ItemIndex;
	public CardItem(string Name, Sprite Image, int Index)
	{
		this.itemName = Name;
		this.ItemImage = Image;
		this.ItemIndex = Index;
	}
}
