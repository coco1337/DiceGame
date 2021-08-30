using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

	public List<CardItem> cardItems;

	[SerializeField]
	private Transform slotParent;

	[SerializeField]
	private Slot[] slots;

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
		for(; i<cardItems.Count && i< slots.Length; i++)
		{
			slots[i].PcardItem = cardItems[i];
		}

		for(; i<slots.Length; i++)
		{
			slots[i].PcardItem = null;
		}
	}

	public void AddItem(CardItem cardItem)
	{
		if(cardItems.Count<slots.Length)
		{
			cardItems.Add(cardItem);
			FreshSlot();
		}
		else
		{
			D.Log("½½·Ô´ÙÂü");
		}
	}
}
