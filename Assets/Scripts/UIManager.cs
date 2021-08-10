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

	[SerializeField] public List<Toggle> toggleCheck;
	[SerializeField] private List<Text> textPrice;

	public DiceManager diceManager;
	public TextMeshProUGUI valueText;
	public Image buyImage;
	public UnityEvent rollDicePlay;
	private BoardCell cell;
	public bool[] buildBool = new bool[4];

	private int money;
	private int dest;
	private int sum;
	private int diceSum;

	private void Awake()
	{
		this.bmm.rollDiceEvent.AddListener(BuildingBuyOn);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			BuildingBuyOff();
		}
	}

	public void PlayerMovePoint()
	{
		int diceToMove = this.diceManager.totalValue;
		this.valueText.text = diceToMove.ToString();
	}

	/// <summary>
	/// 땅 및 건물 구매 UI 켜기
	/// </summary>
	/// <param name="dest">int, destination</param>
	public void BuildingBuyOn(int dest)         /// 현재 유니티 이벤트 주사위값으로 나오는 문제있음. 수정해야함  아마 같은 이벤트에 넣어서 그런듯하다.
	{
		this.diceSum += dest;
		this.dest = dest;
		if (diceSum > 40) { Debug.Log("40넘김"); diceSum -= 40; }

		if (this.diceSum == 10)
		{
			var moneys = int.Parse(myMoney.text) / 10;
			money = int.Parse(myMoney.text) - moneys;
			this.myMoney.text = this.money.ToString();
		}
		else
		{
			BuildingBuyPopup();
		}
	}

	public void BuildingBuyOff()
	{
		BlueMarbleManager.Instance.CurrentStep = ESteps.NONE; //현재상태
		Debug.Log(BlueMarbleManager.Instance.CurrentStep);
		this.buyImage.gameObject.SetActive(false);
	}

	private void BuildingBuyPopup()
	{
		this.cell = this.bmm.GetCell(this.diceSum);  // 부루마블에 있는 getCell에 dest(주사위값들)을 넣어줘서 플레이어 위치가 보드 어느위치인지 나오게함 (dest에서 diceSum으로 변경)
		var buildStatus = this.cell.GetBuildStatus; // BoardCell에 있는 GetBuildStatus 의 bool타입 가져옴
		Debug.Log(buildStatus);
		this.buyImage.gameObject.SetActive(true);
		for (int i = 0; i < buildStatus.Length; ++i)
		{
			this.toggleCheck[i].interactable = buildStatus[i] == false;
		}
	}
	public void BuyButton() // 토글 체크후 내 자산에서 건물값 지불
	{
		for (int i = 0; i < this.toggleCheck.Count; i++)
		{
			
			if (this.toggleCheck[i].isOn)
			{
				this.sum += int.Parse(this.textPrice[i].text);
				buildBool[i] = this.cell.GetBuildStatus[i] = true;
			}
			else
			{
				buildBool[i] = this.cell.GetBuildStatus[i] = false;
			}	
		}
		
		cell.BuildingOn(buildBool);
		int sub = int.Parse(this.myMoney.text);
		this.myMoney.text = (sub - this.sum).ToString();
		sum = 0;
		BuildingBuyOff();
	}
}