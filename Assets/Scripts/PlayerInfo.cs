using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public sealed class PlayerInfo : MonoBehaviour
{
	private UIManager uiManager;

	private int currentIndex;

	public UnityEvent BuyStart;

	public int dest;

	public bool CurrentMoving { get; private set; }

	private void Awake()
	{
		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

	}

	public void MoveTo(int idx)
	{
		dest = currentIndex + idx;
		dest = dest >= BlueMarbleManager.Instance.GetBoardSize ? dest - BlueMarbleManager.Instance.GetBoardSize : dest;
		StartCoroutine(CMoveAnimation(dest, () => BuyStart.Invoke()));

		Debug.Log(dest);
	}

	private IEnumerator CMoveAnimation(int destination, Action temp)
	{
		this.CurrentMoving = true;
		while (currentIndex != destination)
		{
			currentIndex = currentIndex >= BlueMarbleManager.Instance.GetBoardSize - 1 ? 0 : currentIndex + 1;
			var next = BlueMarbleManager.Instance.GetCell(currentIndex);
			var y = this.transform.localPosition.y;
			this.transform.parent = next.transform;
			this.transform.localPosition = new Vector3(0, y, 0);
			yield return new WaitForSeconds(0.5f);
		}

		this.BuyStart.AddListener(uiManager.BuildingBuyOn);
		temp.Invoke();
		this.CurrentMoving = false;
	}
}
