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
	private static extern void OnTestCS();

	[DllImport("__Internal")]
	private static extern void SetEvent(Action<string> onTest);

	private void Start()
	{
		Hello();
		SetEvent((s => this.uiText.text = s));
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
