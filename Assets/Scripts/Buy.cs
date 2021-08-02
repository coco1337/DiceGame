using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public sealed class Buy : MonoBehaviour
{
	public List<Toggle> toggleCheck;
	public List<Text> textPrice;
	public Text myMoney;
	int sum;

	public UnityEvent RollDiceBuyOff;

		// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void BuyLand()
	{
		for(int i=0; i<toggleCheck.Count; i++)
		{
			if (toggleCheck[i].isOn)
			{
				sum += int.Parse(textPrice[i].text);
			}
			else
			{
				continue;
			}
		}


		Debug.Log(sum);
		var sub = int.Parse(myMoney.text);
		var myMoneySum = sub - sum;

		myMoney.text = myMoneySum.ToString();

		RollDiceBuyOff.Invoke();
	}
}
