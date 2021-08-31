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
<<<<<<< HEAD
				//image.color = new Color(1, 1, 1, 1);
				image.enabled = true;
			}
			else
			{
				//image.color = new Color(1, 1, 1, 0);
				image.enabled = false;
=======
				image.sprite = this.PcardItem.ItemImage;
				// image.color = new Color(1, 1, 1, 1);
				this.image.enabled = true;
			}
			else
			{
				// image.color = new Color(1, 1, 1, 0);
				this.image.enabled = false;
>>>>>>> 9e761739e8427872bbc07f5ebe437a46c99a3c97
			}
		}
	}
}
