using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerInfo : MonoBehaviour
{
	private int currentIndex;
	public DiceManager diceManager;

	public Text valueText;

	public int diceMove;

	public bool CurrentMoving { get; private set; }


	public void MoveTo(int idx)
	{
		var dest = currentIndex + idx;
		dest = dest >= BlueMarbleManager.Instance.GetBoardSize ? dest - BlueMarbleManager.Instance.GetBoardSize : dest;
		StartCoroutine(CMoveAnimation(dest));
	}

	private IEnumerator CMoveAnimation(int destination)
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

		this.CurrentMoving = false;
	}
}
