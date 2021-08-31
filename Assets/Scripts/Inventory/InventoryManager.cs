using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public List<CardItem> cardItems;

	[SerializeField] private Transform slotParent;
	[SerializeField] private Slot[] slots;
	[SerializeField] private Sprite keyImage;
	[SerializeField] public List<CardItem> goldcardItem;

	public static InventoryManager Instance { get; private set; }

	private void Awake()
	{
		Instance ??= this;
	}

	public void FreshSlot()
	{
		int i = 0;
		for (; i < goldcardItem.Count && i < slots.Length; i++)
		{
			slots[i].PcardItem = goldcardItem[i];
		}

		for (; i < slots.Length; i++)
		{
			slots[i].PcardItem = null;
		}
	}
	public void CardList()
	{
<<<<<<< HEAD
		CardItem abc = new CardItem("dd", 1);
		goldcardItem.Add(abc);
=======
		goldcardItem.Add(new CardItem("dd", keyImage, 1)); // 수정할부분
>>>>>>> 9e761739e8427872bbc07f5ebe437a46c99a3c97

	}

	public void AddItem()
	{
		if (goldcardItem.Count < slots.Length)
		{
			CardList();
			FreshSlot();
		}
		else
		{
<<<<<<< HEAD
			D.Log("?�롯 ?�참");
=======
			D.Log("슬롯다참");
>>>>>>> 9e761739e8427872bbc07f5ebe437a46c99a3c97
		}
	}

	public void AddItems(string name, int index)
	{
		if (goldcardItem.Count < slots.Length)
		{
			goldcardItem.Add(new CardItem(name, index));
			FreshSlot();
<<<<<<< HEAD
		}
		else
		{
			D.Log("?�롯?�참");
=======
			D.Log("카드인벤 들어왔다!?");
		}
		else
		{
			D.Log("슬롯다참");
>>>>>>> 9e761739e8427872bbc07f5ebe437a46c99a3c97
		}
	}

	public void DeleteItem()
	{
		D.Log(goldcardItem[0].ItemIndex.ToString());
		D.Log(goldcardItem[0].itemName.ToString());
		goldcardItem.Remove(goldcardItem[0]); //
		FreshSlot();
	}
}
