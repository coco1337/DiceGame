using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public sealed class WebSocketManager : MonoBehaviour
{
	private static Dictionary<EPacketId, IMessageHandler> messageHandler = new Dictionary<EPacketId, IMessageHandler>();
	[SerializeField] private Text uiText;

	[DllImport("__Internal")]
	private static extern void SendPacket(string str);

	private void Start()
	{
#if UNITY_WEBGL
		SendPacket("Test string");
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
	
}
