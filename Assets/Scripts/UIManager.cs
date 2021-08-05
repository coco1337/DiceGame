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

	public Image buyImage;

	public UnityEvent rollDicePlay;

	private BoardCell cell;

	private int moneys;

	private int dest;

	private void Awake()
	{
		this.bmm.rollDiceEvent.AddListener(BuildingBuyOn);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			BuildingBuyOff();
		}
	}

	public void PlayerMovePoint()
	{
		int diceToMove = this.diceManager.totalValue;
		this.valueText.text = diceToMove.ToString();

		this.rollDicePlay.Invoke();
	}

	/// <summary>
	/// 땅 및 건물 구매 UI 켜기
	/// </summary>
	/// <param name="dest">int, destination</param>
	public void BuildingBuyOn(int dest)
	{
		this.dest = dest;
		if (this.dest == 10)
		{
			this.moneys -= this.moneys / 10;
			this.myMoney.text = this.moneys.ToString();
		}
		else
		{
			BuildingBuyPopup();
			//BackgroundOn();
		}
	}
	
	public void BuildingBuyOff()
	{
		BlueMarbleManager.Instance.CurrentStep = ESteps.NONE;
		BackgroundOff();
		this.buyImage.gameObject.SetActive(false);
	}

	private void BuildingBuyPopup()
	{
		this.cell = this.bmm.GetCell(this.dest);
		var buildStatus = this.cell.GetBuildStatus;
		this.buyImage.gameObject.SetActive(true);
		for (int i = 0; i < buildStatus.Length; ++i)
		{
			this.buy.toggleCheck[i].interactable = buildStatus[i] == false;
		}
		this.buyImage.gameObject.SetActive(true);
	}

	public void BackgroundOn()
	{
		this.cell = this.bmm.GetCell(this.dest);

		for(int i=0; i < this.buy.buildingBackground.Count; i++)
		{
			if(i==1)
			{
				this.buy.toggleCheck[i].interactable = false;
			}

			else if(i==2)
			{
				this.buy.toggleCheck[i].isOn = false;
			}

			else if(i==3)
			{
				this.buy.toggleCheck[i].isOn = false;
			}
			else { }
		}
		//..
	}

	public void BackgroundOff()
	{
		foreach (var t in this.buy.buildingBackground)
		{
			t.gameObject.SetActive(false);
		}
	}
}