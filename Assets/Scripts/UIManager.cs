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
	[SerializeField] private PlayerInfo playerinfo;
	[SerializeField] private Text myMoney;
	[SerializeField] private Text specialBuyMoney;

	[SerializeField] public List<Toggle> toggleCheck;
	[SerializeField] private List<Text> textPrice;

	public DiceManager diceManager;
	public TextMeshProUGUI valueText;
	public Image buyImage;
	public Image specialbuyImage;
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

	// 열쇠 2,7,12,17,22,28,35,38
	// 특수지역 5,15,25 ,35, 32

	public void BuildingBuyOn(int dest)         /// 현재 유니티 이벤트 주사위값으로 나오는 문제있음. 수정해야함  아마 같은 이벤트에 넣어서 그런듯하다.
	{
		this.diceSum += dest;
		this.dest = dest;

		////특수칸 리스트
		int[] specialDest = { 5, 15, 25, 35 };
		var specialList = new List<int>();
		specialList.AddRange(specialDest);
		///
		///열쇠칸 리스트
		int[] keyDest = { 2, 7, 12, 17, 22, 28, 35, 38 };
		var keyList = new List<int>();
		keyList.AddRange(keyDest);
		///
		
		if (diceSum > 40) { Debug.Log("40넘김"); diceSum -= 40; }

		if (keyList.Contains(diceSum)) { Debug.Log("열쇠칸"); }

		else if (specialList.Contains(diceSum))
		{
			SpecialBuyPopup();
			//CsvReader.Instance.CsvTest(diceSum);
			JsonManagers.Instance.Load(diceSum);
		}

		else if (this.diceSum == 10)
		{
			var moneys = int.Parse(myMoney.text) / 10;
			money = int.Parse(myMoney.text) - moneys;
			this.myMoney.text = this.money.ToString();
		}
		else
		{
			BuildingBuyPopup();
			//CsvReader.Instance.CsvTest(diceSum);
			JsonManagers.Instance.Load(diceSum);
		}
	}

	public void BuildingBuyOff()
	{
		BlueMarbleManager.Instance.CurrentStep = ESteps.NONE; //현재상태
		Debug.Log(BlueMarbleManager.Instance.CurrentStep);
		this.buyImage.gameObject.SetActive(false);
	}

	private void SpecialBuyPopup()
	{
		this.cell = this.bmm.GetCell(this.diceSum);
		this.specialbuyImage.gameObject.SetActive(true);
	}

	private void BuildingBuyPopup()
	{
		this.cell = this.bmm.GetCell(this.diceSum);  // 부루마블에 있는 getCell에 dest(주사위값들)을 넣어줘서 플레이어 위치가 보드 어느위치인지 나오게함 (dest에서 diceSum으로 변경)
		var buildStatus = this.cell.GetBuildStatus; // BoardCell에 있는 GetBuildStatus 의 bool타입 가져옴
		this.buyImage.gameObject.SetActive(true);
		for (int i = 0; i < buildStatus.Length; ++i)
		{
			this.toggleCheck[i].interactable = buildStatus[i] == false;
			this.toggleCheck[i].isOn = buildStatus[i] == false;
		}
	}
	public void OnClickBuyButton() // 토글 체크후 내 자산에서 건물값 지불
	{
		var buildStatus = this.cell.GetBuildStatus;
		for (int i = 0; i < this.toggleCheck.Count; i++)
		{
			
			if (this.toggleCheck[i].isOn)
			{
				//this.sum += int.Parse(this.textPrice[i].text);
				buildStatus[i] = true;
			}
			else
			{
				buildStatus[i] = false;
			}	
		}
		
		cell.BuildingOn(buildStatus);
		Buy();
		BuildingBuyOff();
	}

	public void SpecialBuildingBuyOff()
	{
		BlueMarbleManager.Instance.CurrentStep = ESteps.NONE; //현재상태
		Debug.Log(BlueMarbleManager.Instance.CurrentStep);
		this.specialbuyImage.gameObject.SetActive(false);
	}

	public void OnClickSpecialBuyButton()
	{
		var sub = int.Parse(this.myMoney.text);
		var specialmoney = int.Parse(this.specialBuyMoney.text);
		this.myMoney.text = (sub - specialmoney).ToString();

		SpecialBuildingBuyOff();
	}

	public void Buy()
	{
		for (int i = 0; i < this.toggleCheck.Count; i++)
		{

			if (this.toggleCheck[i].isOn)
			{
				this.sum += int.Parse(this.textPrice[i].text);
			}
			else
			{
			}
		}

		int sub = int.Parse(this.myMoney.text);
		this.myMoney.text = (sub - this.sum).ToString();
		sum = 0;
	}
}

//다음 해봐야할거 : csv 사용해서 땅마다 이름, 건물 가격 가져오는거 해보기.

//0817 건물 지어진곳 체크못하게 막아논건 됬지만 그대로 체크상태이기 떄문에 값이 나가는 오류가 있음. 변경해야함.