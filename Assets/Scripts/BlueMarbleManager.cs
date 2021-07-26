using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BlueMarbleManager : MonoBehaviour
{
  private static BlueMarbleManager instance;
  
  [SerializeField] private BoardManager boardManager;
  [SerializeField] private UIManager uiManager;
  [SerializeField] private PlayerInfo playerPrefab;
  [SerializeField] private List<PlayerInfo> playerList;

  private int turn;
  private float playerHeightOffset = 1f;

  public static BlueMarbleManager Instance => instance;
  public int GetBoardSize => boardManager.CellList.Count;
  public BoardCell GetCell(int index) => boardManager.CellList[index];
  public float PlayerHeightOffset => playerHeightOffset;

  private void Start()
  {
    instance ??= this;
    
    var p1 = Instantiate(playerPrefab, boardManager.CellList[0].transform);
    p1.transform.localPosition = new Vector3(p1.transform.localPosition.x,
      p1.transform.localPosition.y + playerHeightOffset, p1.transform.localPosition.z);
    this.playerList.Add(p1);
  }

  public void RollDice()
  {
    if (playerList[turn].CurrentMoving) return;
    var result = Random.Range(1, 7);
    uiManager.UpdateDiceResult(result);
    playerList[turn].MoveTo(result);
  }
}
