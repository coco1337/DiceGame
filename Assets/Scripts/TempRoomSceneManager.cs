using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class TempRoomSceneManager : MonoBehaviour
{
	[SerializeField] private InputField nicknameField;
	[SerializeField] private GameObject waitingPanel;
	
	private void Start()
	{
		WebSocketManager.AddHandler(EPacketId.CREATE_ROOM_RES, new MessageHandler<CreateRoomRes>(OnReceiveMessage));
		WebSocketManager.AddHandler(EPacketId.PLAYER_JOIN_NOTI, new MessageHandler<PlayerJoinNoti>(OnReceiveMessage));
		WebSocketManager.AddHandler(EPacketId.START_GAME_NOTI, new MessageHandler<StartGameNoti>(OnReceiveMessage));
	}
	
	public void OnClickJoinRandomRoom()
	{
		if (string.IsNullOrEmpty(this.nicknameField.text)) return;
		AccountManager.Instance.SetGuid(this.nicknameField.text);
	}

	public void OnClickCreateRoom()
	{
		if (string.IsNullOrEmpty(this.nicknameField.text)) return;
		AccountManager.Instance.SetGuid(this.nicknameField.text);
		
		WebSocketManager.SendPacket(new CreateRoomReq
		{
			id = EPacketId.CREATE_ROOM_REQ,
			sender = AccountManager.Instance.CustomGuid,
		});
	}

	private void OnReceiveMessage(CreateRoomRes message)
	{
		if (message.result == EError.SUCCESS) 
			this.waitingPanel.SetActive(true);
	}

	private void OnReceiveMessage(PlayerJoinNoti message)
	{
		if (message.result == EError.SUCCESS)
			D.Log("player join : " + message.playerGuid);
	}

	private void OnReceiveMessage(StartGameNoti message)
	{
		if (message.result == EError.SUCCESS)
			SceneManager.LoadScene("SampleScene 1");
	}
}