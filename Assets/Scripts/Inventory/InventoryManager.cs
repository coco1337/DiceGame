using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public List<CardItem> cardItems;

	[SerializeField] private Transform slotParent;
	[SerializeField] private Slot[] slots;
	[SerializeField] private Sprite keyImage;

	private void OnValidate()
	{
		slots = slotParent.GetComponentsInChildren<Slot>();
	}

	private void Awake()
	{
		FreshSlot();
	}

	public void FreshSlot()
	{
		int i = 0;
		for (; i < cardItems.Count && i < slots.Length; i++)
		{
			slots[i].PcardItem = cardItems[i];
		}

		for (; i < slots.Length; i++)
		{
			slots[i].PcardItem = null;
		}
	}
	public void CardList()
	{
		cardItems.Add(new CardItem("dd", keyImage, 1));

	}

	public void AddItem()
	{
		if (cardItems.Count < slots.Length)
		{
			CardList();
			FreshSlot();
		}
		else
		{
			D.Log("½½·Ô´ÙÂü");
		}
	}

	public void DeleteItem()
	{
		cardItems.Remove(cardItems[0]); //
		FreshSlot();
	}
}
