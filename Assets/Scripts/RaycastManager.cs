using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{

	private void Start()
	{
		int[] number = { 1, 3, 5, 7 };
		var list = new List<int>();
		list.AddRange(number);

		if(list.Contains(5))
		{
			Debug.Log("5찾음");
		}
		else
		{
			Debug.Log("못찾");
		}
	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			OnClickRay(true);
		}
	}

	public void OnClickRay(bool start)
	{
		var RayStart = start;
		if(RayStart)
		{
			RaycastHit hit = new RaycastHit();

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray.origin, ray.direction, out hit))
			{
				Debug.Log(hit.transform.gameObject.name);
			}
		}

		RayStart = false;
	}
}
