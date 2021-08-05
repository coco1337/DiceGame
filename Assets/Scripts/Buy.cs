using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public sealed class Buy : MonoBehaviour
{
	[SerializeField] public List<Toggle> toggleCheck;
	[SerializeField] private List<Text> textPrice;
	[SerializeField] public List<Image> buildingBackground;
	[SerializeField] private BlueMarbleManager blueMarbleManagers;

	public Text myMoney;
	public UnityEvent RollDiceBuyOff;

	private int sum;
	public GameObject player1;
	private GameObject cell;

	private void Awake()
	{
		player1 = GameObject.FindWithTag("Player");
	}

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
		myMoney.text = (sub - sum).ToString();

		RollDiceBuyOff.Invoke();
		Building();
	}

	public void Building()
	{
		cell = player1.transform.parent.gameObject;
		for (int i = 0; i < toggleCheck.Count; i++)
		{
			if (toggleCheck[i].isOn)
			{
				if (i == 0)
				{
					var playerColor = blueMarbleManagers.playerList[0].GetComponent<MeshRenderer>().material.GetColor("_Color");
					cell.GetComponent<MeshRenderer>().material.SetColor("_Color", playerColor);
				}
				else if (i == 1)
				{
					cell.transform.GetChild(1).gameObject.SetActive(true);
				}
				else if (i == 2)
				{
					cell.transform.GetChild(2).gameObject.SetActive(true);
				}
				else if (i == 3)
				{
					cell.transform.GetChild(3).gameObject.SetActive(true);
				}
				else { }
			}
		}
	}
}
