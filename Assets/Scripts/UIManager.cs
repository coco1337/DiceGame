using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIManager : MonoBehaviour
{
	[SerializeField] private BlueMarbleManager bmm;
	[SerializeField] private TextMeshProUGUI txtDiceResult;
	[SerializeField] private Buy buy;
	[SerializeField] private PlayerInfo playerinfo;
	[SerializeField] private Text myMoney;

	public static UIManager Uimanager { get; private set; }

	public DiceManager diceManager;

	public TextMeshProUGUI valueText;

	public Image BuyImage;

	public UnityEvent RollDicePlay;

	private GameObject cell;

	private int moneys;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			BuildingBuyOff();
		}
	}

	public void PlayerMovePoint()
	{
		int diceToMove = diceManager.totalValue;
		valueText.text = diceToMove.ToString();

		RollDicePlay.Invoke();
	}

	public void BuildingBuyOn()
	{
		Debug.Log(bmm.dest);
		if (bmm.dest == 10)
		{
			Debug.Log("기부금 추가");
			moneys = int.Parse(myMoney.text);
			var div = moneys / 10;
			Debug.Log("이자값 : " + div);
			var sum = moneys + div;
			Debug.Log("이자+자본 : " + sum);
			myMoney.text = sum.ToString();
		}
		else
		{
			BuyImage.gameObject.SetActive(true);
			BackgroundOn();
		}
	}
	public void BuildingBuyOff()
	{
		BackgroundOff();
		BuyImage.gameObject.SetActive(false);
	}

	public void BackgroundOn()
	{
		cell = buy.player1.transform.parent.gameObject;

		for(int i=0; i< buy.buildingBackground.Count; i++)
		{
			if(i==1)
			{
				if (cell.transform.GetChild(1).gameObject.activeSelf)
				{
					buy.toggleCheck[i].isOn = false;
					buy.buildingBackground[i].gameObject.SetActive(true);
					
				}
			}

			else if(i==2)
			{
				if (cell.transform.GetChild(2).gameObject.activeSelf)
				{
					buy.toggleCheck[i].isOn = false;
					buy.buildingBackground[i].gameObject.SetActive(true);
					
				}
			}

			else if(i==3)
			{
				if (cell.transform.GetChild(3).gameObject.activeSelf)
				{
					buy.toggleCheck[i].isOn = false;
					buy.buildingBackground[i].gameObject.SetActive(true);
					
				}
			}
			else { }
		}
		//..
	}

	public void BackgroundOff()
	{
		for(int i=0; i<buy.buildingBackground.Count; i++)
		{
			buy.buildingBackground[i].gameObject.SetActive(false);
		}
	}
}