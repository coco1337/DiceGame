using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
	public List<Toggle> toggleCheck;
	public List<Text> textPrice;
	public Text myMoney;
	int aa;

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
				aa += int.Parse(textPrice[i].text);
			}
			else
			{
				continue;
			}
		}

		Debug.Log(aa);
		var sub = int.Parse(myMoney.text);
		var sum = sub - aa;

		myMoney.text = sum.ToString();
	}
}
