using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
	[SerializeField] Image image;

	private CardItem cardItem;
	public CardItem PcardItem
	{
		get => cardItem;
		set
		{
			cardItem = value;
			if (cardItem != null)
			{
				image.sprite = this.PcardItem.ItemImage;
				// image.color = new Color(1, 1, 1, 1);
				this.image.enabled = true;
			}
			else
			{
				// image.color = new Color(1, 1, 1, 0);
				this.image.enabled = false;
			}
		}
	}
}
