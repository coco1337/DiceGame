using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public sealed class ToggleCheck : MonoBehaviour
{

	public Toggle toggleCheck;

	private void Start()
	{
		toggleCheck.isOn = false;
	}

	private void ToggleButtonCheck()
	{
		if (toggleCheck.isOn) toggleCheck.isOn = false;
		else toggleCheck.isOn = true;

	}
}
