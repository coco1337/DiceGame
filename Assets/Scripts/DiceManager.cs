using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DiceManager : MonoBehaviour
{
	[SerializeField] private Image image;
	public List<Dice> diceList;  // ���̽� 2�� ���
	public int totalValue;
	public UnityEvent endRollEvent;

	public void RollAllDice()
	{
		this.totalValue = 0;

		foreach (var t in this.diceList)
		{
			t.AddForceToDice();
		}
	}

	public void CountAllDiceValues()
	{
		for (int i = 0; i < this.diceList.Count; i++)
		{
			if (this.diceList[i].isRolling == true)
			{
				this.totalValue = 0;
				return;
			}
			else
			{
				this.totalValue += this.diceList[i].value;
			}
		}

		this.endRollEvent.Invoke();
	}
}
