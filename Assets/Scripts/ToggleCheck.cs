using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleCheck : MonoBehaviour
{

	public Toggle toggleCheck;


	private void Start()
	{
		toggleCheck.isOn = true;
	}

	public void ToggleButtonCheck()
	{
		if (toggleCheck.isOn) toggleCheck.isOn = false;
		else toggleCheck.isOn = true;

	}
}
