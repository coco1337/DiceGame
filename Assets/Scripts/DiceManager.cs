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

	private void Start() => AddHandlers();

	public void RollAllDice()
	{
		this.totalValue = 0;

		foreach (var t in this.diceList)
		{
			t.AddForceToDice();
		}

		var packet = new RollDiceReq();
		WebSocketManager.SendPacket(packet);
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

	public void OnReceivePacket(RollDiceRes packet)
	{
		// 패킷으로 하는일 처리
	}

	public void OnReceivePacket(ChangeTurnNoti packet)
	{
		
	}

	private void AddHandlers()
	{
		WebSocketManager.AddHandler(EPacketId.ROLL_DICE_RESPONSE, new MessageHandler<RollDiceRes>(OnReceivePacket));
		WebSocketManager.AddHandler(EPacketId.CHANGE_TURN_NOTI, new MessageHandler<ChangeTurnNoti>(OnReceivePacket));
	}
}

/*
 * DiceManager(RollDice!) 버튼 누르면  RollAllDice함수 실행 -> Dice스크립트에있는 AddForceToDice(주사위 돌아가는거) 실행  -> Dice에 UPDATE 를 통해 움직임을 파악
 * 함수에 isRolling 을 true로 바꿔주고 움직임 IsSleeping 안움직이는걸 확인후 주사위 숫자가 CalculateValue 를 통해 파악함.
 * Dice 함수에 있는 Event를 통해 DiceManager에 있는 CountAllDiceValue 를 통해 주사위 눈금 나옴 and 부루마블 매니저에있는 RollDice 실행
 * 부루마블매니저 이벤트에 Add 해놓은 rollDiceEvent 에 주사위 눈금을 넣은 이벤트  MoveTO와 UIManager에 넣은 이벤트 2개 실행 
 */