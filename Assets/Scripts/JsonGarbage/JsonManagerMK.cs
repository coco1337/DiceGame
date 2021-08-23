using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class PriceManager
{
	public string country;
	public int earthPrice;
	public int buildingPrice;
	public int villaPrice;
	public int hotelPrice;

	public PriceManager(string Country, int EarthPrice, int BuildingPrice, int VillaPrice, int HotelPrice)
	{
		this.country = Country;
		this.earthPrice = EarthPrice;
		this.buildingPrice = BuildingPrice;
		this.villaPrice = VillaPrice;
		this.hotelPrice = HotelPrice;
	}
}

public class JsonManagerMK : MonoBehaviour
{
	public static List<PriceManager> priceList = new List<PriceManager>();
	public static List<PriceManager> myPriceList = new List<PriceManager>();
	public static List<PriceManager> testPriceList = new List<PriceManager>();

	private void Start()
	{
		LoadBase();

		foreach(var dd in testPriceList)
		{
			Debug.Log(dd);
		}
	}

	//void ParsingJson(JsonData name, List<PriceManager> ListPrice)
	//{
	//	for (int i = 0; i < name.Count; i++)
	//	{
	//		var varCountry = name[i][0].ToString();
	//		var varLand = int.Parse(name[i][1].ToString());
	//		var varBuilding = int.Parse(name[i][2].ToString());
	//		var varVilla = int.Parse(name[i][3].ToString());
	//		var varHotel= int.Parse(name[i][4].ToString());

	//		PriceManager tempPriceManager = new PriceManager(varCountry, varLand, varBuilding, varVilla, varHotel);
	//		ListPrice.Add(tempPriceManager);

	//		Debug.Log("넣기완료");

	//	}
	//}

	void ParsingJson(JsonData name)
	{
		for (int i = 0; i < 39; i++)
		{
			var varCountry = name[i][0].ToString();
			var varLand = int.Parse(name[i][1].ToString());
			var varBuilding = int.Parse(name[i][2].ToString());
			var varVilla = int.Parse(name[i][3].ToString());
			var varHotel = int.Parse(name[i][4].ToString());

			PriceManager tempPriceManager = new PriceManager(varCountry, varLand, varBuilding, varVilla, varHotel);
			testPriceList.Add(tempPriceManager);
		}
	}

	public void LoadBase()
	{
		string Jsonstring;
		string filePath;

		filePath = Application.streamingAssetsPath + "/BuildingJson.json";

		if (Application.platform == RuntimePlatform.Android)
		{
			WWW reader = new WWW(filePath);
			while (!reader.isDone) { }

			Jsonstring = reader.text;
		}
		else
		{
			Jsonstring = File.ReadAllText(filePath);
		}

		JsonData priceData = JsonMapper.ToObject(Jsonstring);

		//ParsingJson(priceData, priceList);
		ParsingJson(priceData);

		Debug.Log(priceData[1]["country"].ToString());
		Debug.Log(priceData[1]["earthPrice"].ToString());
	}
}
