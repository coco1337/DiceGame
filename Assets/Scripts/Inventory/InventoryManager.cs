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

	private void OnValidate()
	{
		slots = slotParent.GetComponentsInChildren<Slot>();
	}

	private void Awake()
	{
		Instance ??= this;
		//FreshSlot();
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
		goldcardItem.Add(new CardItem("dd", keyImage, 1)); // 수정할부분

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
			D.Log("슬롯다참");
		}
	}

	public void AddItems(string name, int index)
	{
		if (goldcardItem.Count < slots.Length)
		{
			goldcardItem.Add(new CardItem(name, keyImage, index));
			FreshSlot();
			D.Log("카드인벤 들어왔다!?");
		}
		else
		{
			D.Log("슬롯다참");
		}
	}

	public void DeleteItem()
	{
		D.Log(goldcardItem[0].ItemIndex.ToString());
		D.Log(goldcardItem[0].ItemImage.ToString());
		goldcardItem.Remove(goldcardItem[0]); //
		FreshSlot();
	}
}
