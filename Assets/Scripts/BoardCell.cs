using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class BoardCell : MonoBehaviour
{
  private float moveSpeed;

  private void Start()
  {
    this.moveSpeed = Random.Range(0.5f, 1.5f);
  }

  private void Update()
  {
    this.transform.position = new Vector3(this.transform.position.x, 
			(Mathf.Sin(Time.time * moveSpeed) + 1) / 8, this.transform.position.z);
  }
}