using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public sealed class WebSocketManager : MonoBehaviour
{
	[DllImport("__Internal")]
	private static extern void Hello();

	private void Start()
	{
		Hello();
	}
}
