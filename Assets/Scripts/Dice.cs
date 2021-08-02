using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
	[SerializeField] private List<PlayerInfo> playerList;

	private int turn;
	private float playerHeightOffset = 1f;

	[HideInInspector]
	public bool isRolling;

	
	public float minRollForce;
	public float maxRollForce;
	private Rigidbody rb;
	public int value;
	public UnityEvent RollEvent;

	private void Awake()
	{
		rb = this.GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (isRolling == true)
		{
			if (rb.IsSleeping())
			{
				isRolling = false;
				CalculateValue();
				RollEvent.Invoke();
			}
		}
	}

	private void CalculateValue()
	{
		var upPosDot = Vector3.Dot(Vector3.up, this.transform.up);
		var rightPosDot = Vector3.Dot(Vector3.up, this.transform.right);
		var forwardPosDot = Vector3.Dot(Vector3.up, this.transform.forward);

        if (System.Math.Abs(upPosDot - 1) < 0.1f) value = 2;
        if (System.Math.Abs(upPosDot - -1) < 0.1f) value = 4;
        if (System.Math.Abs(rightPosDot - 1) < 0.1f) value = 3;
        if (System.Math.Abs(rightPosDot - -1) < 0.1f) value = 1;
        if (System.Math.Abs(forwardPosDot - 1) < 0.1f) value = 5;
        if (System.Math.Abs(forwardPosDot - -1) < 0.1f) value = 6;

    }

	public void AddForceToDice()
	{
		if (!isRolling)
		{
			isRolling = true;
			var RandomPosition = new Vector3(Random.Range(-0.2f, 0.2f), -1, Random.Range(-0.2f, 0.2f));
			rb.AddExplosionForce(Random.Range(minRollForce, maxRollForce), RandomPosition, -0.5f, 2f);
		}
	}
}                                                                                             