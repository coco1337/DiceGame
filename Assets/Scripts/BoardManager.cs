using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BoardManager : MonoBehaviour
{
  [SerializeField] private List<BoardCell> cellList;

  public List<BoardCell> CellList => cellList;
} 
