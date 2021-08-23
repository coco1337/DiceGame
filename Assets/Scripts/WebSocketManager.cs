using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public sealed class WebSocketManager : MonoBehaviour
{
	[SerializeField] private Text uiText;
	
	[DllImport("__Internal")]
	private static extern void Hello();

	[DllImport("__Internal")]
	private static extern void SendPacket(string str);

	private void Start()
	{
		Hello();
		SendPacket("Test string");
	}

	public void Test(string str)
	{
		this.uiText.text = str;
		Debug.Log(nameof(Test) + " 이거 호출되긴함? " + str);
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
