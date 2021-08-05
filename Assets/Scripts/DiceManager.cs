using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DiceManager : MonoBehaviour
{
	[SerializeField] private Image image;
	public List<Dice> diceList;  // 다이스 2개 대비
	public int totalValue;
	public UnityEvent EndRollEvent;

	public void RollAllDie()
	{
		if (!image.gameObject.activeSelf)
		{
			totalValue = 0;

			for (int i = 0; i < diceList.Count; i++)
			{
				diceList[i].AddForceToDice();
			}
		}
		else
		{
			Debug.Log("창 안닫");
		}
	}

	public void CountAllDieValues()
	{
		for (int i = 0; i < diceList.Count; i++)
		{
			if (diceList[i].isRolling == true)
			{
				totalValue = 0;
				return;
			}
			else
			{
				totalValue += diceList[i].value;
			}
		}

		EndRollEvent.Invoke();
	}
}
