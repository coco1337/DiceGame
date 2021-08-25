using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public sealed class WebSocketManager : MonoBehaviour
{
	private static Dictionary<EPacketId, IMessageHandler> messageHandler = new Dictionary<EPacketId, IMessageHandler>();
	[SerializeField] private Text uiText;

	private void Start()
	{
#if UNITY_EDITOR
		Init();
#endif
	}

	public void Test(string str)
	{
		this.uiText.text = str;
		Debug.Log(nameof(Test) + " 이거 호출되긴함? " + str);
	}

	public static void AddHandler(EPacketId packetId, IMessageHandler handler) => messageHandler.Add(packetId, handler);

	public static void SendPacket(WebPacket packet) => SendPacket(JsonConvert.SerializeObject(packet));

	public void ReceiveWebMessage(string str)
	{
		var message = JsonConvert.DeserializeObject<WebMessage>(str);

		if (messageHandler.TryGetValue(message.id, out var handler))
		{
			var action = handler.MakeAction(message.msg);
			action.Invoke();
		}
		else
		{
			D.Error("Try to access not registered handler. packet Id : " + message.id);
		}
	}

	/*
	 *
Module['WebGLTest'].OnTest2 = function() {
    // Module.cwarp("name", null, [...args]);
}
// Module.cwrap("name", return, [...args]
	 * 
	 */

	#region in unity editor

#if UNITY_EDITOR
	private string host = "localhost";
	private int port = 8080;
	private static ClientWebSocket socket = new ClientWebSocket();

	private void Init()
	{
		var uri = new Uri("ws://" + this.host + this.port);
		socket.ConnectAsync(uri, CancellationToken.None).Wait();
		
		
	}

#endif
	
#if UNITY_WEBGL && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void SendPacket(string str);
#else 
	private static void SendPacket(string str)
	{
		var arrSeg = new ArraySegment<byte>(Encoding.Default.GetBytes(str));
		socket.SendAsync(arrSeg, WebSocketMessageType.Text, true, CancellationToken.None).Wait();
	}
#endif
	#endregion

}
