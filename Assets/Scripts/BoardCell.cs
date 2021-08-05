using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class BoardCell : MonoBehaviour
{
	[SerializeField] private ECellType cellType;
	[SerializeField] private int owner;
	[SerializeField] private GameObject villa;
	[SerializeField] private GameObject hotel;
	[SerializeField] private GameObject building;
	[SerializeField] private Transform estateTransform;
	
	/// <summary>
	/// [0] : 소유 여부
	/// [1] : 빌딩
	/// [2] : 빌라
	/// [3] : 호텔
	/// </summary>
	[SerializeField] private bool[] buildArray = new bool[4];
	private float moveSpeed;
  
  public ECellType GetCellType => this.cellType;
  public bool[] GetBuildStatus => this.buildArray;

  private void Start()
  {
    this.moveSpeed = Random.Range(0.5f, 1.5f);
		this.villa.SetActive(false);
		this.hotel.SetActive(false);
		this.building.SetActive(false);
  }

  private void Update()
  {
    this.transform.position = new Vector3(this.transform.position.x, 
			(Mathf.Sin(Time.time * this.moveSpeed) + 1) / 8, this.transform.position.z);
  }
}