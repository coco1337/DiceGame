using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class BlueMarbleManager : MonoBehaviour
{
	[SerializeField] private BoardManager boardManager;
	[SerializeField] private UIManager uiManager;
	[SerializeField] private PlayerInfo playerPrefab;
	[SerializeField] private DiceManager dicemanager;
	[SerializeField] public List<PlayerInfo> playerList;

	private Material[] material;

	private int turn;

	public int dest;

	public static BlueMarbleManager Instance { get; private set; }
	public int GetBoardSize => boardManager.CellList.Count;
	public BoardCell GetCell(int index) => boardManager.CellList[index];
	public float PlayerHeightOffset { get; } = 1f;

	private void Start()
	{
		Instance ??= this;

		var p1 = Instantiate(playerPrefab, boardManager.CellList[0].transform);

		//material = p1.GetComponent<MeshRenderer>().materials;
		//p1.GetComponent<MeshRenderer>().materials = material;
		p1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
		
		p1.transform.localPosition = new Vector3(p1.transform.localPosition.x,
			p1.transform.localPosition.y + this.PlayerHeightOffset, p1.transform.localPosition.z);
		this.playerList.Add(p1);
	}

	public void RollDice()
	{
		if (playerList[turn].CurrentMoving) return;
		var result = dicemanager.totalValue;
		playerList[turn].MoveTo(result);
		dest = playerList[turn].dest;
	}
}
