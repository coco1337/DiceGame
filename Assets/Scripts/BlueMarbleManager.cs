using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BlueMarbleManager : MonoBehaviour
{
	[SerializeField] private BoardManager boardManager;
	[SerializeField] private UIManager uiManager;
	[SerializeField] private PlayerInfo playerPrefab;
	[SerializeField] private DiceManager dicemanager;
	[SerializeField] private List<PlayerInfo> playerList;


	private int turn;
	int result = 0;

	public static BlueMarbleManager Instance { get; private set; }
	public int GetBoardSize => boardManager.CellList.Count;
	public BoardCell GetCell(int index) => boardManager.CellList[index];
	public float PlayerHeightOffset { get; } = 1f;

	private void Start()
	{
		Instance ??= this;

		var p1 = Instantiate(playerPrefab, boardManager.CellList[0].transform);
		p1.transform.localPosition = new Vector3(p1.transform.localPosition.x,
			p1.transform.localPosition.y + PlayerHeightOffset, p1.transform.localPosition.z);
		this.playerList.Add(p1);
	}


    public void RollDice()
    {

        if (playerList[turn].CurrentMoving) return;

		var result = dicemanager.totalValue;
        playerList[turn].MoveTo(result);
    }


}
