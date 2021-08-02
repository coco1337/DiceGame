using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public sealed class Buy : MonoBehaviour
{
	[SerializeField] private List<Toggle> toggleCheck;
	[SerializeField] private List<Text> textPrice;
	public Text myMoney;
	private int sum;
	public UnityEvent RollDiceBuyOff;
	public void BuyLand()
	{
		for (int i = 0; i < toggleCheck.Count; i++)
		{
			if (toggleCheck[i].isOn)
			{
				sum += int.Parse(textPrice[i].text);
			}
			else
			{
				continue;
			}
		}

		var sub = int.Parse(myMoney.text);
		var myMoneySum = sub - sum;

		myMoney.text = myMoneySum.ToString();

		RollDiceBuyOff.Invoke();
	}
}
