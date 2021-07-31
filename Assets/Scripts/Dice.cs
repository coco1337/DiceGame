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
	public Text sum;
	public int value = 0;
	public float minRollForce;
	public float maxRollForce;
	private Rigidbody rb;
	public UnityEvent RollEvent;

	private void Awake()
	{
		rb = this.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	private void Update()
	{
		if (isRolling == true)
		{
			if (rb.IsSleeping())
			{
				isRolling = false;
				CalculateValue();
				Debug.Log("첫번째 유니티이벤트");
				RollEvent.Invoke();
			}
		}
	}

	private void CalculateValue()
	{
		var upPosDot = Mathf.Abs(Vector3.Dot(Vector3.up, this.transform.up));
		var rightPosDot = Mathf.Abs(Vector3.Dot(Vector3.up, this.transform.right));
		var forwardPosDot = Mathf.Abs(Vector3.Dot(Vector3.up, this.transform.forward));

		if (upPosDot - 1 < 0.1f) value = 2;
		if (upPosDot - -1 < 0.1f) value = 4;
		if (rightPosDot - 1 < 0.1f) value = 3;
		if (rightPosDot - -1 < 0.1f) value = 1;
		if (forwardPosDot - 1 < 0.1f) value = 5;
		if (forwardPosDot - -1 < 0.1f) value = 6;
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
