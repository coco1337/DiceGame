using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AccountManager : MonoBehaviour
{
	[SerializeField] private string customGuid;
	
	public string CustomGuid => this.customGuid;
	public static AccountManager Instance { get; private set; }

	private void Start()
	{
		Instance ??= this;
		DontDestroyOnLoad(this);
	}

	public void SetGuid(string str) => this.customGuid = str;
}